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
        public async Task<int> EditarEmpleado(EmpleadosTabla elEmpleadoParaEditar)
        {
            EmpleadosTabla elEmpleadoEnBaseDeDatos = _elcontexto.EmpleadosTabla.Where(elEmpleado => elEmpleado.idEmpleado == elEmpleadoParaEditar.idEmpleado).FirstOrDefault();
            elEmpleadoEnBaseDeDatos.nombre = elEmpleadoParaEditar.nombre;
            elEmpleadoEnBaseDeDatos.primer_apellido = elEmpleadoParaEditar.primer_apellido;
            elEmpleadoEnBaseDeDatos.segundo_apellido = elEmpleadoParaEditar.segundo_apellido;
            elEmpleadoEnBaseDeDatos.telefono = elEmpleadoParaEditar.telefono;
            elEmpleadoEnBaseDeDatos.correo = elEmpleadoParaEditar.correo;
            elEmpleadoEnBaseDeDatos.cedula = elEmpleadoParaEditar.cedula;
            elEmpleadoEnBaseDeDatos.turno = elEmpleadoParaEditar.turno;
            elEmpleadoEnBaseDeDatos.puesto = elEmpleadoEnBaseDeDatos.puesto;
            elEmpleadoEnBaseDeDatos.numeroCuenta = elEmpleadoEnBaseDeDatos.numeroCuenta;
            EntityState estado = _elcontexto.Entry(elEmpleadoEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elcontexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}
