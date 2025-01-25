using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Editar
{
    public interface IEditarUsuarioLN
    {
        Task<int> EditarUsuarios(UsuariosDto elClieteEnVista);

    }
}
