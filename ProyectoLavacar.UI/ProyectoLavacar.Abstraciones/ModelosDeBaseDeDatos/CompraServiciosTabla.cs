using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    [Table("CompraServicios")]
    public class CompraServiciosTabla
    {
        [Key]
        public int idCompraServicios { get; set; }
        public int idCompra { get; set; }
        public int idServicio { get; set; }
    }
}
