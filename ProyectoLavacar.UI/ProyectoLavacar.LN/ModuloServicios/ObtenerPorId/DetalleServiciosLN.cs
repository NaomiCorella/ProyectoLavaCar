using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloServicios.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloReservas.ObtenerPorId;
using ProyectoLavacar.AccesoADatos.ModuloServicios.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloServicios.ObtenerPorId
{
    public class DetalleServiciosLN : IDetalleServiciosLN
    {
        IDetallesServicioAD _obtenerPorIdServiciosAD;
        public DetalleServiciosLN()
        {
            _obtenerPorIdServiciosAD = new DetallesServicioAD();
        }
        public ServiciosDto Detalle(int idServicio)
        {
            ServiciosTabla serviciosEnBaseDeDatos = _obtenerPorIdServiciosAD.Detalle(idServicio);
            ServiciosDto laServicioAMostrar = ConvertirAServicioAMostrar(serviciosEnBaseDeDatos);
            return laServicioAMostrar;
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
                modalidad = elServicio.modalidad

            };


        }
    }
}
