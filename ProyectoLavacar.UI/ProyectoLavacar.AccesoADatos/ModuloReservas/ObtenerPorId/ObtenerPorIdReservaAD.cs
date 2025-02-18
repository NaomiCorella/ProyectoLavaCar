using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloReservas.ObtenerPorId
{
    public class ObtenerPorIdReservaAD : IObtenerPorIdNominaAD
    {
        Contexto _elContexto;

        public ObtenerPorIdReservaAD()
        {
            _elContexto = new Contexto();
        }
        public ReservasTabla Detalle(int idReserva)
        {
            ReservasTabla laPalabraEnBaseDeDatos = _elContexto.ReservasTabla.Where(laReserva => laReserva.idReserva == idReserva).FirstOrDefault();
            return laPalabraEnBaseDeDatos;
        }
    }
}
