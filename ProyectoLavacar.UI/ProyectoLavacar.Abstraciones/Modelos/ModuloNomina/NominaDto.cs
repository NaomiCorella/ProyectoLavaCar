using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloNomina
{
    public class NominaDto
    {
        public int IdNomina { get; set; }
        public string IdEmpleado { get; set; }
        [Display(Name = "Salario Neto")]
        public decimal SalarioNeto { get; set; }
        [Display(Name = "Salario Bruto")]
        public decimal?SalarioBruto { get; set; }
        [Display(Name = "Fecha de pago")]
        public DateTime FechaDePago { get; set; }
        [Display(Name = "Período de pago")]
        public string PeriodoDePago { get; set; }
        [Display(Name = "Horas ordinarias")]
        public int? HorasOrdinarias { get; set; }
        [Display(Name = "Horas extras")]
        public int? HorasExtras { get; set; }
        [Display(Name = "Horas dobles")]
        public int? HorasDobles { get; set; }
        [Display(Name = "Días disponibles de vacaciones")]
        public int DiasDispoVacaciones { get; set; }
       
        [Display(Name = "Días utilizados de vacaciones")]
        public int DiasUtiliVacaciones { get; set; }
        public decimal? Incapacidad { get; set; }
        [Display(Name = "Tipo de contrato")]
        public string TipoDeContrato { get; set; }

        public bool Estado { get; set; }
        [Display(Name = "Total de bonificaciones")]
        public decimal totalBono { get; set; }
        [Display(Name = "Total de deducciones")]
        public decimal totalDedu { get; set; }
        [Display(Name = "Deducciones de CCSS")]
        public decimal deduccionCCSS { get; set; }
        [Display(Name = "Deducciones de ISR")]
        public decimal deduccionISR { get; set; }
        [Display(Name = "Bonos de horas extra")]
        public decimal bonoHorasExtra { get; set; }
    }
}
