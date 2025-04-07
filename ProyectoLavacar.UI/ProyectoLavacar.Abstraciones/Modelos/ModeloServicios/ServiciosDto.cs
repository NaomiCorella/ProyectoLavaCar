using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModeloServicios
{
    public class ServiciosDto
    {
        public int idServicio { get; set; }
        [Display(Name = "Costo")]
        public decimal costo { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "La propiedad descripción es requerida ")]
        [StringLength(200, ErrorMessage = "La propiedad del descripción debe de ser mayor a 4 caracteres y menor a 200.", MinimumLength = 4)]
        public string descripcion { get; set; }
        [Display(Name = "Tiempo de duración")]
        public string tiempoDuracion { get; set; }
        [Display(Name = "Estado")]
        public bool estado { get; set; } 
        [Display(Name = "Modalidad")]
        public string modalidad { get; set; }
        [Display(Name = "Precio")]
        public decimal precio { get; set; }
    }

}

