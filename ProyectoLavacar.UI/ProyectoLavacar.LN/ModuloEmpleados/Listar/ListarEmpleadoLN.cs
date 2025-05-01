using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEmpleados.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
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

        public List<EmpleadoDto> ListarEmpleados()
        {
            List<EmpleadoDto> laListasDeEmpleados = _listarEmpleadoAD.ListarEmpleado();
            return laListasDeEmpleados;
        }

        private List<EmpleadoDto> ObtenerLaListaConvertida(List<UsuariosTabla> laListasDeEmpleados)
        {
            List<EmpleadoDto> laListaDeEmpleados = new List<EmpleadoDto>();
            foreach (UsuariosTabla elEmpleado in laListasDeEmpleados)
            {
                laListaDeEmpleados.Add(ConvertirObjetoEmpleadoDto(elEmpleado));
            }
            return laListaDeEmpleados;

        }
        private EmpleadoDto ConvertirObjetoEmpleadoDto(UsuariosTabla elEmpleado)
        {
            if (elEmpleado == null)
            {

                throw new ArgumentNullException(nameof(elEmpleado), "El objeto  no puede ser null.");
            }
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