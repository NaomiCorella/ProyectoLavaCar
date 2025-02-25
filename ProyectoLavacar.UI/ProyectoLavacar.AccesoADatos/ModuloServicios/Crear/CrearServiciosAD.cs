using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloServicios.Crear;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloServicios.Crear
{
   public  class CrearServiciosAD :ICrearServiciosAD
    {
        Contexto _elContexto;

        public CrearServiciosAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> Crear(ServiciosTabla elServicio)
        {
            try
            {
                _elContexto.ServiciosTabla.Add(elServicio);
                EntityState estado = _elContexto.Entry(elServicio).State = System.Data.Entity.EntityState.Added;
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
