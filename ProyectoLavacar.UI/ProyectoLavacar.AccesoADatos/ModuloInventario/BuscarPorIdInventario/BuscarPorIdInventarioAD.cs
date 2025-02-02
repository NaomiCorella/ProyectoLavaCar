using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.BuscarPorIdInventario;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloInventario.BuscarPorIdInventario
{
    public class BuscarPorIdInventarioAD : IBuscarPorIdInventarioAD
    {
        Contexto _elContexto;

        public BuscarPorIdInventarioAD()
        {
            _elContexto = new Contexto();
        }
        public InventarioTabla Detalle(int idInventario)
        {
            InventarioTabla laPalabraEnBaseDeDatos = _elContexto.InventarioTabla.Where(elInventario => elInventario.idInventario == idInventario).FirstOrDefault();
            return laPalabraEnBaseDeDatos;
        }

       
    }
}
