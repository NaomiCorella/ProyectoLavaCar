using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios
{
    public class UsuariosDto
    {
        public string Id { get; set; }
        public string nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string Email { get; set; }
   
        public string PhoneNumber { get; set; }
    
        public bool estado { get; set; } = true;
        public int cedula { get; set; }
        public string numeroCuenta { get; set; }
        public string turno { get; set; }
        public string puesto { get; set; }
    }
}
