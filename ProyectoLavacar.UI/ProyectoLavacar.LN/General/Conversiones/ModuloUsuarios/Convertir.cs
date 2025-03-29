using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloUsuarios;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.General.Conversiones.ModuloUsuarios
{
    public class convertir : IConvertir
    {
        public UsuariosTabla ConvertirCliente(EmpleadoDto elCliente)
        {
            return new UsuariosTabla
            {
                Id = elCliente.Id,
                PasswordHash = elCliente.PasswordHash,

            };
        }
    }
}
