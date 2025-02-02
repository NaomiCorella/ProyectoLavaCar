using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModeloEvaluaciones
{
    public class EvalucionesDto
    {
        public int idEvaluacion { get; set; }
        public string idEmpleado { get; set; }
        public string fechaEvaluacion { get; set; }
        public int calificacion { get; set; }
        public string comentarios { get; set; }
        public string areaMejora { get; set; }
        public string recomendaciones { get; set; }
    }
}

