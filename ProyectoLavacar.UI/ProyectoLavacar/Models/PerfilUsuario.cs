using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProyectoLavacar.Models
{
    public class PerfilUsuario
    {
        public string id { get; set; }
        public string nombre { get; set; }
        [Display(Name = "Primer Apellido")]
        public string primer_apellido { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string segundo_apellido { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Numero de Telefono")]
        public string PhoneNumber { get; set; }
        public List<ReservaCompleta> reservas { get; set; }

    }
}