using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.Editar;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.IngresarHoras;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.RegistroHoraSalida;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.RegistroHoraSalida;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloNomina.EditarNomina;
using ProyectoLavacar.AccesoADatos.ModuloNomina.RegistrarHoraSalida;
using ProyectoLavacar.LN.General.Conversiones.ModuloNomina;
using ProyectoLavacar.LN.ModuloNomina.EditarNomina;
using ProyectoLavacar.LN.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.LN.ModuloNomina.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.RegistroHoraSalida
{
    public class RegistroHoraSalidaLN : IRegistroHoraSalidaLN
    {
        IRegistroHoraSalidaAD _Registrar;
        IConvertirRegistroHorasDtoARegistroHorasTabla _convertirObjeto;
        IEditarNominaLN _editarNomina;
        IListarUnicoEmpleadoLN _listarNominaDelEmpelado;
        public RegistroHoraSalidaLN()
        {
            _Registrar = new RegistrarHoraSalidaAD();
            _convertirObjeto = new ConvertirRegistroHorasDtoARegistroHorasTabla();
            _editarNomina = new EditarNominaLN();
            _listarNominaDelEmpelado = new ListarUnicoEmpleadoLN();
        }

        public async Task<int> RegistroHoraSalida(RegistroHorasDto hora)
        {
            int horas = HorasTotales(hora);
            RegistroHorasDto horaEditada = new RegistroHorasDto()
            {
                idRegistro = hora.idRegistro,
                HoraEntrada = hora.HoraEntrada,
                HoraSalida = hora.HoraSalida,
                idEmpleado = hora.idEmpleado,
                estado = hora.estado,
                totalHoras = horas
            };
            int cantidadDeDatosEditados = await _Registrar.RegistroHoraSalida(_convertirObjeto.Convertir(horaEditada));
            int hecho=registrarHorasExtra(hora);
            return cantidadDeDatosEditados;
        }

        public int HorasTotales(RegistroHorasDto hora)
        {
            DateTime horaEntrada = DateTime.Parse(hora.HoraEntrada);
            DateTime horaSalida = DateTime.Parse(hora.HoraSalida);

            TimeSpan diferencia = horaSalida - horaEntrada;

            int horasTotales = (int)diferencia.TotalHours;
            return horasTotales;
        }

        public int registrarHorasExtra(RegistroHorasDto hora)
        {

            UnicoEmpleadoDto laNomina = _listarNominaDelEmpelado.ListarNomina(hora.idEmpleado).LastOrDefault();
            int? jornada = laNomina.HorasOrdinarias;
            int? horasTrabajadas =HorasTotales(hora);
            int horasExtras = 0;
            if (horasTrabajadas > jornada)
            {
                 horasExtras = horasTrabajadas.Value - jornada.Value;
              
            }
            else if (horasTrabajadas < jornada)
            {
                horasExtras = 0;
            }
            int? horasExtraTotales =laNomina.HorasExtras += horasExtras;
            NominaDto nomina = new NominaDto
            {
                IdNomina = laNomina.IdNomina,
                IdEmpleado = laNomina.IdEmpleado,
                SalarioBruto = laNomina.SalarioBruto,
                SalarioNeto = laNomina.SalarioNeto,
                HorasExtras = horasExtras,
                HorasDobles = laNomina.HorasDobles,
                HorasOrdinarias = laNomina.HorasOrdinarias,
                PeriodoDePago = laNomina.PeriodoDePago,
                FechaDePago = laNomina.FechaDePago,
                TipoDeContrato = laNomina.TipoDeContrato,
                DiasDispoVacaciones = laNomina.DiasDispoVacaciones,
                DiasUtiliVacaciones = laNomina.DiasUtiliVacaciones,
                Incapacidad = laNomina.Incapacidad,
                Estado = laNomina.Estado,
                totalBono = laNomina.totalBono,
                totalDedu = laNomina.totalDedu,
                deduccionCCSS = laNomina.deduccionCCSS,
                deduccionISR = laNomina.deduccionISR,
                bonoHorasExtra = laNomina.bonoHorasExtra

            };
            _editarNomina.EditarNomina(nomina);
            return 1;   
        }
    }
}
