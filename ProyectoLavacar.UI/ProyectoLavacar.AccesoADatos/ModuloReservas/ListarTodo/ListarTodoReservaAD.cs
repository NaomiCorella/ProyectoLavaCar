using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ListarTodo;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloReservas.ListarTodo
{
    public class ListarTodoReservaAD : IListarTodoReservaAD
    {
        Contexto _elContexto;

        public ListarTodoReservaAD()
        {
            _elContexto = new Contexto();
        }

        public List<ReservasDto> ListarReservasTodo()
        {
            List<ReservasDto> lalistadeServicios = (from reserva in _elContexto.ReservasTabla
                                                     select new ReservasDto
                                                     {
                                                         idReserva = reserva.idReserva,
                                                         idCliente = reserva.idCliente,
                                                         idEmpleado = reserva.idEmpleado,
                                                         idServicio = reserva.idServicio,
                                                         fecha = reserva.fecha.ToString(),
                                                         hora = reserva.hora.ToString(),
                                                         estado = reserva.estado
                                                     }).ToList();
            return lalistadeServicios;
        }
    }
}
