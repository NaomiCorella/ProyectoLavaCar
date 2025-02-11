using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas
{
    public class ReseniaDto
    {
        public int idResenia { get; set; }
        public string idCliente { get; set; }
        public int idServicio { get; set; }
        public string fecha { get; set; }
        public int calificacion { get; set; }
        public string comentarios { get; set; }
        public bool estado { get; set; } = true;
 
    }
}
