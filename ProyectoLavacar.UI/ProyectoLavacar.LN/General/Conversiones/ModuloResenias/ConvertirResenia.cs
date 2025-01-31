using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloReseñas;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.General.Conversiones.ModuloResenias
{
    public class ConvertirResenia : IConvertirResenia
    {
        IFecha _fecha;
        public ConvertirResenia()
        {
            _fecha = new ProyectoLavacar.LN.General.Fecha.Fecha();
        }
        public ReseniasTabla ConvertirReservas(ReseniaDto laResenia)
        {
            return new ReseniasTabla
            {
                idResenia = laResenia.idResenia,
                idCliente = laResenia.idCliente,
                idServicio = laResenia.idServicio,
                fecha = _fecha.ObtenerFecha(),
                calificacion = laResenia.calificacion,
                comentarios = laResenia.comentarios,
                estado = laResenia.estado
            };
        }
    }
}
