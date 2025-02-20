using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.DetallesReservaCompleta;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.DetallesReservaCompleta;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloReservas.DetallesReservaCompletaLN;
using ProyectoLavacar.AccesoADatos.ModuloReservas.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloReservas.DetallesReservaCompleta
{
    public class DetallesReservaCompletaLN : IDetallesReservaCompletaLN
    {
        IDetallesReservaCompletaAD _obtenerPorIdReservaAD;
        public DetallesReservaCompletaLN()
        {
            _obtenerPorIdReservaAD = new DetallesReservaCompletaAD();
        }
        public ReservaCompleta Detalle(int idReserva)
        {
            ReservaCompleta reservaEnBaseDeDatos = _obtenerPorIdReservaAD.Detalle(idReserva);
            ReservaCompleta laReservaAMostrar = ConvertirAReservaAMostrar(reservaEnBaseDeDatos);
            return laReservaAMostrar;
        }
        private ReservaCompleta ConvertirAReservaAMostrar(ReservaCompleta reserva)
        {

            return new ReservaCompleta
            {
                idReserva = reserva.idReserva,
                idCliente = reserva.idCliente,
                idEmpleado = reserva.idEmpleado,
                idServicio = reserva.idServicio,
                fecha = reserva.fecha.ToString(),
                hora = reserva.hora.ToString(),
                estado = reserva.estado,
                nombreCliente = reserva.nombreCliente,
                nombreEmpleado = reserva.nombreEmpleado,
                nombreServicio = reserva.nombreServicio
            };
        }
    }
}
