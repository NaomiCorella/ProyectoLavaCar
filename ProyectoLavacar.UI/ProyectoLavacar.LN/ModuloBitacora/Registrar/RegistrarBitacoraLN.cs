
using ProyectoLavacar.Abstracciones.AccesoADatos.Interfaces.ModuloBitacora.Registrar;
using ProyectoLavacar.Abstracciones.LN.Interfaces.ModuloBitacora.Registrar;
using ProyectoLavacar.Abstracciones.Modelos.ModuloBitacora;
using ProyectoLavacar.Abstracciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.AccesoADatos.ModuloBitacora.Registrar;
using ProyectoLavacar.LN.General.Fecha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloBitacora.Registrar
{
    public class RegistrarBitacoraLN : IRegistrarBitacoraLN
    {
        IRegistrarBitacoraAD _registrarBitacoraAD;
        IFecha _fecha;

        public RegistrarBitacoraLN()
        {
            _fecha = new Fecha();
            _registrarBitacoraAD = new RegistrarBitacoraAD();
        }
        public async Task<int>RegistrarBitacora(BitacoraDto modelo)
        {
            int cantidadDeDAtosAlmacenados = await _registrarBitacoraAD.RegistrarBitacora(ConvertirObjetoBitacoraTabla(modelo));
            return cantidadDeDAtosAlmacenados;
        }

        public BitacoraTabla ConvertirObjetoBitacoraTabla(BitacoraDto Bitacora)
        {
            return new BitacoraTabla()
            {
                IdEvento = Bitacora.IdEvento,
                TablaDeEvento = Bitacora.TablaDeEvento,
                TipoDeEvento = Bitacora.TipoDeEvento,
                FechaDeEvento = _fecha.ObtenerFecha(),
                DescripcionDeEvento = Bitacora.DescripcionDeEvento,
                StackTrace = Bitacora.StackTrace,
                DatosAnteriores = Bitacora.DatosAnteriores,
                DatosPosteriores = Bitacora.DatosPosteriores
            };
        }
    }
}
