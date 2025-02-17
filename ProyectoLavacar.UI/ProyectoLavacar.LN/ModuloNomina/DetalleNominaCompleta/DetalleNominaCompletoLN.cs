using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEvaluaciones.Listar;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.DetalleNominaCompleta;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.DetalleNominaCompleta;
using ProyectoLavacar.Abstraciones.Modelos.ModeloEvaluaciones;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;

using ProyectoLavacar.AccesoADatos.ModuloNomina.DetalleNominaCompleta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.DetalleNominaCompleta
{
    public class DetalleNominaCompletoLN : IDetalleNominaCompletaLN
    {
        private IDetallesNominaCompletaAD _DetalleNominaCompletaAD;

        public DetalleNominaCompletoLN()
        {
            _DetalleNominaCompletaAD = new DetalleNominaCompletaAD();
        }

        public NominaCompletaDto Detalle(int idNomina)
        {
            var laNominaEnBaseDeDatos = _DetalleNominaCompletaAD.Detalle(idNomina);
            var laNominaAMostrar = ConvertirNominaAMostrar(laNominaEnBaseDeDatos);

            return laNominaAMostrar;
        }

        private NominaCompletaDto ConvertirNominaAMostrar(NominaCompletaDto laNomina)
        {
            return new NominaCompletaDto
            {
                IdNomina = laNomina.IdNomina,
                SalarioNeto = laNomina.SalarioNeto,
                SalarioBruto = laNomina.SalarioBruto,
                FechaDePago = laNomina.FechaDePago,
                PeriodoDePago = laNomina.PeriodoDePago,
                HorasOrdinarias = laNomina.HorasOrdinarias,
                HorasExtras = laNomina.HorasExtras,
                HorasDobles = laNomina.HorasDobles,
                DiasDispoVacaciones = laNomina.DiasDispoVacaciones,
                DiasUtiliVacaciones = laNomina.DiasUtiliVacaciones,
                Incapacidad = laNomina.Incapacidad,
                TipoDeContrato = laNomina.TipoDeContrato,
                Estado = laNomina.Estado,

                // Ajustes salariales
                IdAjusteSalarial = laNomina.IdAjusteSalarial,
                Monto = laNomina.Monto,
                RazonAjuste = laNomina.RazonAjuste,

                // Tramites
                IdTramite = laNomina.IdTramite,
                FechaInicio = laNomina.FechaInicio,
                FechaFin = laNomina.FechaFin,
                RazonTramite = laNomina.RazonTramite,

                // Datos del empleado
                IdEmpleado = laNomina.IdEmpleado,
                nombre = laNomina.nombre,
                primer_apellido = laNomina.primer_apellido,
                segundo_apellido = laNomina.segundo_apellido,
                telefono = laNomina.telefono,
                correo = laNomina.correo,
                cedula = laNomina.cedula,
                puesto = laNomina.puesto,
                turno = laNomina.turno,
                estado = laNomina.estado,
                numeroCuenta = laNomina.numeroCuenta
            };
        }
    }
}
