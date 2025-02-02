using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEvaluaciones.Listar
{
    public interface IDetallesEvaluacionesAD
    {
        EvaluacionesTabla Detalle(int idEvaluacion);
    }
}
