
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Editar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.AccesoADatos.ModuloUsuarios.Editar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloEmpleados.Editar
{
    public class EditarEmpleadoLN : IEditarEmpleadoLN
    {
        IEditarEmpleadoAD _editarEmpleadosAD;
        IConvertirEmpleadosDtoAEmpleadosTabla _convertirObjeto;

        public EditarUsuarioLN()
        {
            _editarEmpleadosAD = new EditarEmpleadosAD();
            _convertirObjeto = new ConvertirEmpleadosDtoAEmpleadosTabla();
        }

        public async Task<int> EditarEmpleados(EmpleadosDto elEmpleadoEnVista)
        {
            int cantidadDeDatosEditados = await _editarEmpleadosAD.EditarEmpleados(_convertirObjeto.ConvertirEmpleados(elEmpleadoEnVista));
            return cantidadDeDatosEditados;
        }
    }
}


