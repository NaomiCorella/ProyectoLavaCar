using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados
{
    public class EmpleadosDto
    {
        public int idEmpleado { get; set; }
        public int nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string cedula { get; set; }
        public string puesto { get; set; }
        public string turno { get; set; }
        public bool estado { get; set; }
        public string numeroCuenta { get; set; }
    }
}
