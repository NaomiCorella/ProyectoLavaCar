using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReseñas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloReseñas.ObtenerPorId
{
    public class ObtenerPorIdAD: IObtenerPorIdAD
    {
        Contexto _elContexto;

        public ObtenerPorIdAD()
        {
            _elContexto = new Contexto();
        }
        public ReseniasTabla Detalle(int idReserva)
        {
            ReseniasTabla laPalabraEnBaseDeDatos = _elContexto.ReseniasTabla.Where(laReserva => laReserva.idResenia == idReserva).FirstOrDefault();
            return laPalabraEnBaseDeDatos;
        }
    }
}
