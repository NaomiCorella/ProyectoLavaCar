using ProyectoLavacar.Abstracciones.LN.Interfaces.ModuloBitacora.Registrar;
using ProyectoLavacar.Abstracciones.Modelos.ModuloBitacora;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloReservas;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.Editar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.AccesoADatos.ModuloReservas.Editar;
using ProyectoLavacar.LN.ModuloBitacora.Registrar;
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
        IRegistrarBitacoraLN _registrarBitacoraLN;

        public EditarReservaLN()
        {
            _editarReservas = new EditarReservaAD();
            _convertirObjeto = new ConvertirReservasDtoAReservasTabla();
            _registrarBitacoraLN = new RegistrarBitacoraLN();
        }

        public async Task<int> EditarPersonas(ReservasDto laReserva, string datos)
        {
            int cantidadDeDatosEditados = await _editarReservas.EditarReservas(_convertirObjeto.ConvertirReservas(laReserva));
            int cantidadDeDatosRegistrados = await RegistroNominaBitacora(laReserva, datos);
            return cantidadDeDatosEditados;
        }

        private async Task<int> RegistroNominaBitacora(ReservasDto reserva,string datos)
        {

            string datosPosteriores = $@"
{{
    ""IdReserva"": ""{reserva.idReserva}"",
    ""IdCliente"": ""{reserva.idCliente}"",
    ""IdEmpleado"": ""{reserva.idEmpleado}"",
    ""IdServicio"": ""{reserva.idServicio}"",
    ""Fecha"": ""{reserva.fecha}"",
    ""Hora"": ""{reserva.hora}"",
    ""Estado"": ""{reserva.estado}""
}}";

            var bitacora = new BitacoraDto
            {
                IdEvento = 0,
                TablaDeEvento = "Reservas",
                TipoDeEvento = "Editar de Reservas",
                FechaDeEvento = "19-11-2024",
                DescripcionDeEvento = "Se hizo un edit en la tabla Reservas",
                StackTrace = "no hubo error",
                DatosAnteriores = datos,
                DatosPosteriores = datosPosteriores
            };

            int cantidad = await _registrarBitacoraLN.RegistrarBitacora(bitacora);


            return cantidad;
        }
    }
}

