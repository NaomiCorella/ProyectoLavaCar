using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ListarEncargos;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ListarTodo;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ListarEncargo;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloReservas.ListarEncargos;
using ProyectoLavacar.AccesoADatos.ModuloReservas.ListarTodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloReservas.ListarEncargo
{
    public class ListarEncargoLN : IListarEncargoLN
    {
        IListarEncargoAD _listarEncargoReservasAD;
        public ListarEncargoLN()
        {
            _listarEncargoReservasAD = new ListarEncargoAD();
        }

        public List<ReservasDto> Listar(string idEmpleado)
        {
            List<ReservasDto> laListaDeActividadesPersona = _listarEncargoReservasAD.ListarReservasEmpleado(idEmpleado);

            return laListaDeActividadesPersona;
        }

        private List<ReservasDto> ObtenerLaListaConvertida(List<ReservasTabla> lalistadeReservas, List<UsuariosTabla> listadeEmpleados)
        {
            List<ReservasDto> laListaDeActividades = new List<ReservasDto>();


            var joinLista = from reserva in lalistadeReservas
                            join empleados in listadeEmpleados on reserva.idEmpleado equals empleados.Id
                            where reserva.idEmpleado == empleados.Id
                            select new { reserva, empleados };

            foreach (var item in joinLista)
            {
                laListaDeActividades.Add(ConvertirObjetoServiciosDto(item.reserva, item.empleados));
            }

            return laListaDeActividades;
        }

        private ReservasDto ConvertirObjetoServiciosDto(ReservasTabla reserva, UsuariosTabla empleados)
        {

            return new ReservasDto
            {
                idReserva = reserva.idReserva,
                idCliente = reserva.idCliente,
                idEmpleado = empleados.Id,
                idServicio = reserva.idServicio,
                fecha = reserva.fecha.ToString(),
                hora = reserva.hora.ToString(),
                estado = reserva.estado
            };
        }
    }
}
