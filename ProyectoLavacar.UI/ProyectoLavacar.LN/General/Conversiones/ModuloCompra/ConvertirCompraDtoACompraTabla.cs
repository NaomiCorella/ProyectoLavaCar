using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloCompra;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.General.Conversiones.ModuloCompra
{
    public class ConvertirCompraDtoACompraTabla : IConvertirCompraDtoACompraTabla

    {
        IFecha _fecha;
        public ConvertirCompraDtoACompraTabla()
        {
            _fecha = new ProyectoLavacar.LN.General.Fecha.Fecha();
        }
        public CompraTabla ConvertirCompra(CompraDto compra)
        {
            return new CompraTabla
            {
                idCompra = compra.idCompra,
                idCliente = compra.idCliente,
      
                fecha = _fecha.ObtenerFecha(),
                DescripcionServicio = compra.DescripcionServicio,
                Total = compra.Total,
                Estado = compra.Estado




            };
        }
    }

}


