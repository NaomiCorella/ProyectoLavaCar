using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloNomina
{
    public class TramitesDto
    {
        public int IdTramite { get; set; }

        public string IdEmpleado { get; set; }

        public DateTime FechaInicio { get; set; }


        public DateTime FechaFin { get; set; }

        public string Razon { get; set; }
    }
}
