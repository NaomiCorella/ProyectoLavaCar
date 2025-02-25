using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    [Table("RebajosEspecificos")]
    public class RebajosTabla
    {
        [Key]
        public int idRebajo { get; set; }

        public decimal Monto { get; set; }

        public string Razon { get; set; }
        public string tipo { get; set; }

        public int IdNomina { get; set; }
    }
}
