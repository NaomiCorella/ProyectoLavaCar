using ProyectoLavacar.Abstraciones.Modelos.ModeloEvaluaciones;
using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEvaluaciones.Crear
{
    public interface ICrearEvaluacionLN
    {
        Task<int> Crear(EvaluacionesDto modelo);
    }
}
