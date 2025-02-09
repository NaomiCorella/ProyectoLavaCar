using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    [Table("[Movimiento]")]
    public class MovimientoTabla
    {
        [Key]
        public int idMovimiento { get; set; }
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }
    }
}
