using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloCompra
{
   public class CompraServiciosDto
    {
        public int idCompraServicios { get; set; }
        public Guid idCompra { get; set; }
 
        public int idServicio{ get; set; }
    }
}
