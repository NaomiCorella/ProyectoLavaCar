using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEmpleados.Editar;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloEmpleados.Editar
{
    public class EditarEmpleadoAD : IEditarEmpleadoAD
    {
        Contexto _elcontexto;

        public EditarEmpleadoAD()
        {
            _elcontexto = new Contexto();
        }
        public async Task<int> EditarEmpleado(UsuariosTabla elEmpleadoParaEditar)
        {
            UsuariosTabla elEmpleadoEnBaseDeDatos = _elcontexto.UsuariosTabla.Where(elEmpleado => elEmpleado.Id == elEmpleadoParaEditar.Id).FirstOrDefault();
            elEmpleadoEnBaseDeDatos.nombre = elEmpleadoParaEditar.nombre;
            elEmpleadoEnBaseDeDatos.primer_apellido = elEmpleadoParaEditar.primer_apellido;
            elEmpleadoEnBaseDeDatos.segundo_apellido = elEmpleadoParaEditar.segundo_apellido;
            elEmpleadoEnBaseDeDatos.PhoneNumber = elEmpleadoParaEditar.PhoneNumber;
            elEmpleadoEnBaseDeDatos.Email = elEmpleadoParaEditar.Email;
            elEmpleadoEnBaseDeDatos.cedula = elEmpleadoParaEditar.cedula;
            elEmpleadoEnBaseDeDatos.turno = elEmpleadoParaEditar.turno;
            elEmpleadoEnBaseDeDatos.puesto = elEmpleadoParaEditar.puesto;
            elEmpleadoEnBaseDeDatos.numeroCuenta = elEmpleadoParaEditar.numeroCuenta;
            EntityState estado = _elcontexto.Entry(elEmpleadoEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elcontexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}
