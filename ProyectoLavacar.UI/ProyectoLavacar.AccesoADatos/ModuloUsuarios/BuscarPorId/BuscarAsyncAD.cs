using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.BuscarPorId;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloUsuarios.BuscarPorId
{
    public class BuscarAsyncAD : IBuscarAsyncAD
    {
        Contexto _elContexto;

        public BuscarAsyncAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<UsuariosTabla> DetalleAsync(string idCliente)
        {
            return await _elContexto.UsuariosTabla
                .Where(elUsuario => elUsuario.Id == idCliente)
                .FirstOrDefaultAsync();
        }


    }
}
