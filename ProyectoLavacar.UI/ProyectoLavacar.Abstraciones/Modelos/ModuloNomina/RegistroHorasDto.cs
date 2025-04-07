using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloNomina
{
    public class RegistroHorasDto
    {

      public int idRegistro { get; set; }
        [Display(Name = "Hora de entrada")]
        public string HoraEntrada { get; set; }
        [Display(Name = "Hora de salida")]
        public string HoraSalida { get; set; }
        public string idEmpleado { get; set; }
        [Display(Name = "Estado")]
        public bool estado { get; set; }
         [Display(Name = "Total de horas")]
        public int totalHoras { get; set; }
    }
}
