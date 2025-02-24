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
   public class CrearAccidenteAD : ICrearAccidenteAD
    {
   
        Contexto _elContexto;

        public CrearAccidenteAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> RegistrarTramites(AccidenteTabla elTramiteARegistrar)
        {
            try
            {
                _elContexto.AccidenteTabla.Add(elTramiteARegistrar);
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
