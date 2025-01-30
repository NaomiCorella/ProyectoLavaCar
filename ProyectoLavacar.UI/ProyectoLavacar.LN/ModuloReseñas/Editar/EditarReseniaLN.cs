using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReseñas.Editar;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloReseñas;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloReservas;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.Editar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.AccesoADatos.ModuloReseñas.Editar;
using ProyectoLavacar.AccesoADatos.ModuloReservas.Editar;
using ProyectoLavacar.LN.General.Conversiones.ModuloResenias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloReseñas.Editar
{
    public class EditarReseniaLN : IEditarReseniaLN
    {

        IEditarReseniaAD _editarReservas;
        IConvertirResenia _convertirObjeto;

        public EditarReseniaLN()
        {
            _editarReservas = new EditarReseniaAD();
            _convertirObjeto = new ConvertirResenia();
        }

        public async Task<int> EditarPersonas(ReseniaDto laReserva)
        {
            int cantidadDeDatosEditados = await _editarReservas.EditarResenia(_convertirObjeto.ConvertirReservas(laReserva));
            return cantidadDeDatosEditados;
        }
    }
}
}
