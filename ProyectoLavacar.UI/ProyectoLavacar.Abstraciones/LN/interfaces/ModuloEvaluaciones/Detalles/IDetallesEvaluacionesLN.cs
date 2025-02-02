using ProyectoLavacar.Abstraciones.Modelos.ModeloEvaluaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEvaluaciones.Detalles
{
    public interface IDetallesEvaluacionesLN
    {
        EvalucionesDto Detalle(int idEvaluacion);
    }
}
