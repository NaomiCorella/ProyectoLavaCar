﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloNomina
{
    public class RebajosDto
    {
        public int idRebajo { get; set; }

        public decimal Monto { get; set; }

        public string Razon { get; set; }
        public string tipo { get; set; }

        public int IdNomina { get; set; }
     
    }
}
