using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.CrearTramites;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.CrearTramites
{
    public class CrearTramitesAD : ICrearTramitesAD
    {
        Contexto _elContexto;

        public CrearTramitesAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> RegistrarTramites(TramitesTabla elTramiteARegistrar)
        {
            try
            {
                _elContexto.TramitesTabla.Add(elTramiteARegistrar);
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