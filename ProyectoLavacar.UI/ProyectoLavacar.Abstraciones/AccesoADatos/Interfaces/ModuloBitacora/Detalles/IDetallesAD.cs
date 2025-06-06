using ProyectoLavacar.Abstracciones.Modelos.ModuloBitacora;
using ProyectoLavacar.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloBitacora.Detalles
{
   public  interface IDetallesAD
    {
        BitacoraTabla Detalle (int idEvento);
    }
}
