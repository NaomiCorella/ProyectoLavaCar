using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarGeneral;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarGeneral;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloNomina.ListarGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.ListarGeneral
{
    public class ListarGeneralLN : IListarGeneralLN
    {
         IListarGeneralAD _listarGeneralAD;

        public ListarGeneralLN()
        {
            _listarGeneralAD = new ListarGeneralAD();
        }


        public List<GeneralDto> ListarNomina()
        {
            List<GeneralDto> laListaDeNominasEmpleado = _listarGeneralAD.ListarGeneral();
            return laListaDeNominasEmpleado;
        }

        private List<GeneralDto> ObtenerListaConvertida(List<NominaTabla> listaNomina, List<UsuariosTabla> listaUsuarios)
        {
            var joinLista = from nomina in listaNomina
                            join usuario in listaUsuarios on nomina.IdEmpleado equals usuario.Id
                            select new GeneralDto
                            {
                                IdNomina = nomina.IdNomina,
                                IdEmpleado = usuario.Id,
                                SalarioNeto = nomina.SalarioNeto,
                                SalarioBruto = nomina.SalarioBruto,
                                FechaDePago = nomina.FechaDePago,
                                PeriodoDePago = nomina.PeriodoDePago,
                                HorasOrdinarias = nomina.HorasOrdinarias,
                                HorasExtras = nomina.HorasExtras,
                                HorasDobles = nomina.HorasDobles,
                                DiasDispoVacaciones = nomina.DiasDispoVacaciones,
                                DiasUtiliVacaciones = nomina.DiasUtiliVacaciones,
                                Incapacidad = nomina.Incapacidad,
                                TipoDeContrato = nomina.TipoDeContrato,
                                Estado = nomina.Estado
                            };

            return joinLista.ToList();
        }

        private GeneralDto ConvertirObjetoNominaDto(NominaTabla nomina, UsuariosTabla usuario)
        {
            return new GeneralDto
            {
                IdNomina = nomina.IdNomina,
                IdEmpleado = usuario.Id,
                SalarioNeto = nomina.SalarioNeto,
                SalarioBruto = nomina.SalarioBruto,
                FechaDePago = nomina.FechaDePago,
                PeriodoDePago = nomina.PeriodoDePago,
                HorasOrdinarias = nomina.HorasOrdinarias,
                HorasExtras = nomina.HorasExtras,
                HorasDobles = nomina.HorasDobles,
                DiasDispoVacaciones = nomina.DiasDispoVacaciones,
                DiasUtiliVacaciones = nomina.DiasUtiliVacaciones,
                Incapacidad = nomina.Incapacidad,
                TipoDeContrato = nomina.TipoDeContrato,
                Estado = nomina.Estado
            };
        }


    }
}
