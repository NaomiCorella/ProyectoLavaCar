using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas
{
    public class ReseniaDto
    {
        [Display(Name = "Fecha de Evaluacion")]
        public int idResenia { get; set; }
        [Display(Name = "Fecha de Evaluacion")]
        public string idCliente { get; set; }
        [Display(Name = "Fecha de Evaluacion")]
        public int idServicio { get; set; }
        [Display(Name = "Fecha")]
        public string fecha { get; set; }
        [Display(Name = "Calificacion")]
        public int calificacion { get; set; }
        [Display(Name = "Comentarios")]
        public string comentarios { get; set; }
        [Display(Name = "Disponiblilidad")]
        public bool estado { get; set; } = true;
    }
}

