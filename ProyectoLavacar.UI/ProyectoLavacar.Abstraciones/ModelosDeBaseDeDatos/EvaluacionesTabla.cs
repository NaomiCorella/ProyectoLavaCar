using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    [Table("Evaluaciones")]
    public class EvaluacionesTabla
    {

        [Key]
        public int idEvaluacion { get; set; }
        public string idEmpleado { get; set; }
        public DateTime fechaEvaluacion { get; set; }
        public int calificacion { get; set; }
        public string comentarios { get; set; }
        public string areaMejora { get; set; }
        public string recomendaciones { get; set; }
}
}
