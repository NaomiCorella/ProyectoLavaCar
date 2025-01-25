using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEmpleados.BuscarPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.BuscarPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloEmpleados.BuscarPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloEmpleados.BuscarPorId
{
    public class BuscarPorIdLN : IBuscarPorIdLN
    {
        IBuscarPorIdAD _obtenerPorIdAD;
        public BuscarPorIdLN()
        {
            _obtenerPorIdAD = new BuscarPorIdAD();
        }
        public EmpleadosDto Detalle(int idEmpleado)
        {
            EmpleadosTabla EmpleadosEnBaseDeDatos = _obtenerPorIdAD.Detalle(idEmpleado);
            EmpleadosDto elempleadoAMostrar = ConvertirAPersonaAMostrar(EmpleadosEnBaseDeDatos);
            return elempleadoAMostrar;
        }
        private EmpleadosDto ConvertirAPersonaAMostrar(EmpleadosTabla elEmpleado)
        {

            return new EmpleadosDto
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