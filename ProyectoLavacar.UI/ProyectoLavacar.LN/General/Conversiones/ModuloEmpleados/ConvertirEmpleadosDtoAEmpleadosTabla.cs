using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.General.Conversiones.ModuloEmpleados
{
    public class ConvertirEmpleadosDtoAEmpleadosTabla : IConvertirEmpleadosDtoAEmpleadosTabla
    {

        public UsuariosTabla ConvertirEmpleados(UsuariosDto elEmpleado)
        {
            return new UsuariosTabla
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
                numeroCuenta = elEmpleado.numeroCuenta
            };
        }
    }
}