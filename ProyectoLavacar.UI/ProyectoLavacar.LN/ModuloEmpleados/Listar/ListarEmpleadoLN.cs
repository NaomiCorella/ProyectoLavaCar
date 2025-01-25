using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEmpleados.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloEmpleados.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloEmpleados.Listar
{
    public class ListarEmpleadoLN : IListarEmpleadoLN
    {
        IListarEmpleadoAD _listarEmpleadoAD;
        public ListarEmpleadoLN()
        {
            _listarEmpleadoAD = new ListarEmpleadoAD();
        }

        public List<EmpleadosDto> ListarEmpleados()
        {
            List<EmpleadosDto> laListasDeEmpleados = _listarEmpleadoAD.ListarEmpleado();
            return laListasDeEmpleados;
        }

        private List<EmpleadosDto> ObtenerLaListaConvertida(List<EmpleadosTabla> laListasDeEmpleados)
        {
            List<EmpleadosDto> laListaDeEmpleados = new List<EmpleadosDto>();
            foreach (EmpleadosTabla elEmpleado in laListasDeEmpleados)
            {
                laListaDeEmpleados.Add(ConvertirObjetoEmpleadoDto(elEmpleado));
            }
            return laListaDeEmpleados;

        }
        private EmpleadosDto ConvertirObjetoEmpleadoDto(EmpleadosTabla elEmpleado)
        {
            if (elEmpleado == null)
            {

                throw new ArgumentNullException(nameof(elEmpleado), "El objeto  no puede ser null.");
            }
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