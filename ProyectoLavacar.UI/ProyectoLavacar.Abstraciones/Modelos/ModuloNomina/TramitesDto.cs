using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloNomina
{
    public class TramitesDto
    {
        public int IdTramite { get; set; }

        public DateTime FechaInicio { get; set; }

        public int duracion { get; set; }

        [Display(Name = "Tipo")]
        public string Razon { get; set; }

        public int IdNomina { get; set; }
        [Display(Name = "Categoria de Tramite")]
        public string tipo { get; set; }
        public int estado { get; set; }
    }
}
