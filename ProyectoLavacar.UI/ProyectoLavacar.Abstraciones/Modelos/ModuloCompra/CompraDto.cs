using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloCompra
{
    
        public class CompraDto
        {
         public Guid idCompra { get; set; }
        public string idCliente { get; set; }
        public List<int> listaServicios { get; set; } = new List<int>();

        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Display(Name = "Fecha")]
        public string fecha { get; set; }

        [Display(Name = "Descripción")]
        public string DescripcionServicio { get; set; }
        public bool Estado { get; set; }
        } 
    }

