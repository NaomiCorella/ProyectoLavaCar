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
        public List<EmpleadosDto> ListarEmpleado()
        {
            List<EmpleadosDto> laListaDeEmpleados = (from elEmpleado in _elContexto.EmpleadosTabla

                                                   select new EmpleadosDto
                                                   {
                                                       nombre = elEmpleado.nombre,
                                                       primer_apellido = elEmpleado.primer_apellido,
                                                       segundo_apellido = elEmpleado.segundo_apellido,
                                                       telefono = elEmpleado.telefono,
                                                       correo = elEmpleado.correo,
                                                       cedula = elEmpleado.cedula,
                                                       estado = elEmpleado.estado,
                                                       idEmpleado = elEmpleado.idEmpleado,
                                                       puesto = elEmpleado.puesto,
                                                       turno = elEmpleado.turno,
                                                       numeroCuenta = elEmpleado.numeroCuenta,
                                                   }).ToList();
            return laListaDeEmpleados;
        }
    }
}
