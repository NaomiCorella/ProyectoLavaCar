using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEmpleados.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloEmpleados.Listar
{
    public class ListarEmpleadoAD : IListarEmpleadoAD
    {
        Contexto _elContexto;

        public ListarEmpleadoAD()
        {
            _elContexto = new Contexto();
        }
        public List<UsuariosDto> ListarEmpleado()
        {
            List<UsuariosDto> laListaDeEmpleados = (from elEmpleado in _elContexto.UsuariosTabla

                                                   select new UsuariosDto
                                                   {
                                                       nombre = elEmpleado.nombre,
                                                       primer_apellido = elEmpleado.primer_apellido,
                                                       segundo_apellido = elEmpleado.segundo_apellido,
                                                       PhoneNumber = elEmpleado.PhoneNumber,
                                                       Email = elEmpleado.Email,
                                                       cedula = elEmpleado.cedula,
                                                       estado = elEmpleado.estado,
                                                       Id = elEmpleado.Id,
                                                       puesto = elEmpleado.puesto,
                                                       turno = elEmpleado.turno,
                                                       numeroCuenta = elEmpleado.numeroCuenta,
                                                   }).ToList();
            return laListaDeEmpleados;
        }
    }
}
