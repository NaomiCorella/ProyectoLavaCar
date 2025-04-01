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
        public EmpleadoDto Detalle(string idEmpleado)
        {
            UsuariosTabla EmpleadosEnBaseDeDatos = _obtenerPorIdAD.Detalle(idEmpleado);
            EmpleadoDto elempleadoAMostrar = ConvertirAPersonaAMostrar(EmpleadosEnBaseDeDatos);
            return elempleadoAMostrar;
        }
        private EmpleadoDto ConvertirAPersonaAMostrar(UsuariosTabla elEmpleado)
        {

            return new EmpleadoDto
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