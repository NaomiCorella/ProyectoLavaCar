using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
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

        public EmpleadosTabla ConvertirEmpleados(EmpleadosDto elEmpleado)
        {
            return new EmpleadosTabla
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
                numeroCuenta = elEmpleado.numeroCuenta
            };
        }
    }
}