using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloCompra.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloCompra.ObtenerPorId
{
    public class ObtenerPorIdLN : IObtenerPorIdLN
    {
        IObtenerPorIdAD _obtenerPorIdCompraAD;
        public ObtenerPorIdLN()
        {
            _obtenerPorIdCompraAD = new ObtenerPorIdAD();
        }
        public CompraDto Detalle(int idCompra)
        {
            CompraTabla CompraEnBaseDeDatos = _obtenerPorIdCompraAD.Detalle(idCompra);
            CompraDto laCompraAMostrar = ConvertirACompraAMostrar(CompraEnBaseDeDatos);
            return laCompraAMostrar;
        }
        private CompraDto ConvertirACompraAMostrar(CompraTabla laCompra)
        {

            return new CompraDto
            {
                idCompra = laCompra.idCompra,
                idCliente = laCompra.idCliente,
                Total = laCompra.Total,
                DescripcionServicio = laCompra.DescripcionServicio,
                fecha = laCompra.fecha.ToString(),
                Estado = laCompra.Estado
            };
        }
    }
}
