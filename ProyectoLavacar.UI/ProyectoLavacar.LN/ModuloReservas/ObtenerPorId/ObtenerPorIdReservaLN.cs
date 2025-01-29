using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloReservas.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloReservas.ObtenerPorId
{
    public class ObtenerPorIdReservaLN : IObtenerPorIdReservaLN
    {

        IObtenerPorIdReservaAD _obtenerPorIdReservaAD;
        public ObtenerPorIdReservaLN()
        {
            _obtenerPorIdReservaAD = new ObtenerPorIdReservaAD();
        }
        public ReservasDto Detalle(int idReserva)
        {
            ReservasTabla reservaEnBaseDeDatos = _obtenerPorIdReservaAD.Detalle(idReserva);
            ReservasDto laReservaAMostrar = ConvertirAReservaAMostrar(reservaEnBaseDeDatos);
            return laReservaAMostrar;
        }
        private ReservasDto ConvertirAReservaAMostrar(ReservasTabla reserva)
        {
        
            return new ReservasDto
            {
                idReserva = reserva.idReserva,
                idCliente = reserva.idCliente,
                idEmpleado = reserva.idEmpleado,
                idServicio = reserva.idServicio,
                fecha = reserva.fecha.ToString(),
                hora = reserva.hora.ToString(),
                estado = reserva.estado
            };
        }
    }
}

