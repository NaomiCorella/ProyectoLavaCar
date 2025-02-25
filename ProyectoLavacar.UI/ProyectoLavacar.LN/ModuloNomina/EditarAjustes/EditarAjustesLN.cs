using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.Editar;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.EditarAjuste;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarAjustes;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.AccesoADatos.ModuloNomina.EditarAjustes;
using ProyectoLavacar.AccesoADatos.ModuloNomina.EditarNomina;
using ProyectoLavacar.LN.General.Conversiones.ModuloNomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.EditarAjustes
{
    public class EditarAjustesLN : IEditarAjusteLN
    {
        IEditarAjusteAD _editarAjustesAD;
        IConvertirAjustesSalarialesDtoAAjustesSalarialesTabla _convertirObjeto;

        public EditarAjustesLN()
        {
            _editarAjustesAD = new EditarAjustesAD();
            _convertirObjeto = new ConvertirAjustesSalarialesDtoAAjustesSalarialesTabla();
        }

        public async Task<int> Editar(AjustesSalarialesDto ajustes)
        {
            int cantidadDeDatosEditados = await _editarAjustesAD.Editar(_convertirObjeto.ConvertirAjustesSalariales(ajustes));
            return cantidadDeDatosEditados;
        }
    }
}
