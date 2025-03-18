using System;
using System.Collections.Generic;
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
        public int idServicio { get; set; }

        [Display(Name = "Servicio")]
        public string nombre { get; set; }

        [Display(Name = "Costo")]
        public decimal costo { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Display(Name = "Fecha")]
        public string Fecha { get; set; }
        [Display(Name = "Descripción")]
        public string DescripcionServicio { get; set; }
        public bool Estado { get; set; }
    }

}