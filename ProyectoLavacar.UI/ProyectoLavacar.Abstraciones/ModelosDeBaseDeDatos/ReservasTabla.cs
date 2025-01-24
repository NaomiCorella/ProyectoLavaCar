﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    [Table("Reservas")]
    public class ReservasTabla
    {
        public int idReserva { get; set; }
        public int idCliente { get; set; }
        public int idEmpleado { get; set; }
        public int idServicio { get; set; }
        public DateTime fecha { get; set; }
        public DateTime hora { get; set; }
        public bool estado { get; set; } = true;
    }
}
