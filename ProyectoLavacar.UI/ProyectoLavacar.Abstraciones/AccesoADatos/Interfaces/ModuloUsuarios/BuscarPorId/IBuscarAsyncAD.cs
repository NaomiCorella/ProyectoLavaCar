using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.BuscarPorId
{
    public interface IBuscarAsyncAD
    {
            Task<UsuariosTabla> DetalleAsync(string idCliente);
     

    }
}
