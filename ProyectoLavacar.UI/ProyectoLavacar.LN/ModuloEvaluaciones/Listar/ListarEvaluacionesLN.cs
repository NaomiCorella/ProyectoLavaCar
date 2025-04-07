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

        public List<EvaluacionesDto> ListarEvaluaciones(string idEmpleado)
        {
            List<EvaluacionesDto> lalistaEvaluaciones = _listarEvaluacionesAD.ListarEvaluaciones(idEmpleado);

            return lalistaEvaluaciones;
        }

        private List<EvaluacionesDto> ObtenerLaListaConvertida(List<EvaluacionesTabla> lalistaDeEvaluaciones)
        {//chequear
            List<EvaluacionesDto> lalistaEvalua = new List<EvaluacionesDto>();
            foreach (EvaluacionesTabla laEvaluacion in lalistaDeEvaluaciones)
            {
                lalistaEvalua.Add(ConvertirObjetoServiciosDto(laEvaluacion));
            }
            return lalistaEvalua;
        }
        private EvaluacionesDto ConvertirObjetoServiciosDto(EvaluacionesTabla laEvaluacion)
        {

            return new EvaluacionesDto
            {
                idEvaluacion = laEvaluacion.idEvaluacion,
                idEmpleado = laEvaluacion.idEmpleado,
                areaMejora = laEvaluacion.areaMejora,
                comentarios = laEvaluacion.comentarios,
                calificacion = laEvaluacion.calificacion,
                recomendaciones = laEvaluacion.recomendaciones,
                fechaEvaluacion = laEvaluacion.fechaEvaluacion.ToString("dd/mm/yyyy"),


            };
        }
    }
}
