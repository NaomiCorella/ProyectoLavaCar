using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.Remover;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloUsuarios.Remover
{
  
        public class RemoverAD : IRemoverAD
        {
            Contexto _elcontexto;

            public RemoverAD()
            {
                _elcontexto = new Contexto();
            }

            public async Task<int> EditarUsuarios(UsuariosTabla elClienteParaEditar)
            {
                UsuariosTabla laPersonaEnBaseDeDatos = _elcontexto.UsuariosTabla.Where(elCliente => elCliente.Id == elClienteParaEditar.Id).FirstOrDefault();
                laPersonaEnBaseDeDatos.PasswordHash = elClienteParaEditar.PasswordHash;

                EntityState estado = _elcontexto.Entry(laPersonaEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
                int cantidadDeDatosAlmacenados = await _elcontexto.SaveChangesAsync();
                return cantidadDeDatosAlmacenados;
            }
        }
    }



