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
        public string descripcion { get; set; }
        [Display(Name = "Tiempo de duración")]
        public string tiempoDuracion { get; set; }
        [Display(Name = "Disponibilidad")]
        public bool estado { get; set; } = true;
        [Display(Name = "Modalidad")]
        public string modalidad { get; set; }
        [Display(Name = "Precio")]
        public decimal precio { get; set; }
    }

}

