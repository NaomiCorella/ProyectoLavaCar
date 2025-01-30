using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    [Table("Resenias")]
    public class ReseniasTabla
    {
        [Key]
        public int idResenia { get; set; }
        public string idCliente { get; set; }
        public int idServicio { get; set; }
        public DateTime fecha { get; set; }
        public int calificacion { get; set; }
        public string comentarios { get; set; }
        public bool estado { get; set; } = true;
    }
}
