using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    [Table("Reservas")]
    public class ReservasTabla
    {
        [Key]
        public int idReserva { get; set; }
        public string idCliente { get; set; }
        public int idEmpleado { get; set; }
        public int idServicio { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan hora { get; set; }
        public bool estado { get; set; } 
    }
}
