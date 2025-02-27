using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.General.Conversiones.ModuloNomina
{
   public  class ConvertirRegistroHorasDtoARegistroHorasTabla :IConvertirRegistroHorasDtoARegistroHorasTabla
    {
        IFecha _fecha;
        public ConvertirRegistroHorasDtoARegistroHorasTabla()
        {
            _fecha = new ProyectoLavacar.LN.General.Fecha.Fecha();
        }

        public RegistroHorasTabla Convertir(RegistroHorasDto hora)
        {
            return new RegistroHorasTabla
            {
                idRegistro = hora.idRegistro,
                estado = hora.estado,
                HoraSalida= _fecha.ObtenerFecha(),
            };
        }
    }
}
