using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEvaluaciones.Crear;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEvaluaciones.Crear;
using ProyectoLavacar.Abstraciones.Modelos.ModeloEvaluaciones;
using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloEvaluaciones.Crear;
using ProyectoLavacar.AccesoADatos.ModuloInventario.Crear;
using ProyectoLavacar.LN.General.Fecha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloEvaluaciones.Crear
{
   public  class CrearEvaluacionLN :ICrearEvaluacionLN
    {
        IFecha _fecha;
        ICrearEvaluacionAD _crearEvaluacionAD;

        public CrearEvaluacionLN()
        {
            _fecha = new Fecha();
            _crearEvaluacionAD = new CrearEvaluacionAD();
        }

        public async Task<int> Crear(EvaluacionesDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _crearEvaluacionAD.Crear(ConvertirObjetoInventarioTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }

        private EvaluacionesTabla ConvertirObjetoInventarioTabla(EvaluacionesDto laEvaluacion)
        {
            return new EvaluacionesTabla()
            {
                idEvaluacion = laEvaluacion.idEvaluacion,
                idEmpleado = laEvaluacion.idEmpleado,
                areaMejora = laEvaluacion.areaMejora,
                comentarios = laEvaluacion.comentarios,
                calificacion = laEvaluacion.calificacion,
                recomendaciones = laEvaluacion.recomendaciones,
                fechaEvaluacion = _fecha.ObtenerFecha()

            };
        }
    }
}
