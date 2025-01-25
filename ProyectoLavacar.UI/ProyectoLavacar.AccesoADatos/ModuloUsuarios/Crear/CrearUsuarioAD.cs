using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.Crear;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloUsuarios.Crear
{
    public class CrearUsuarioAD : ICrearUsuarioAD
    {
        Contexto _elContexto;

        public CrearUsuarioAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> RegistrarUsuarios(UsuariosTabla elClienteaARegistrar)
        {
            try
            {
                _elContexto.UsuariosTabla.Add(elClienteaARegistrar);
                EntityState estado = _elContexto.Entry(elClienteaARegistrar).State = System.Data.Entity.EntityState.Added;
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