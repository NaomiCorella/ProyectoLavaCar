using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Remover
{
    public interface IRemoverLN
    {
        Task<int> EditarUsuarios(EmpleadoDto elClieteEnVista);
    }
}
