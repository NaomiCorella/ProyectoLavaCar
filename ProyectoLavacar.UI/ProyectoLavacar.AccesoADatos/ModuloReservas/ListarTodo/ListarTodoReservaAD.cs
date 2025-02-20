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

        public List<ReservaCompleta> ListarReservasTodo()
        {
            List<ReservaCompleta> lalistadeServicios = (from reserva in _elContexto.ReservasTabla
                                                        join elCliente in _elContexto.UsuariosTabla
                                                            on reserva.idCliente equals elCliente.Id
                                                        join elEmpleado in _elContexto.UsuariosTabla
                                                    on reserva.idEmpleado equals elEmpleado.Id
                                                        join servicio in _elContexto.ServiciosTabla
                                                      on reserva.idServicio equals servicio.idServicio
                                                        select new ReservaCompleta
                                                     {
                                                         idReserva = reserva.idReserva,
                                                         idCliente = reserva.idCliente,
                                                         idEmpleado = reserva.idEmpleado,
                                                         idServicio = reserva.idServicio,
                                                         fecha = reserva.fecha.ToString(),
                                                         hora = reserva.hora.ToString(),
                                                         estado = reserva.estado,
                                                         nombreCliente= elCliente.nombre,
                                                         nombreEmpleado = elEmpleado.nombre,
                                                         nombreServicio= servicio.nombre
                                                     }).ToList();
            return lalistadeServicios;
        }
    }
}
