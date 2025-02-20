using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ListarDisponibles;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloReservas.ListarDisponibles
{
    public class ListarDisponiblesAD : IListarDisponiblesAD
    {
        Contexto _elContexto;

        public ListarDisponiblesAD()
        {
            _elContexto = new Contexto();
        }

        public List<ReservaCompleta> ListarReservasCliente(string idCliente)
        {
            List<ReservaCompleta> lalistadeServicios = (from reserva in _elContexto.ReservasTabla
                                                    join cliente in _elContexto.UsuariosTabla on reserva.idCliente equals cliente.Id
                                                    where reserva.idCliente == idCliente
                                                    join empleados in _elContexto.UsuariosTabla
                                                           on reserva.idEmpleado equals empleados.Id
                                                    join servicio in _elContexto.ServiciosTabla
                                                      on reserva.idServicio equals servicio.idServicio
                                                    select new ReservaCompleta
                                                    {
                                                        idReserva = reserva.idReserva,
                                                        idCliente = reserva.idCliente,
                                                        idEmpleado = reserva.idEmpleado,
                                                        idServicio = reserva.idServicio,
                                                        nombreServicio = servicio.nombre,
                                                        nombreCliente = cliente.nombre,
                                                        nombreEmpleado = empleados.nombre,
                                                        fecha = reserva.fecha.ToString(),
                                                        hora = reserva.hora.ToString(),
                                                        estado = reserva.estado
                                                    }).ToList();
            return lalistadeServicios;
        }
    }
}
