using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.General.Fecha
{
    public class Fecha : IFecha
    {
        public DateTime ObtenerFecha()
        {
            return DateTime.Now;
        }


    }
}
