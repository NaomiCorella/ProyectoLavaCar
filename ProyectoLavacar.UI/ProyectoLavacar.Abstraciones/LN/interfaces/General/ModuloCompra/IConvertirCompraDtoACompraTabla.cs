using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloCompra
{
     public interface IConvertirCompraDtoACompraTabla
    {
       CompraTabla ConvertirCompra(CompraDto laCompra);
    }
}
