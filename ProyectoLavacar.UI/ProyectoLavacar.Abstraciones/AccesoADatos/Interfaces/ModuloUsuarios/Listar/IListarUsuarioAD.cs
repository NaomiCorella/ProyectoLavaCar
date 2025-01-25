using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.Listar
{
    public interface IListarUsuarioAD
    {
        List<UsuariosDto> ListarUsuarios();

    }
}
