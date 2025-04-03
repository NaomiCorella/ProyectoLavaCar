using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.CrearCompraServicios;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloCompra.CrearCompraServicio
{
   public class CrearCompraServicioAD : ICrearCompraServicioAD
    {
        Contexto _elContexto;

        public CrearCompraServicioAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> CrearCompra(CompraServiciosTabla laCompraACrear)
        {
            try
            {
                _elContexto.CompraServiciosTabla.Add(laCompraACrear);
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
