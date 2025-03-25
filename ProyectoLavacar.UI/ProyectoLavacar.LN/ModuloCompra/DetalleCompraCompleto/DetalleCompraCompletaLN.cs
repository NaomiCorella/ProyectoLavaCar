using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.DetalleCompraCompleto;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.DetalleCompraCompleta;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.ListarDetalles;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using ProyectoLavacar.AccesoADatos.ModuloCompra.DetalleCompraCompleta;
using ProyectoLavacar.AccesoADatos.ModuloServicios.ObtenerPorId;
using ProyectoLavacar.LN.ModuloCompra.ListarDetalles;
using ProyectoLavacar.LN.ModuloServicios.ObtenerPorId;
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
        IListarDetallesDeServiciosLN _listarServiciosPorCompra;
        IDetalleServiciosLN _DetallesDelServicio;
        public DetalleCompraCompletaLN()
        {
            _obtenerPorIdAD = new DetalleCompraCompletaAD();
            _listarServiciosPorCompra = new ListarDetallesDeServicioLN();
            _DetallesDelServicio = new DetalleServiciosLN();
        }
        public CompraCompletaDto Detalle(Guid idCompra)
        {
            CompraCompletaDto CompraEnBaseDeDatos = _obtenerPorIdAD.Detalle(idCompra);
            CompraCompletaDto laCompraAMostrar = ConvertirACompraAMostrar(CompraEnBaseDeDatos);
            List<ServiciosDto> listaDeServicios = listar(laCompraAMostrar);
            return laCompraAMostrar;
        }
        private CompraCompletaDto ConvertirACompraAMostrar(CompraCompletaDto Compra)
        {

            return new CompraCompletaDto
            {
                idCompra = Compra.idCompra,
                Nombre = Compra.Nombre,
                PrimerApellido = Compra.PrimerApellido,
                SegundoApellido = Compra.SegundoApellido,
                Cedula = Compra.Cedula,
                Total = Compra.Total,
                Fecha = Compra.Fecha,
                DescripcionServicio = Compra.DescripcionServicio,
                listaDeServicios = listar(Compra)
            };
        }

        private List<ServiciosDto> listar (CompraCompletaDto compra)
        {
            List<CompraServiciosDto> listaDeServiciosID = _listarServiciosPorCompra.ListarCompra(compra.idCompra);
            List<ServiciosDto> listaDeServicios = new List<ServiciosDto>();
            foreach (CompraServiciosDto lacompra in listaDeServiciosID)
            {
                ServiciosDto servicio = _DetallesDelServicio.Detalle(lacompra.idServicio);
                compra.listaDeServicios.Add(servicio);
            }
            return listaDeServicios;
        }
    }
}


