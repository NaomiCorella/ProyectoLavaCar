using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.CrearAccidente;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.CrearAccidente
{
   public class CrearRebajoAD : ICrearRebajoAD
    {
   
        Contexto _elContexto;

        public CrearRebajoAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> RegistrarTramites(RebajosTabla elTramiteARegistrar)
        {
            try
            {
                _elContexto.RebajosTabla.Add(elTramiteARegistrar);
                EntityState estado = _elContexto.Entry(elTramiteARegistrar).State = System.Data.Entity.EntityState.Added;
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
