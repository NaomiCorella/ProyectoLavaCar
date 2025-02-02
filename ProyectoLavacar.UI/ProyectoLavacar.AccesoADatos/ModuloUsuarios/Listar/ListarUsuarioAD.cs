using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloUsuarios.Listar
{
    public class ListarUsuarioAD : IListarUsuarioAD
    {
        Contexto _elContexto;

        public ListarUsuarioAD()
        {
            _elContexto = new Contexto();
        }
        public List<UsuariosDto> ListarUsuarios()
        {
            List<UsuariosDto> laListaDeclientes = (from elCliente in _elContexto.UsuariosTabla
                                                   join usuarioRol in _elContexto.AspNetUserRolesTabla
                                                       on elCliente.Id equals usuarioRol.UserId
                                                   join elRol in _elContexto.RolesTabla
                                                       on usuarioRol.RoleId equals elRol.Id
                                                   where elRol.Name == "Usuario"

                                                   select new UsuariosDto
                                                  {
                                                      nombre = elCliente.nombre,
                                                      primer_apellido = elCliente.primer_apellido,
                                                      segundo_apellido = elCliente.segundo_apellido,
                                                      PhoneNumber = elCliente.PhoneNumber,
                                                      Email = elCliente.Email,
                                                     
                                                      estado = elCliente.estado,
                                                      Id = elCliente.Id,
                                                 
                                                  }).ToList();
            return laListaDeclientes;
        }
    }
}
