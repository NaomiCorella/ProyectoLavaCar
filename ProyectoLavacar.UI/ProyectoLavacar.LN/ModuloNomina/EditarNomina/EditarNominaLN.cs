
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.AccesoADatos.ModuloNomina.EditarNomina;
using ProyectoLavacar.LN.General.Conversiones.ModuloNomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.EditarNomina
{
    public class EditarNominaLN : IEditarNominaLN
    {
        IEditarNominaAD _editarNominasAD;
        IConvertirNominaDtoANominaTabla _convertirObjeto;

        public EditarNominaLN()
        {
            _editarNominasAD = new EditarNominaAD();
            _convertirObjeto = new ConvertirNominaDtoANominaTabla();
        }

        public async Task<int> EditarNomina(NominaDto laNomina)
        {
            int cantidadDeDatosEditados = await _editarNominasAD.EditarNomina(_convertirObjeto.ConvertirNomina(laNomina));
            return cantidadDeDatosEditados;
        }

    }
}



