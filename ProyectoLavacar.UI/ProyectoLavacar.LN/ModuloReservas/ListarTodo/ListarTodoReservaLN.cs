using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ListarTodo;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloServicios.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ListarTodo;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloReservas.ListarTodo;
using ProyectoLavacar.AccesoADatos.ModuloServicios.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloReservas.ListarTodo
{
    public class ListarTodoReservaLN : IListarTodoReservaLN
    {
        IListarTodoReservaAD _listarTodoReservasAD;
        public ListarTodoReservaLN()
        {
            _listarTodoReservasAD = new ListarTodoReservaAD();
        }

        public List<ReservasDto> ListarReservasTodo()
        {
            List<ReservasDto> laListadeServicios = _listarTodoReservasAD.ListarReservasTodo();

            return laListadeServicios;
        }

        private List<ReservasDto> ObtenerLaListaConvertida(List<ReservasTabla> laListasDeServicios)
        {//chequear
            List<ReservasDto> lalistaServicios = new List<ReservasDto>();
            foreach (ReservasTabla elServicio in laListasDeServicios)
            {
                lalistaServicios.Add(ConvertirObjetoServiciosDto(elServicio));
            }
            return lalistaServicios;
        }
        private ReservasDto ConvertirObjetoServiciosDto(ReservasTabla reserva)
        {

            return new ReservasDto
            {
                idReserva = reserva.idReserva,
                idCliente = reserva.idCliente,
                idEmpleado = reserva.idEmpleado,
                idServicio = reserva.idServicio,
                fecha = reserva.fecha.ToString(),
                hora = reserva.hora.ToString(),

            };
        }
    
}
}
