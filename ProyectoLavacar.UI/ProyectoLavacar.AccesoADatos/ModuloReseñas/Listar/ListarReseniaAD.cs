using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReseñas.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloReseñas.Listar
{
    public class ListarReseniaAD : IListarReseniaAD
    {
        Contexto _elContexto;

        public ListarReseniaAD()
        {
            _elContexto = new Contexto();
        }

        public List<ReseniaConRespuesta> ListarResenias()
        {
            List<ReseniaConRespuesta> lalistadeServicios = (from laResenia in _elContexto.ReseniasTabla
                                                   join laRespuesta in _elContexto.RespuestaTabla
                                                   on laResenia.idResenia equals laRespuesta.idResenia into respuestas
                                                   from respuesta in respuestas.DefaultIfEmpty() 
                                                   select new ReseniaConRespuesta
                                                   {
                                                       idResenia = laResenia.idResenia,
                                                       idCliente = laResenia.idCliente,
                                                       idServicio = laResenia.idServicio,
                                                       fecha = laResenia.fecha.ToString(),
                                                       calificacion = laResenia.calificacion,
                                                       comentarios = laResenia.comentarios,
                                                       estadoResenia = laResenia.estado,
                                                       idRespuesta = respuesta != null ? (int?)respuesta.idRespuesta : null,
                                                       idEmpleado = respuesta != null ? respuesta.idEmpleado : null,
                                                       comentariosRespuesta = respuesta != null ? respuesta.comentarios : null,
                                                       fechaRespuesta = respuesta != null ? respuesta.fecha.ToString() : null,
                                                     
                                                 

        }).ToList();
            return lalistadeServicios;
        }
    }
}





