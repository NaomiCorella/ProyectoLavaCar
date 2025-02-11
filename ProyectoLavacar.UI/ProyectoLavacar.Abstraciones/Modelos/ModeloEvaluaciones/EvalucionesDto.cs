using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModeloEvaluaciones
{
    public class EvalucionesDto
    {
        public int idEvaluacion { get; set; }
        public string idEmpleado { get; set; }
        [Display(Name = "Fecha de Evaluacion")]
        public string fechaEvaluacion { get; set; }
        [Display(Name = "Calificaciones")]
        public int calificacion { get; set; }
        [Display(Name = "Comentarios")]
        public string comentarios { get; set; }
        [Display(Name = "Area de Mejora")]
        public string areaMejora { get; set; }
        [Display(Name = "Recomendaciones")]
        public string recomendaciones { get; set; }
    }
}