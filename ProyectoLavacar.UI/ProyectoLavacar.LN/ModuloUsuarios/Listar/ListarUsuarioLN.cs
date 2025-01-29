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

        public List<UsuariosDto> ListarUsuarios()
        {
            List<UsuariosDto> laListasDePersonas = _listarPersonasAD.ListarUsuarios();
            return laListasDePersonas;
        }

        private List<UsuariosDto> ObtenerLaListaConvertida(List<UsuariosTabla> laListasDePersonas)
        {
            List<UsuariosDto> laListaDeUsuarios = new List<UsuariosDto>();
            foreach (UsuariosTabla elUsuario in laListasDePersonas)
            {
                laListaDeUsuarios.Add(ConvertirObjetoUsuariosDto(elUsuario));
            }
            return laListaDeUsuarios;
        }
        private UsuariosDto ConvertirObjetoUsuariosDto(UsuariosTabla elCliente)
        {
            if (elCliente == null)
            {

                throw new ArgumentNullException(nameof(elCliente), "El objeto  no puede ser null.");
            }
            return new UsuariosDto
            {
                nombre = elCliente.nombre,
                primer_apellido = elCliente.primer_apellido,
                segundo_apellido = elCliente.segundo_apellido,
                telefono = elCliente.telefono,
                correoElectronico = elCliente.correoElectronico,
                direccion = elCliente.direccion,
                estado = elCliente.estado,
                idCliente = elCliente.Id,
                contraseña = elCliente.contraseña
            };
        }
    }
}