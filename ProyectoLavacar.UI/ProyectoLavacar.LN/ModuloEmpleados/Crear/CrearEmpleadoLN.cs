
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEmpleados.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Crear;
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloEmpleados.Crear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloEmpleados.Crear
{
    public class CrearEmpleadoLN : ICrearEmpleadoLN
    {
        ICrearEmpleadoAD _crearEmpleadosAD;


        public CrearEmpleadoLN()
        {

            _crearEmpleadosAD = new CrearEmpleadoAD();
        }
        public async Task<int> RegistrarEmpleado(EmpleadosDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _crearEmpleadosAD.RegistrarEmpleados(ConvertirObjetoEmpleadosTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }
        private EmpleadosTabla ConvertirObjetoEmpleadosTabla(EmpleadosDto elEmpleado)
        {
            return new EmpleadosTabla()
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

