using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloReservas
{
    public class ConvertirReservasDtoAReservasTabla : IConvertirReservasDtoAReservasTabla

    {
        IFecha _fecha;
        public ConvertirReservasDtoAReservasTabla()
        {
            _fecha = new ProyectoLavacar.LN.General.Fecha.Fecha();
        }
        public ReservasTabla ConvertirReservas(ReservasDto reserva)
        {
            return new ReservasTabla
            {
                idCliente = reserva.idCliente,
                idEmpleado = reserva.idEmpleado,
                idServicio = reserva.idServicio,
                fecha = _fecha.ObtenerFecha(),
                hora = _fecha.ObtenerFecha(),
            };
        }
    }

}
