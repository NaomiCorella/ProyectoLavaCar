using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModulaInventario;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.Editar;
using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.AccesoADatos.ModuloInventario.Editar;
using ProyectoLavacar.LN.General.Conversiones.ModuloInventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloInventario.Editar
{
    public class EditarInventarioLN : IEditarInventarioLN
    {
        IEditarInventarioAD _editarInventarioAD;
        IConvertirInventarioDtoAInventarioTabla _convertirObjeto;

        public EditarInventarioLN()
        {
            _editarInventarioAD = new EditarInventarioAD();
            _convertirObjeto = new ConvertirInventarioDtoAInventarioTabla();
        }

        public async Task<int> EditarInventario(InventarioDto elInventarioEnVista)
        {
            int cantidadDeDatosEditados = await _editarInventarioAD.EditarInventario(_convertirObjeto.ConvertirInventario(elInventarioEnVista));
            return cantidadDeDatosEditados;
        }


    }
}
