using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModulaInventario;

using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;

using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.General.Conversiones.ModuloInventario
{
    public class ConvertirInventarioDtoAInventarioTabla : IConvertirInventarioDtoAInventarioTabla
    {
        public InventarioTabla ConvertirInventario(InventarioDto elInventario)
        {
            return new InventarioTabla
            {
                nombre = elInventario.nombre,
                categoria = elInventario.categoria,
                cantidadDisponible = elInventario.cantidadDisponible,
                precioUnitario = elInventario.precioUnitario,
                estado = elInventario.estado,
                idProducto = elInventario.idProducto,

            };
        }
    }
}
