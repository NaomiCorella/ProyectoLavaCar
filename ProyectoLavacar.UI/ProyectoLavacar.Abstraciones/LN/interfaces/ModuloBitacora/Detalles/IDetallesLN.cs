using ProyectoLavacar.Abstracciones.Modelos.ModuloBitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloBitacora.Detalles
{
   public  interface IDetallesLN
    {
        BitacoraDto Detalle(int idEvento);
    }
}
