using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    [Table("[AspNetUsers]")]
    public class UsuariosTabla
    {
        [Key]
        public string Id { get; set; }
        public string nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    
        public bool estado { get; set; }
        public int cedula { get; set; }
        public string numeroCuenta { get; set; }
        public string turno { get; set; }
        public string puesto { get; set; }
        public string PasswordHash { get; set; }
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpira { get; set; }
    }
}
