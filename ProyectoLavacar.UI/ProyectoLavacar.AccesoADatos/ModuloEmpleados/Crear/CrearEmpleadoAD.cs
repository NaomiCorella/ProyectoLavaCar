using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEmpleados.Crear;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloEmpleados.Crear
{
    public class CrearEmpleadoAD : ICrearEmpleadoAD
    {
        Contexto _elContexto;

        public CrearEmpleadoAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> RegistrarEmpleados(EmpleadosTabla elEmpleadoARegistrar)
        {
            try
            {
                _elContexto.EmpleadosTabla.Add(elEmpleadoARegistrar);
                EntityState estado = _elContexto.Entry(elEmpleadoARegistrar).State = System.Data.Entity.EntityState.Added;
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