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
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string correoElectronico { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string contraseña { get; set; }
        public bool estado { get; set; } = true;
    }
}
