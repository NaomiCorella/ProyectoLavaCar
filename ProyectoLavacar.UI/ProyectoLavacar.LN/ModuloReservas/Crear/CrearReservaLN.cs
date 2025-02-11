using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.Crear;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloReservas.Crear;
using ProyectoLavacar.LN.General;
using ProyectoLavacar.LN.General.Fecha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloReservas.Crear
{
    public class CrearReservaLN : ICrearReservaLN
    {
        ICrearReservaAD _crearReserva;
        IFecha _fecha;

        public CrearReservaLN()
        {
            _fecha = new Fecha();
            _crearReserva = new CrearReservaAD();
        }

        public async Task<int> CrearReserva(ReservasDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _crearReserva.CrearReserva(ConvertirObjetoArchivosTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }

        public ReservasTabla ConvertirObjetoArchivosTabla(ReservasDto reserva)
        {
            return new ReservasTabla
            {
                idReserva = reserva.idReserva,
                idCliente = reserva.idCliente,
                idEmpleado = reserva.idEmpleado,
                idServicio = reserva.idServicio,
                fecha = DateTime.Parse(reserva.fecha),
                hora = TimeSpan.Parse(reserva.hora),
                estado = reserva.estado

            };
        }
    }

}
