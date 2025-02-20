using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.DetallesReservaCompleta;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloReservas.DetallesReservaCompletaLN
{
     public class DetallesReservaCompletaAD: IDetallesReservaCompletaAD
    {
        Contexto _elContexto;

        public DetallesReservaCompletaAD()
        {
            _elContexto = new Contexto();
        }
        public ReservaCompleta Detalle(int idReserva)
        {
            var reservaCompleta = (from reserva in _elContexto.ReservasTabla
                                   join elCliente in _elContexto.UsuariosTabla
                                       on reserva.idCliente equals elCliente.Id
                                   join elEmpleado in _elContexto.UsuariosTabla
                                       on reserva.idEmpleado equals elEmpleado.Id
                                   join servicio in _elContexto.ServiciosTabla
                                       on reserva.idServicio equals servicio.idServicio
                                   where reserva.idReserva == idReserva
                                   select new ReservaCompleta
                                   {
                                       idReserva = reserva.idReserva,
                                       idCliente = reserva.idCliente,
                                       idEmpleado = reserva.idEmpleado,
                                       idServicio = reserva.idServicio,
                                       fecha = reserva.fecha.ToString(),
                                       hora = reserva.hora.ToString(),
                                       estado = reserva.estado,
                                       nombreCliente = elCliente.nombre,
                                       nombreEmpleado = elEmpleado.nombre,
                                       nombreServicio = servicio.nombre
                                   }).FirstOrDefault();

            return reservaCompleta;
        }
    }
}
