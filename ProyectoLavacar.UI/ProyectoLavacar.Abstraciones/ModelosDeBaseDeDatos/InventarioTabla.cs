using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    [Table("Producto")]
    public class InventarioTabla
    {
        [Key]
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }
        public decimal precioUnitario { get; set; }
        public int cantidadDisponible { get; set; }
        public bool estado { get; set; }
    }
}
