using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloReservas
{
    public interface IConvertirReservasDtoAReservasTabla
    {
        ReservasTabla ConvertirReservas(ReservasDto reserva);
    }
}
