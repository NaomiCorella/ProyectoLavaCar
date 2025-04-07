using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProyectoLavacar.Abstraciones.Modelos.ModeloInventario
{
    public class InventarioDto
    {
        public int idProducto { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Categoria")]
        public string categoria { get; set; }
        [Display(Name = "Precio Unitario")]
        public decimal precioUnitario { get; set; }
        [Display(Name = "Cantidad Disponible")]
        public int cantidadDisponible { get; set; }
        [Display(Name = "Estado")]
        public bool estado { get; set; }

    }
}