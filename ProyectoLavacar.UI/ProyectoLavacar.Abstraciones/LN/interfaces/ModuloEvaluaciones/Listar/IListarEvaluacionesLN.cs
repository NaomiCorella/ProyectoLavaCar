using ProyectoLavacar.Abstraciones.Modelos.ModeloEvaluaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEvaluaciones
{
    public interface IListarEvaluacionesLN
    {
        List<EvalucionesDto> ListarEvaluaciones(String idEmpleado);
    }
}
