using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ListarDisponibles;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ListarEncargos;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ListarDisponibles;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloReservas.ListarDisponibles;
using ProyectoLavacar.AccesoADatos.ModuloReservas.ListarEncargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloReservas.ListarDisponibles
{
    public class ListarDisponiblesLN : IListarDisponiblesLN
    {
        IListarDisponiblesAD _listarDisponiblesReservasAD;
        public ListarDisponiblesLN()
        {
            _listarDisponiblesReservasAD = new ListarDisponiblesAD();
        }

        public List<ReservasDto> Listar(int idCliente)
        {
            List<ReservasDto> laListaDeActividadesPersona = _listarDisponiblesReservasAD.ListarReservasCliente(idCliente);

            return laListaDeActividadesPersona;
        }

        private List<ReservasDto> ObtenerLaListaConvertida(List<ReservasTabla> lalistadeReservas, List<UsuariosTabla> lalistadeClientes)
        {
            List<ReservasDto> laListaDeActividades = new List<ReservasDto>();


            var joinLista = from reserva in lalistadeReservas
                            join clientes in lalistadeClientes on reserva.idCliente equals clientes.idCliente
                            where reserva.idEmpleado == clientes.idCliente
                            select new { reserva, clientes };

            foreach (var item in joinLista)
            {
                laListaDeActividades.Add(ConvertirObjetoServiciosDto(item.reserva, item.clientes));
            }

            return laListaDeActividades;
        }

        private ReservasDto ConvertirObjetoServiciosDto(ReservasTabla reserva, UsuariosTabla clientes)
        {

            return new ReservasDto
            {
                idReserva = reserva.idReserva,
                idCliente = clientes.idCliente,
                idEmpleado = reserva.idEmpleado,
                idServicio = reserva.idServicio,
                fecha = reserva.fecha.ToString(),
                hora = reserva.hora.ToString(),

            };
        }
    }
}
