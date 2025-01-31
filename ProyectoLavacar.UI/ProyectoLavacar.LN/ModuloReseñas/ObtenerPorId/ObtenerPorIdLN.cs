using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReseñas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloReseñas.ObtenerPorId;
using ProyectoLavacar.AccesoADatos.ModuloReservas.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloReseñas.ObtenerPorId
{
    public class ObtenerPorIdLN: IObtenerPorIdLN
    {
        IObtenerPorIdAD _obtenerPorIdReservaAD;
        public ObtenerPorIdLN()
        {
            _obtenerPorIdReservaAD = new ObtenerPorIdAD();
        }
        public ReseniaDto Detalle(int idReserva)
        {
            ReseniasTabla reservaEnBaseDeDatos = _obtenerPorIdReservaAD.Detalle(idReserva);
            ReseniaDto laReservaAMostrar = ConvertirAReservaAMostrar(reservaEnBaseDeDatos);
            return laReservaAMostrar;
        }
        private ReseniaDto ConvertirAReservaAMostrar(ReseniasTabla laResenia)
        {

            return new ReseniaDto
            {
                idResenia = laResenia.idResenia,
                idCliente = laResenia.idCliente,
                idServicio = laResenia.idServicio,
                fecha = laResenia.fecha.ToString(),
                calificacion = laResenia.calificacion,
                comentarios = laResenia.comentarios,
                estado = laResenia.estado
            };
        }
    }
}
