﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloReservas
{
    public class ReservaCompleta
    {
        public int idReserva { get; set; }
        public string idCliente { get; set; }
        public string idEmpleado { get; set; }
        public string nombreCliente { get; set; }
        public string nombreEmpleado { get; set; }
        public string nombreServicio { get; set; }
        public int idServicio { get; set; }
        [Display(Name = "Fecha")]
        public string fecha { get; set; }
        [Display(Name = "Hora")]
        public string hora { get; set; }
        [Display(Name = "Disponibilidad")]
        public bool estado { get; set; }
    }
}
