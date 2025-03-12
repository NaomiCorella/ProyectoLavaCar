using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.Editar;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.Remover;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloUsuarios;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Remover;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.AccesoADatos.ModuloUsuarios.Editar;
using ProyectoLavacar.AccesoADatos.ModuloUsuarios.Remover;
using ProyectoLavacar.LN.General.Conversiones.ModuloUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloUsuarios.Remover
{
    public class RemoverLN :IRemoverLN
    {
        IRemoverAD _editarPersonasAD;
        IConvertir _convertirObjeto;

        public RemoverLN()
        {
            _editarPersonasAD = new RemoverAD();
            _convertirObjeto = new convertir();
        }

        public async Task<int> EditarUsuarios(UsuariosDto elClieteEnVista)
        {
            int cantidadDeDatosEditados = await _editarPersonasAD.EditarUsuarios(_convertirObjeto.ConvertirCliente(elClieteEnVista));
            return cantidadDeDatosEditados;
        }
    }
}
