using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloReservas
{
    public class ReservasDto
    {
        public int idReserva { get; set; }
        public int idCliente { get; set; }
        public int idEmpleado { get; set; }
        public int idServicio { get; set; }
        public string fecha { get; set; }

        public string hora { get; set; }
        public bool estado { get; set; } = true;

    }
}
