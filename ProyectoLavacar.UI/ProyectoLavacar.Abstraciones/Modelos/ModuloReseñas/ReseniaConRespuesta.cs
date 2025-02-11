using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas
{
    public class ReseniaConRespuesta
    {
        public int idResenia { get; set; }
        public string idCliente { get; set; }
        public int idServicio { get; set; }
        public string fecha { get; set; }
        public int calificacion { get; set; }
        public string comentarios { get; set; }
        public bool estadoResenia { get; set; } = true;
        public int? idRespuesta { get; set; }
        public string idEmpleado { get; set; }
        public string fechaRespuesta { get; set; }
        public string comentariosRespuesta { get; set; }
       
    }
}
