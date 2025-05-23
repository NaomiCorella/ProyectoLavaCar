﻿using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.Editar;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloUsuarios.Editar
{
    public class EditarUsuarioAD : IEditarUsuarioAD
    {
        Contexto _elcontexto;

        public EditarUsuarioAD()
        {
            _elcontexto = new Contexto();
        }

        public async Task<int> EditarUsuarios(UsuariosTabla elClienteParaEditar)
        {
            UsuariosTabla laPersonaEnBaseDeDatos = _elcontexto.UsuariosTabla.Where(elCliente => elCliente.Id == elClienteParaEditar.Id).FirstOrDefault();
            laPersonaEnBaseDeDatos.nombre = elClienteParaEditar.nombre;
            laPersonaEnBaseDeDatos.primer_apellido = elClienteParaEditar.primer_apellido;
            laPersonaEnBaseDeDatos.segundo_apellido = elClienteParaEditar.segundo_apellido;
            laPersonaEnBaseDeDatos.PhoneNumber = elClienteParaEditar.PhoneNumber;
            laPersonaEnBaseDeDatos.Email = elClienteParaEditar.Email;
          
            EntityState estado = _elcontexto.Entry(laPersonaEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elcontexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}

