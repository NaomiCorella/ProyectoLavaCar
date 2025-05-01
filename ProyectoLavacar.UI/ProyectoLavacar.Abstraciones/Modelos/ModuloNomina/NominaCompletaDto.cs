using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloNomina
{
    public class NominaCompletaDto
    {
        public int IdNomina { get; set; }
        [Display(Name = "Salario Neto")]
        public decimal SalarioNeto { get; set; }
        [Display(Name = "Salario bruto")]
        public decimal? SalarioBruto { get; set; }
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


        public int? IdAjusteSalarial { get; set; }
        public decimal? Monto { get; set; }
        [Display(Name = "Razón de ajuste")]
        public string RazonAjuste { get; set; }


        public int? IdTramite { get; set; }
        [Display(Name = "Fecha de inicio")]
        public string FechaInicio { get; set; }
        [Display(Name = "Duración")]
        public int? duracion { get; set; }
        [Display(Name = "Razón de trámite")]
        public string RazonTramite { get; set; }

        public string IdEmpleado { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Primer apellido")]
        public string primer_apellido { get; set; }
        [Display(Name = "Segundo apellido")]
        public string segundo_apellido { get; set; }
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }
        [Display(Name = "Correo electrónico")]
        public string correo { get; set; }
        [Display(Name = "Cédula")]
        public int cedula { get; set; }
        [Display(Name = "Puesto")]
        public string puesto { get; set; }
        [Display(Name = "Turno")]
        public string turno { get; set; }
        [Display(Name = "Estado")]
        public bool estado { get; set; }
        [Display(Name = "Número de cuenta")]
        public string numeroCuenta { get; set; }
        [Display(Name = "Total de bonificaciones")]
        public decimal totalBono { get; set; }
        [Display(Name = "Total de deducciones")]
        public decimal totalDedu { get; set; }
    }
}
