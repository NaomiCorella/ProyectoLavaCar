using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.CrearNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.CrearNomina
{
    public class CrearNominaAD : ICrearNominaAD
    {
        Contexto _elContexto;

        public CrearNominaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> RegistrarNomina(NominaTabla elTramiteARegistrar)
        {
            try
            {
                _elContexto.NominaTabla.Add(elTramiteARegistrar);
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
