using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEmpleados.Crear;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEvaluaciones.Crear;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloEvaluaciones.Crear
{
   public class CrearEvaluacionAD : ICrearEvaluacionAD
    {
        Contexto _elContexto;

        public CrearEvaluacionAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Crear(EvaluacionesTabla elInventarioACrear)
        {
            try
            {
                _elContexto.EvaluacionesTabla.Add(elInventarioACrear);
                EntityState estado = _elContexto.Entry(elInventarioACrear).State = System.Data.Entity.EntityState.Added;
                int cantidadDeDatosAlmacenados = await _elContexto.SaveChangesAsync();
                return cantidadDeDatosAlmacenados;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
