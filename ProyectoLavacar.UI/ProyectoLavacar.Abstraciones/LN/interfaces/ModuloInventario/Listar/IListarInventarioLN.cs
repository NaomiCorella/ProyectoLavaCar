using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.Listar
{
    public interface IListarInventarioLN
    {
        List<InventarioDto> ListarInventario();
    }
}
