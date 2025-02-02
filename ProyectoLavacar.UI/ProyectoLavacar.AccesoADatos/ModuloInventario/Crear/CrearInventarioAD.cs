using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.Crear;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloInventario.Crear
{
    public class CrearInventarioAD : ICrearInventarioAD
    {
        Contexto _elContexto;

        public CrearInventarioAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> CrearInventario (InventarioTabla elInventarioACrear)
        {
            try
            {
                _elContexto.InventarioTabla.Add(elInventarioACrear);
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