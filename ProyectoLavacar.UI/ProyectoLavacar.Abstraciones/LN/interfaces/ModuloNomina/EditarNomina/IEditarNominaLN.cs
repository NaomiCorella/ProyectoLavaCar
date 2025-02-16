using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarNomina
{
    public interface IEditarNominaLN
    {
        Task<int> EditarNomina(NominaDto laNomina);
    }
}
