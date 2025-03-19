using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloCompra.Crear;
using ProyectoLavacar.LN.General.Fecha;
using ProyectoLavacar.LN.ModuloCompra.CrearCompraServicio;
using ProyectoLavacar.LN.ModuloServicios.ListarServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloCompra.Crear
{
    public class CrearCompraLN : ICrearCompraLN
    {
        ICrearCompraAD _crearCompra;
        IFecha _fecha;
        CrearCompraServicioLN _compraServicio;
        IListarServiciosLN _listarServicios;
        public CrearCompraLN()
        {
            _fecha = new Fecha();
            _crearCompra = new CrearCompraAD();
            _compraServicio = new CrearCompraServicioLN();
            _listarServicios = new ListarServiciosLN();
        }

        public async Task<int> CrearCompra(CompraDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _crearCompra.CrearCompra(ConvertirObjetoArchivosTabla(modelo));
            int cantidad = await  CrearCompraServicios(modelo);
            return cantidadDeDatosAlmacenados;
        }

        public CompraTabla ConvertirObjetoArchivosTabla(CompraDto Compra)
        {
            return new CompraTabla
            {
                idCompra = Compra.idCompra,
                idCliente = Compra.idCliente,
                DescripcionServicio = Compra.DescripcionServicio,
                fecha = _fecha.ObtenerFecha(),
                Total = total(Compra),
                Estado = Compra.Estado
            };
        }
          public async Task<int> CrearCompraServicios(CompraDto modelo)
        {
            int cantidadDeDatos=0;

            foreach (int servicio in modelo.listaServicios)
            {
                CompraServiciosDto compraServicio = new CompraServiciosDto
                {
                    idCompra = modelo.idCompra,
                    idCompraServicios =9,
                    idServicio = servicio
                };
                cantidadDeDatos = await _compraServicio.CrearCompra(compraServicio);

            }
            return cantidadDeDatos;
        }

        public decimal total(CompraDto modelo)
        {
         List<ServiciosDto> serviciosDtos = _listarServicios.ListarServicios();
            decimal total = 0;
            foreach (int servicio in modelo.listaServicios)
            {
                foreach (ServiciosDto serv in serviciosDtos)
                {
                    if (serv.idServicio == servicio)
                    {
                        total += serv.costo;
                    }
                }
            }
            return total;
        }

    }
}


