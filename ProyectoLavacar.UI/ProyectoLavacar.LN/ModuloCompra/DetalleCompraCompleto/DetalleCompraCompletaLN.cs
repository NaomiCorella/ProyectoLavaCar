using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.DetalleCompraCompleto;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.DetalleCompraCompleta;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using ProyectoLavacar.AccesoADatos.ModuloCompra.DetalleCompraCompleta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloCompra.DetalleCompraCompleto
{
    public class DetalleCompraCompletaLN : IDetalleCompraCompletaLN
    {
        IDetalleCompraCompletaAD _obtenerPorIdAD;
        public DetalleCompraCompletaLN()
        {
            _obtenerPorIdAD = new DetalleCompraCompletaAD();
        }
        public CompraCompletaDto Detalle(Guid idCompra)
        {
            CompraCompletaDto CompraEnBaseDeDatos = _obtenerPorIdAD.Detalle(idCompra);
            CompraCompletaDto laCompraAMostrar = ConvertirACompraAMostrar(CompraEnBaseDeDatos);
            return laCompraAMostrar;
        }
        private CompraCompletaDto ConvertirACompraAMostrar(CompraCompletaDto Compra)
        {

            return new CompraCompletaDto
            {
                idCompra = Compra.idCompra,
                idCliente = Compra.idCliente,
                idServicio = Compra.idServicio,

                Nombre = Compra.Nombre,
                PrimerApellido = Compra.PrimerApellido,
                SegundoApellido = Compra.SegundoApellido,
                Cedula = Compra.Cedula,

                nombre = Compra.nombre,
                costo = Compra.costo,

                Total = Compra.Total,
                Fecha = Compra.Fecha,
                DescripcionServicio = Compra.DescripcionServicio,
                Estado = Compra.Estado,
                
                

            };
        }
    }
}


