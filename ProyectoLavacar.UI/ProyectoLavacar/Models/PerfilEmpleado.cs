using ProyectoLavacar.Abstraciones.Modelos.ModeloEvaluaciones;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoLavacar.Models
{
	public class PerfilEmpleado
	{
    
        public string id { get; set; }
        public string nombre { get; set; }

        public string primer_apellido { get; set; }
 
        public string segundo_apellido { get; set; }

        public string Email { get; set; }

 
        public string PhoneNumber { get; set; }
  
        public string turno { get; set; }

        public string puesto { get; set; }

        public List<ReservaCompleta> reservas { get; set; }
        public List<UnicoEmpleadoDto> nomina { get; set; }
        public List<EvaluacionesDto> evaluaciones { get; set; }
    }
}