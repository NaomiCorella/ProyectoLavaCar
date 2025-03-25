using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    public class NominaTabla
    {
       
       [Key]
        public int IdNomina { get; set; }
        public string IdEmpleado { get; set; }
        public decimal SalarioNeto { get; set; }
        public decimal? SalarioBruto { get; set; } 
        public DateTime FechaDePago { get; set; }
        public string PeriodoDePago { get; set; }
        public int? HorasOrdinarias { get; set; } 
        public int? HorasExtras { get; set; } 
        public int? HorasDobles { get; set; }
        public int DiasDispoVacaciones { get; set; }
        public int DiasUtiliVacaciones { get; set; }
        public decimal? Incapacidad { get; set; } 
        public string TipoDeContrato { get; set; }
        public bool Estado { get; set; }
        public decimal totalBono { get; set; }
        public decimal totalDedu { get; set; }
        public decimal deduccionCCSS { get; set; }
        public decimal deduccionISR { get; set; }
        public decimal bonoHorasExtra { get; set; }
   
    }
}
