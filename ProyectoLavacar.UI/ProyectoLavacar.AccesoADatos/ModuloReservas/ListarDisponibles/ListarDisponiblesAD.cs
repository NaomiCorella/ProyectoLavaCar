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

        public List<ReservasDto> ListarReservasCliente(int idCliente)
        {
            List<ReservasDto> lalistadeServicios = (from reserva in _elContexto.ReservasTabla
                                                    join cliente in _elContexto.UsuariosTabla on reserva.idCliente equals cliente.idCliente
                                                    where reserva.idCliente == idCliente
                                                    select new ReservasDto
                                                    {
                                                        idReserva = reserva.idReserva,
                                                        idCliente = reserva.idCliente,
                                                        idEmpleado = reserva.idEmpleado,
                                                        idServicio = reserva.idServicio,
                                                        fecha = reserva.fecha.ToString(),
                                                        hora = reserva.hora.ToString(),

                                                    }).ToList();
            return lalistadeServicios;
        }
    }
}
