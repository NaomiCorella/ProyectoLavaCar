using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.BuscarPorId
{
    public interface IBuscarAsyncLN
    {
        Task<UsuariosDto> DetalleAsync(string idCliente);


    }
}
