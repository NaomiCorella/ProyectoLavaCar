using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEvaluaciones.Listar;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloEvaluaciones.Detalles
{
    public class DetallesEvaluacionesAD : IDetallesEvaluacionesAD
    {
        Contexto _elContexto;

        public DetallesEvaluacionesAD()
        {
            _elContexto = new Contexto();
        }
        public EvaluacionesTabla Detalle(int  idEvaluacion)
        {
            EvaluacionesTabla laEvaluacionEnBaseDeDatos = _elContexto.EvaluacionesTabla.Where(laEvaluacion => laEvaluacion.idEvaluacion == idEvaluacion).FirstOrDefault();
            return laEvaluacionEnBaseDeDatos;
        }
    }
}
