using System;
using System.Collections.Generic;
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

        public string fecha { get; set; }
        public string comentarios { get; set; }
        public bool estado { get; set; } = true;
        public int idResenia { get; set; }

    }
}
