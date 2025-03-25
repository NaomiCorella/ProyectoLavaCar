using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloCompra
{
    public class CompraCompletaDto
    {
        public Guid idCompra { get; set; }
        public string idCliente { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [Display(Name = "Cédula")]
        public int Cedula { get; set; }
      
        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Display(Name = "Fecha")]
        public string Fecha { get; set; }
        [Display(Name = "Descripción")]
        public string DescripcionServicio { get; set; }

        public string idEmpleado { get; set; }

        [Display(Name = "Nombre")]
        public string NombreEmp { get; set; }

        [Display(Name = "Primer Apellido")]
        public string PrimerApellidoEmp { get; set; }
        [Display(Name = "Segundo Apellido")]

        public List<ServiciosDto> listaDeServicios { get; set; } = new List<ServiciosDto>(); // Inicialización de la lista


    }

}