using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.BuscarPorIdInventario
{
    public interface IBuscarPorIdInventarioLN
    {
        InventarioDto Detalle(int idInventario);
    }
}
