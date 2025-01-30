using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReseñas.Crear;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloReseñas.Crear
{
    public class CrearReseniaAD : ICrearReseniaAD
    {
        Contexto _elContexto;

        public CrearReseniaAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> CrearResenia(ReseniasTabla laresenia)
        {
            try
            {
                _elContexto.ReseniasTabla.Add(laresenia);
                EntityState estado = _elContexto.Entry(laresenia).State = System.Data.Entity.EntityState.Added;
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
