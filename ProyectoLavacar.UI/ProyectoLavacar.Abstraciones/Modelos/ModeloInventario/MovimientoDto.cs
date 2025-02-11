using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModeloInventario
{
    public class MovimientoDto
    {
        public int idMovimiento { get; set; }
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public string fecha { get; set; }


    }
}
