using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstracciones.Modelos.ModuloBitacora
{
    public class BitacoraDto
    {
        public int IdEvento { get; set; }
        public string TablaDeEvento { get; set; }
        public string TipoDeEvento { get; set; }
        public string FechaDeEvento { get; set; }
        public string DescripcionDeEvento { get; set; }
        public string StackTrace { get; set; }
        public string DatosAnteriores { get; set; }
        public string DatosPosteriores { get; set; }
    }
}
