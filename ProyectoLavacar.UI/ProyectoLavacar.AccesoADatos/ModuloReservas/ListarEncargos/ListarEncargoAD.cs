using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ListarEncargos;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloReservas.ListarEncargos
{
    public class ListarEncargoAD : IListarEncargoAD
    {
        Contexto _elContexto;

        public ListarEncargoAD()
        {
            _elContexto = new Contexto();
        }

        public List<ReservasDto> ListarReservasEmpleado(int idEmpleado)
        {
            List<ReservasDto> lalistadeServicios = (from reserva in _elContexto.ReservasTabla join empleados in _elContexto.EmpleadosTabla   on reserva.idEmpleado equals empleados.idEmpleado where reserva.idEmpleado == idEmpleado
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
