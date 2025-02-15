﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloNomina
{
    public class GeneralDto
    {
        public int IdNomina { get; set; }
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

        public string IdEmpleado { get; set; }
        public string nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string cedula { get; set; }
        public string puesto { get; set; }
        public string turno { get; set; }
        public bool estado { get; set; }
        public string numeroCuenta { get; set; }

    }
}
