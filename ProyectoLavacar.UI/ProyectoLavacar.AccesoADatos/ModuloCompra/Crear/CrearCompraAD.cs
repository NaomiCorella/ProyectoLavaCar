using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.Crear;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloCompra.Crear
{
    public class CrearCompraAD : ICrearCompraAD
    {
        Contexto _elContexto;

        public CrearCompraAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> CrearCompra(CompraTabla laCompraACrear)
        {
            try
            {
                _elContexto.CompraTabla.Add(laCompraACrear);
                EntityState estado = _elContexto.Entry(laCompraACrear).State = System.Data.Entity.EntityState.Added;
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

