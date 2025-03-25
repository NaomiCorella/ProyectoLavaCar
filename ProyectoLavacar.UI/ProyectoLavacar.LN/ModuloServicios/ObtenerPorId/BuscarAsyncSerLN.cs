using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloServicios.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloServicios.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloServicios.ObtenerPorId
{
    public class BuscarAsyncSerLN : IBuscarAsyncSerLN
    {
        IBuscarAsyncSerAD _obtenerPorIdSer;

        public BuscarAsyncSerLN()
        {
            _obtenerPorIdSer = new BuscarAsyncSerAD();
        }

        // Método asincrónico para obtener un servicio
        public async Task<ServiciosDto> DetalleAsync(int idServicio)
        {
            // Llamamos al método asincrónico del AD
            ServiciosTabla serviciosEnBaseDeDatos = await _obtenerPorIdSer.DetalleAsync(idServicio);

            if (serviciosEnBaseDeDatos != null)
            {
                return ConvertirAServicioAMostrar(serviciosEnBaseDeDatos);
            }

            return null;
        }

        private ServiciosDto ConvertirAServicioAMostrar(ServiciosTabla elServicio)
        {
            return new ServiciosDto
            {
                idServicio = elServicio.idServicio,
                costo = elServicio.costo,
                nombre = elServicio.nombre,
                descripcion = elServicio.descripcion,
                tiempoDuracion = elServicio.tiempoDuracion,
                estado = elServicio.estado,
                modalidad = elServicio.modalidad,
                precio = elServicio.precio
            };
        }
    }
}