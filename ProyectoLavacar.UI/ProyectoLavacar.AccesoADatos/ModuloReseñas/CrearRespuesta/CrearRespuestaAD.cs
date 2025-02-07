using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReseñas.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.CrearRespuesta;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloReseñas.CrearRespuesta
{

    public class CrearRespuestaAD : ICrearRespuestaAD
    {
        Contexto _elContexto;

        public CrearRespuestaAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> CrearRespuestaResenia(RespuestaTabla larespuesta)
        {
            try
            {
                _elContexto.RespuestaTabla.Add(larespuesta);
                EntityState estado = _elContexto.Entry(larespuesta).State = System.Data.Entity.EntityState.Added;
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
