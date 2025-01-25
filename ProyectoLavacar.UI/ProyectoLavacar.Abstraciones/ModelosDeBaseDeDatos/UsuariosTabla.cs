using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    [Table("Cliente")]
    public class UsuariosTabla
    {
        [Key]
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string correoElectronico { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string contraseña { get; set; }
        public bool estado { get; set; }
    }
}
