using System;
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
        [Display(Name = "Razón de ajuste")]
        public string Razon { get; set; }

        public int IdNomina { get; set; }
        [Display(Name = "Categoria de Ajuste")]
        public string tipo { get; set; }
        [Display(Name = "Estado")]
        public bool estado { get; set; }

    }
}
