using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.ListarMovimiento
{
    public interface IListarMovimientoAD
    {
        List<MovimientoDto> ListarMovimiento();
    }
}
