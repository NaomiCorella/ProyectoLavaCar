using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModeloInventario
{
    public class MovimientoDto
    {
        public int idMovimiento { get; set; }
        public int idProducto { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }
        [Display(Name = "Fecha")]
        public string fecha { get; set; }


    }
}
