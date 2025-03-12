using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloUsuarios
{
    public class ConvertirUsuariosDtoAUsuariosTabla : IConvertirUsuariosDtoAUsuariosTabla
    {
        
        public UsuariosTabla ConvertirCliente(UsuariosDto elCliente)
        {
            return new UsuariosTabla
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