using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.CrearAjusteSalariales;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace ProyectoLavacar.AccesoADatos.ModuloNomina.CrearAjusteSalariales
{
    public class CrearAjustesSalarialesAD : ICrearAjusteSalarialesAD
    {
        Contexto _elContexto;

        public CrearAjustesSalarialesAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> RegistrarAjusteSalarial(AjustesSalarialesTabla elAjusteSalarialARegistrar)
        {
            try
            {
                _elContexto.AjustesSalarialesTabla.Add(elAjusteSalarialARegistrar);
                EntityState estado = _elContexto.Entry(elAjusteSalarialARegistrar).State = System.Data.Entity.EntityState.Added;
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