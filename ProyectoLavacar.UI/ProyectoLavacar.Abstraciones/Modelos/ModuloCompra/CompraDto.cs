using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloCompra
{
    
        public class CompraDto
        {
            public int idCompra { get; set; }
            public string idCliente { get; set; }
            public int idServicio { get; set; }
            public decimal Total { get; set; }
            public string fecha { get; set; }
            public string DescripcionServicio { get; set; }
            public bool Estado { get; set; }
        } 
    }

