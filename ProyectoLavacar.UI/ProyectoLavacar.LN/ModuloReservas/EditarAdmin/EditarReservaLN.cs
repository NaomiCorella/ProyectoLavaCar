using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloReservas;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.Editar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.AccesoADatos.ModuloReservas.Editar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloReservas.Editar
{
    public class EditarReservaLN: IEditarReservaLN
    {
        IEditarReservaAD _editarReservas;
        IConvertirReservasDtoAReservasTabla _convertirObjeto;

        public EditarReservaLN()
        {
            _editarReservas = new EditarReservaAD();
            _convertirObjeto = new ConvertirReservasDtoAReservasTabla();
        }

        public async Task<int> EditarPersonas(ReservasDto laReserva)
        {
            int cantidadDeDatosEditados = await _editarReservas.EditarReservas(_convertirObjeto.ConvertirReservas(laReserva));
            return cantidadDeDatosEditados;
        }
    }
}

