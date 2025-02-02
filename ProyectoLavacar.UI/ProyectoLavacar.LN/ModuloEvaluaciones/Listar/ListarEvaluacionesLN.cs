using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEvaluaciones;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReseñas.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEvaluaciones;
using ProyectoLavacar.Abstraciones.Modelos.ModeloEvaluaciones;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloEvaluaciones;
using ProyectoLavacar.AccesoADatos.ModuloReseñas.Listar;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloEvaluaciones
{
    public class ListarEvaluacionesLN : IListarEvaluacionesLN
    {
        IListarEvaluacionesAD _listarEvaluacionesAD;
        public ListarEvaluacionesLN()
        {
            _listarEvaluacionesAD = new ListarEvaluacionesAD();
        }

        public List<EvalucionesDto> ListarEvaluaciones(string idEmpleado)
        {
            List<EvalucionesDto> lalistaEvaluaciones = _listarEvaluacionesAD.ListarEvaluaciones(idEmpleado);

            return lalistaEvaluaciones;
        }

        private List<EvalucionesDto> ObtenerLaListaConvertida(List<EvaluacionesTabla> lalistaDeEvaluaciones)
        {//chequear
            List<EvalucionesDto> lalistaEvalua = new List<EvalucionesDto>();
            foreach (EvaluacionesTabla laEvaluacion in lalistaDeEvaluaciones)
            {
                lalistaEvalua.Add(ConvertirObjetoServiciosDto(laEvaluacion));
            }
            return lalistaEvalua;
        }
        private EvalucionesDto ConvertirObjetoServiciosDto(EvaluacionesTabla laEvaluacion)
        {

            return new EvalucionesDto
            {
                idEvaluacion = laEvaluacion.idEvaluacion,
                idEmpleado = laEvaluacion.idEmpleado,
                areaMejora = laEvaluacion.areaMejora,
                comentarios = laEvaluacion.comentarios,
                calificacion = laEvaluacion.calificacion,
                recomendaciones = laEvaluacion.recomendaciones,
                fechaEvaluacion = laEvaluacion.fechaEvaluacion.ToString(),


            };
        }
    }
}
