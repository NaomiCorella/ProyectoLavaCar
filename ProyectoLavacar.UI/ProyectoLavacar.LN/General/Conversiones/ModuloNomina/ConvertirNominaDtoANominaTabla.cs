using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.General.Conversiones.ModuloNomina
{
    public class ConvertirNominaDtoANominaTabla : IConvertirNominaDtoANominaTabla
    {

        public NominaTabla ConvertirNomina(NominaDto laNomina)
        {
            return new NominaTabla
            {
                IdNomina = laNomina.IdNomina,
                IdEmpleado = laNomina.IdEmpleado,
                SalarioBruto = laNomina.SalarioBruto,
                SalarioNeto = laNomina.SalarioNeto,
                HorasExtras = laNomina.HorasExtras,
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
                bonoHorasExtra = laNomina.bonoHorasExtra,
               

            };
        }
    }
}
