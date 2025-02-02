using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloInventario.Listar
{
    public class ListarInventarioAD : IListarInventarioAD
    {
        Contexto _elContexto;

        public ListarInventarioAD()
        {
            _elContexto = new Contexto();
        }

        public List<InventarioDto> ListarInventario()
        {
            List<InventarioDto> laListaDeInventario = (from elInventario in _elContexto.InventarioTabla

                                                   select new InventarioDto
                                                   {
                                                       nombre = elInventario.nombre,
                                                       categoria = elInventario.categoria,
                                                       cantidadDisponible = elInventario.cantidadDisponible,
                                                       precioUnitario = elInventario.precioUnitario,

                                                       estado = elInventario.estado,
                                                       idInventario = elInventario.idInventario,

                                                   }).ToList();
            return laListaDeInventario;
        }
    }
}
