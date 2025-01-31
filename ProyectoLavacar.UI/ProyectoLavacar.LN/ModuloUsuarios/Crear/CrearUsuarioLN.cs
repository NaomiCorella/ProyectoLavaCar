
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Crear;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloUsuarios.Crear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloUsuarios.Crear
{
    public class CrearUsuarioLN : ICrearUsuarioLN
    {
        ICrearUsuarioAD _crearUsuarioAD;


        public CrearUsuarioLN()
        {

            _crearUsuarioAD = new CrearUsuarioAD();
        }
        public async Task<int> RegistrarUsuarios(UsuariosDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _crearUsuarioAD.RegistrarUsuarios(ConvertirObjetoClientesTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }
        private UsuariosTabla ConvertirObjetoClientesTabla(UsuariosDto elCliente)
        {
            return new UsuariosTabla()
            {
                
                nombre = elCliente.nombre,
                primer_apellido = elCliente.primer_apellido,
                segundo_apellido = elCliente.segundo_apellido,
                PhoneNumber = elCliente.PhoneNumber,
                Email = elCliente.Email,
          
                estado = elCliente.estado,
                Id = elCliente.Id,
               
            };
        }
    }
}

