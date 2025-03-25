﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloNomina
{
    public class AjustesSalarialesDto
    {
        public int IdAjusteSalarial { get; set; }

        public decimal Monto { get; set; }

        public string Razon { get; set; }

        public int IdNomina { get; set; }
        [Display(Name = "Categoria de Ajuste")]
        public string tipo { get; set; }
        public bool estado { get; set; }

    }
}
