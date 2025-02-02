using ProyectoLavacar.Abstraciones.Modelos.ModeloEvaluaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEvaluaciones
{
    public interface IListarEvaluacionesAD
    {
        List<EvalucionesDto> ListarEvaluaciones(string idEmpleado);
    }
}
