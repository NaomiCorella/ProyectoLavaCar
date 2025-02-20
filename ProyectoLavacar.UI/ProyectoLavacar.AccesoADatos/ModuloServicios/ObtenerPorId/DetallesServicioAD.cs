using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloServicios.ObtenerPorId;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloServicios.ObtenerPorId
{
     public class DetallesServicioAD  : IDetallesServicioAD
    {
        Contexto _elContexto;

        public DetallesServicioAD()
        {
            _elContexto = new Contexto();
        }
        public ServiciosTabla Detalle(int idServicio)
        {
            ServiciosTabla laPalabraEnBaseDeDatos = _elContexto.ServiciosTabla.Where(elServicio => elServicio.idServicio == idServicio).FirstOrDefault();
            return laPalabraEnBaseDeDatos;
        }
    }
}
