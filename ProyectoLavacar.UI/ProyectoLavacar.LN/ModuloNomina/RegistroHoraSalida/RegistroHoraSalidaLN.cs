using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.Editar;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.IngresarHoras;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.RegistroHoraSalida;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.RegistroHoraSalida;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloNomina.EditarNomina;
using ProyectoLavacar.AccesoADatos.ModuloNomina.RegistrarHoraSalida;
using ProyectoLavacar.LN.General.Conversiones.ModuloNomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.RegistroHoraSalida
{
    public class RegistroHoraSalidaLN : IRegistroHoraSalidaLN
    {
        IRegistroHoraSalidaAD _Registrar;
        IConvertirRegistroHorasDtoARegistroHorasTabla _convertirObjeto;

        public RegistroHoraSalidaLN()
        {
            _Registrar = new RegistrarHoraSalidaAD();
            _convertirObjeto = new ConvertirRegistroHorasDtoARegistroHorasTabla();
        }

        public async Task<int> RegistroHoraSalida(RegistroHorasDto hora)
        {
            int cantidadDeDatosEditados = await _Registrar.RegistroHoraSalida(_convertirObjeto.Convertir(hora));
            return cantidadDeDatosEditados;
        }
    }
}
