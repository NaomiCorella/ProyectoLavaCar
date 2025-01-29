using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.BuscarPorId;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloUsuarios.BuscarPorId
{
    public class BuscarPorIdAD : IBuscarPorIdAD
    {
        Contexto _elContexto;

        public BuscarPorIdAD()
        {
            _elContexto = new Contexto();
        }
        public UsuariosTabla Detalle(string idCliente)
        {
            UsuariosTabla elClienteEnBaseDeDatos = _elContexto.UsuariosTabla.Where(elUsuario => elUsuario.Id == idCliente).FirstOrDefault();
            return elClienteEnBaseDeDatos;
        }
    }
}
