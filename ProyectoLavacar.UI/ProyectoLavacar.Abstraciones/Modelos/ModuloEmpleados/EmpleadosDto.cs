using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados
{
    public class EmpleadosDto
    {
        public int idEmpleado { get; set; }
        [Display(Name = "Nombre")]

        public string nombre { get; set; }
        [Display(Name = "Primer apellido")]
        public string primer_apellido { get; set; }
        [Display(Name = "Segundo apellido")]
        public string segundo_apellido { get; set; }
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }
        [Display(Name = "Correo electrónico")]
        public string correo { get; set; }
        [Display(Name = "Cédula")]
        public string cedula { get; set; }
        [Display(Name = "Puesto")]
        public string puesto { get; set; }
        [Display(Name = "Turno")]
        public string turno { get; set; }
        [Display(Name = "Estado")]
        public bool estado { get; set; }
        [Display(Name = "Numero de cuenta")]
        public string numeroCuenta { get; set; }
    }
}
