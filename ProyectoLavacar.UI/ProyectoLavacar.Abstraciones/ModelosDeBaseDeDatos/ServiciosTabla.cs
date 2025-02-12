using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    [Table("Servicios")]
    public class ServiciosTabla
    {
        [Key]
        public int idServicio { get; set; }
        public decimal costo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string tiempoDuracion { get; set; }
        public bool estado { get; set; } = true;
        public string modalidad { get; set; }

    }
}
