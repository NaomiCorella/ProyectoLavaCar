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

        public List<ReseniaDto> ListarResenias()
        {
            List<ReseniaDto> lalistadeServicios = (from laResenia in _elContexto.ReseniasTabla
                                                     select new ReseniaDto
                                                     {
                                                        idResenia = laResenia.idResenia,
                                                        idCliente = laResenia.idCliente,
                                                        idServicio = laResenia.idServicio, 
                                                        fecha = laResenia.fecha.ToString(),
                                                        calificacion = laResenia.calificacion,
                                                        comentarios = laResenia.comentarios,
                                                        estado = laResenia.estado

                                                     }).ToList();
            return lalistadeServicios;
        }
    }
}





