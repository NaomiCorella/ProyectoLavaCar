using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloUsuarios;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Editar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.AccesoADatos;
using ProyectoLavacar.AccesoADatos.ModuloUsuarios.Editar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloUsuarios.Editar
{
    public class EditarUsuarioLN : IEditarUsuarioLN
    {
        IEditarUsuarioAD _editarPersonasAD;
        IConvertirUsuariosDtoAUsuariosTabla _convertirObjeto;

        public EditarUsuarioLN()
        {
            _editarPersonasAD = new EditarUsuarioAD();
            _convertirObjeto = new ConvertirUsuariosDtoAUsuariosTabla();
        }

        public async Task<int> EditarUsuarios(UsuariosDto elClieteEnVista)
        {
            int cantidadDeDatosEditados = await _editarPersonasAD.EditarUsuarios(_convertirObjeto.ConvertirCliente(elClieteEnVista));
            return cantidadDeDatosEditados;
        }
    }
}


