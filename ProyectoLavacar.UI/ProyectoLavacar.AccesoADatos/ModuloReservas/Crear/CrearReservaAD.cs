using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.Crear;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloReservas.Crear
{
    public class CrearReservaAD : ICrearReservaAD
    {
        Contexto _elContexto;

        public CrearReservaAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> CrearReserva(ReservasTabla laReserva)
        {
            try
            {
                _elContexto.ReservasTabla.Add(laReserva);
                EntityState estado = _elContexto.Entry(laReserva).State = System.Data.Entity.EntityState.Added;
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

