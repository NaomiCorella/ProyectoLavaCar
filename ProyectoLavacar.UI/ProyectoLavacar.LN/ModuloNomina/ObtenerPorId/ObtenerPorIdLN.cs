using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloReservas.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.ObtenerPorId
{
    public class ObtenerPorIdLN : IObtenerPorIdLN
    {
        IObtenerPorIdNominaAD _obtenerPorIdNominaAD;
        public ObtenerPorIdLN()
        {
            _obtenerPorIdNominaAD = new ObtenerPorIdReservaAD();
        }
        public NominaDto Detalle(int idNomina)
        {
            NominaTabla nominaEnBaseDeDatos = _obtenerPorIdNominaAD.Detalle(idNomina);
            NominaDto nominaAMostrar = ConvertirANominaAMostrar(nominaEnBaseDeDatos);
            return nominaAMostrar;
        }
        private NominaDto ConvertirANominaAMostrar(NominaTabla nomina)
        {

            return new NominaDto
            {
                IdNomina = nomina.IdNomina,
                IdEmpleado = nomina.IdEmpleado,
                DiasDispoVacaciones = nomina.DiasDispoVacaciones,
                DiasUtiliVacaciones = nomina.DiasUtiliVacaciones,
                Estado = nomina.Estado,
                FechaDePago = nomina.FechaDePago,
                HorasDobles = nomina.HorasDobles,
               HorasExtras = nomina.HorasExtras,
               HorasOrdinarias = nomina.HorasOrdinarias,
               Incapacidad = nomina.Incapacidad,
               PeriodoDePago = nomina.PeriodoDePago,
               SalarioBruto = nomina.SalarioBruto,
               SalarioNeto = nomina.SalarioNeto,
               TipoDeContrato= nomina.TipoDeContrato
            };
        }
    }
}
