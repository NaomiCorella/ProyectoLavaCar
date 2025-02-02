using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEvaluaciones.Listar;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReseñas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEvaluaciones.Detalles;
using ProyectoLavacar.Abstraciones.Modelos.ModeloEvaluaciones;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloEvaluaciones.Detalles;
using ProyectoLavacar.AccesoADatos.ModuloReseñas.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloEvaluaciones.Detalles
{
    public class DetallesEvaluacionesLN : IDetallesEvaluacionesLN
    {
        IDetallesEvaluacionesAD _detallesEvaluacionesAD;
        public DetallesEvaluacionesLN()
        {
            _detallesEvaluacionesAD = new DetallesEvaluacionesAD();
        }
        public EvalucionesDto Detalle(int idEvaluacion)
        {
            EvaluacionesTabla reservaEnBaseDeDatos = _detallesEvaluacionesAD.Detalle(idEvaluacion);
            EvalucionesDto laEvaluacionAMostrar = ConvertirAReservaAMostrar(reservaEnBaseDeDatos);
            return laEvaluacionAMostrar;
        }
        private EvalucionesDto ConvertirAReservaAMostrar(EvaluacionesTabla laEvaluacion)
        {

            return new EvalucionesDto
            {
                idEvaluacion = laEvaluacion.idEvaluacion,
                idEmpleado = laEvaluacion.idEmpleado,
                areaMejora = laEvaluacion.areaMejora,
                comentarios = laEvaluacion.comentarios,
                calificacion = laEvaluacion.calificacion,
                recomendaciones = laEvaluacion.recomendaciones,
                fechaEvaluacion = laEvaluacion.fechaEvaluacion.ToString()
            };
        }
    }
}
