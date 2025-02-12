using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas
{
    public class RespuestaDto
    {
        public int idRespuesta { get; set; }
        public string idEmpleado { get; set; }
        [Display(Name = "Fecha")]
        public string fecha { get; set; }
        [Display(Name = "Comentarios")]
        public string comentarios { get; set; }
        [Display(Name = "Estado")]
        public bool estado { get; set; } = true;
        public int idResenia { get; set; }

    }
}
