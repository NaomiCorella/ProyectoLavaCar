using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.DetallesAjustes;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.DetalleAjustes
{
   public  class DetalleAjustesAD :IDetallesAjustesAD
    {
        Contexto _elContexto;

        public DetalleAjustesAD()
        {
            _elContexto = new Contexto();
        }
        public AjustesSalarialesTabla Detalle(int idAjuste)
        {
            AjustesSalarialesTabla laPalabraEnBaseDeDatos = _elContexto.AjustesSalarialesTabla.Where(elAjuste => elAjuste.IdAjusteSalarial == idAjuste).FirstOrDefault();
            return laPalabraEnBaseDeDatos;
        }
    }
}
