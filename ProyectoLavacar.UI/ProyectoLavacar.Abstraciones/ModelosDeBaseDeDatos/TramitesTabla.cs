using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    public class TramitesTabla
    {
        [Key]
        public int IdTramite { get; set; }

        public string IdEmpleado { get; set; }

        public DateTime FechaInicio { get; set; }


        public DateTime FechaFin { get; set; }

        public string Razon { get; set; }
    }
}
