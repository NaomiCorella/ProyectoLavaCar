using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloUsuarios.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloUsuarios.Listar
{
    public class ListarUsuarioLN : IListarUsuarioLN
    {
        IListarUsuarioAD _listarPersonasAD;
        public ListarUsuarioLN()
        {
            _listarPersonasAD = new ListarUsuarioAD();
        }

        public List<EmpleadoDto> ListarUsuarios()
        {
            List<EmpleadoDto> laListasDePersonas = _listarPersonasAD.ListarUsuarios();
            return laListasDePersonas;
        }

        private List<EmpleadoDto> ObtenerLaListaConvertida(List<UsuariosTabla> laListasDePersonas)
        {
            List<EmpleadoDto> laListaDeUsuarios = new List<EmpleadoDto>();
            foreach (UsuariosTabla elUsuario in laListasDePersonas)
            {
                laListaDeUsuarios.Add(ConvertirObjetoUsuariosDto(elUsuario));
            }
            return laListaDeUsuarios;
        }
        private EmpleadoDto ConvertirObjetoUsuariosDto(UsuariosTabla elCliente)
        {
            if (elCliente == null)
            {

                throw new ArgumentNullException(nameof(elCliente), "El objeto  no puede ser null.");
            }
            return new EmpleadoDto
            {
                nombre = elCliente.nombre,
                primer_apellido = elCliente.primer_apellido,
                segundo_apellido = elCliente.segundo_apellido,
                PhoneNumber = elCliente.PhoneNumber,
                Email = elCliente.Email,
                cedula = elCliente.cedula,
            
                estado = elCliente.estado,
                Id = elCliente.Id,
            
            };
        }
    }
}