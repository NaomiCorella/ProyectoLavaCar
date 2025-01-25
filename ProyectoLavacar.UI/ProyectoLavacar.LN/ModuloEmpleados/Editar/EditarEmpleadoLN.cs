
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEmpleados.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Editar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.AccesoADatos.ModuloEmpleados.Editar;
using ProyectoLavacar.AccesoADatos.ModuloUsuarios.Editar;
using ProyectoLavacar.LN.General.Conversiones.ModuloEmpleados;
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

        public EditarEmpleadoLN()
        {
            _editarEmpleadosAD = new EditarEmpleadoAD();
            _convertirObjeto = new ConvertirEmpleadosDtoAEmpleadosTabla();
        }

        public async Task<int> EditarEmpleados(EmpleadosDto elEmpleadoEnVista)
        {
            int cantidadDeDatosEditados = await _editarEmpleadosAD.EditarEmpleado(_convertirObjeto.ConvertirEmpleados(elEmpleadoEnVista));
            return cantidadDeDatosEditados;
        }
    }
}


