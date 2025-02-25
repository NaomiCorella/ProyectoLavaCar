using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.EditarAjuste;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.EditarTramite;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarTramites;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.AccesoADatos.ModuloNomina.EditarAjustes;
using ProyectoLavacar.AccesoADatos.ModuloNomina.EditarTramite;
using ProyectoLavacar.LN.General.Conversiones.ModuloNomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.EditarTramites
{
    public class EditarTramitesLN :IEditarTramitesLN
    {
        IEditarTramiteAD _editarTramitesAD;
        IConvertirTramitesDtoATramitesTabla _convertirObjeto;

        public EditarTramitesLN()
        {
            _editarTramitesAD = new EditarTramiteAD();
            _convertirObjeto = new ConvertirTramitesDtoATramitesTabla();
        }

        public async Task<int> Editar(TramitesDto ajustes)
        {
            int cantidadDeDatosEditados = await _editarTramitesAD.Editar(_convertirObjeto.ConvertirTramites(ajustes));
            return cantidadDeDatosEditados;
        }
    }
}
