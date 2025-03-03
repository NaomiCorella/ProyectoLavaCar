using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarAjustes
{
    public interface IEditarAjusteLN
    {
        Task<int> Editar(AjustesSalarialesDto tramites);
    }
}
