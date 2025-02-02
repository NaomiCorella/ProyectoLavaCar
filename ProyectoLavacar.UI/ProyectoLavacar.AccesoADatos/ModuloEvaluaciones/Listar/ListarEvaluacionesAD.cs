using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEvaluaciones;
using ProyectoLavacar.Abstraciones.Modelos.ModeloEvaluaciones;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloEvaluaciones
{
    public class ListarEvaluacionesAD : IListarEvaluacionesAD
    {
        Contexto _elContexto;

        public ListarEvaluacionesAD()
        {
            _elContexto = new Contexto();
        }

        public List<EvalucionesDto> ListarEvaluaciones(string idEmpleado)
        {
            List<EvalucionesDto> lalistaDeEvaluaciones = (from laEvaluacion in _elContexto.EvaluacionesTabla
                                                          join empleados in _elContexto.UsuariosTabla on laEvaluacion.idEmpleado equals empleados.Id
                                                          where laEvaluacion.idEmpleado == idEmpleado
                                                       

                                                          select new EvalucionesDto
                                                   {
                                                       idEvaluacion = laEvaluacion.idEvaluacion,
                                                       idEmpleado = laEvaluacion.idEmpleado,
                                                       areaMejora = laEvaluacion.areaMejora,
                                                       comentarios = laEvaluacion.comentarios,
                                                       calificacion = laEvaluacion.calificacion,
                                                       recomendaciones = laEvaluacion.recomendaciones,
                                                       fechaEvaluacion = laEvaluacion.fechaEvaluacion.ToString(),

                                                   }).ToList();
            return lalistaDeEvaluaciones;
        }
    }
}
