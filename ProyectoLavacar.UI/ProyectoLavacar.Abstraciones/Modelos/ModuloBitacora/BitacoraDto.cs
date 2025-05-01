using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstracciones.Modelos.ModuloBitacora
{
    public class BitacoraDto
    {
        public int IdEvento { get; set; }
        [Display(Name = "Tabla")]
        public string TablaDeEvento { get; set; }
        [Display(Name = "Tipo")]

        public string TipoDeEvento { get; set; }
        [Display(Name = "Fecha ")]

        public string FechaDeEvento { get; set; }
        [Display(Name = "Descripción")]

        public string DescripcionDeEvento { get; set; }

        public string StackTrace { get; set; }
        [Display(Name = "Datos Anteriores")]

        public string DatosAnteriores { get; set; }
        [Display(Name = "Datos Posteriores")]

        public string DatosPosteriores { get; set; }
    }
}
