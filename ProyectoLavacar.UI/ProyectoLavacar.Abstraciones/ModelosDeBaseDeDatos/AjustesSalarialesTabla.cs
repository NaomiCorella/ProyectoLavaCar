using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    public class AjustesSalarialesTabla
    {
        [Key]
       
        public int IdAjusteSalarial { get; set; }

        public decimal Monto { get; set; }

        public string Razon { get; set; }

        public int IdNomina { get; set; }
        public string tipo { get; set; }

       

    }
}
