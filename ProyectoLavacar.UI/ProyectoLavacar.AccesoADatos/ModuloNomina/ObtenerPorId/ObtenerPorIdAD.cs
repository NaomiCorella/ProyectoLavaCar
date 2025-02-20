using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.ObtenerPorId
{
   public class ObtenerPorIdAD: IObtenerPorIdAD
    {
        Contexto _elContexto;

        public ObtenerPorIdAD()
        {
            _elContexto = new Contexto();
        }
        public NominaTabla Detalle(int idNomina)
        {
            NominaTabla laPalabraEnBaseDeDatos = _elContexto.NominaTabla.Where(laNomina => laNomina.IdNomina == idNomina).FirstOrDefault();
            return laPalabraEnBaseDeDatos;
        }
    }
}
