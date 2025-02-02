using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModeloInventario
{
    public class InventarioDto
    {
        public int idInventario { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }
        public decimal precioUnitario { get; set; }
        public int cantidadDisponible { get; set; }
        public bool estado { get; set; }

    }
}
