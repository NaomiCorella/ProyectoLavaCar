
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.ObtenerPorId
{
    public interface IObtenerPorIdLN
    {

        CompraDto Detalle(Guid idCompra);
    }
}
