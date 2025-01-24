using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.Crear
{
    public interface ICrearReservaLN
    {
        Task<int> CrearReserva(ReservasDto modelo);
    }
}
