using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas
{
    public class ReseniaConRespuesta
    {
        public int idResenia { get; set; }
        public string idCliente { get; set; }
        public string nombreCliente { get; set; }
        public string nombreEmpleado { get; set; }
        public string nombreServicio { get; set; }
        public int idServicio { get; set; }
        [Display(Name = "Fecha")]
        public string fecha { get; set; }
        [Display(Name = "Calificacion")]
        public int calificacion { get; set; }
        [Display(Name = "Comentarios")]
        public string comentarios { get; set; }
        [Display(Name = "Estado de Reseña")]
        public bool estadoResenia { get; set; } = true;
        public int? idRespuesta { get; set; }
        public string idEmpleado { get; set; }
        [Display(Name = "Fecha de Respuesta")]
        public string fechaRespuesta { get; set; }
        [Display(Name = "Respuesta De Comentarios")]
        public string comentariosRespuesta { get; set; }
       
    }
}
