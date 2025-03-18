using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios
{
    public class UsuariosDto
    {
        public string Id { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Primer Apellido")]
        public string primer_apellido { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string segundo_apellido { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Numero de Telefono")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Disponibilidad")]
        public bool estado { get; set; } = true;
        [Display(Name = "Cedula")]
        public int cedula { get; set; }
        [Display(Name = "Numero de Cuenta")]
        public string numeroCuenta { get; set; }
        [Display(Name = "Turno")]
        public string turno { get; set; }
        [Display(Name = "Puesto")]
        public string puesto { get; set; }
        public string PasswordHash { get; set; }
        public bool nomina { get; set; }

    }
}