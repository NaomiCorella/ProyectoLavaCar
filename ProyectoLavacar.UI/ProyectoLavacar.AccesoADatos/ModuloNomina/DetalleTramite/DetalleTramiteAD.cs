using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.DetallesTramites;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.DetalleTramite
{
    public class DetalleTramiteAD :IDetallesTramitesAD
    {
        Contexto _elContexto;

        public DetalleTramiteAD()
        {
            _elContexto = new Contexto();
        }
        public TramitesTabla Detalle(int idTramite)
        {
            TramitesTabla laPalabraEnBaseDeDatos = _elContexto.TramitesTabla.Where(elTramite => elTramite.IdTramite == idTramite).FirstOrDefault();
            return laPalabraEnBaseDeDatos;
        }
    }
}
