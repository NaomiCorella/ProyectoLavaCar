
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.BuscarPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.BuscarPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloUsuarios.BuscarPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloUsuarios.BuscarPorId
{
    public class BuscarPorIdLN : IBuscarPorIdLN
    {
        IBuscarPorIdAD _obtenerPorIdAD;
        public BuscarPorIdLN()
        {
            _obtenerPorIdAD = new BuscarPorIdAD();
        }
        public UsuariosDto Detalle (int idCliente)
        {
            UsuariosTabla clientesEnBaseDeDatos = _obtenerPorIdAD.Detalle(idCliente);
            UsuariosDto elClienetAMostrar = ConvertirAPersonaAMostrar(clientesEnBaseDeDatos);
            return elClienetAMostrar;
        }
        private UsuariosDto ConvertirAPersonaAMostrar(UsuariosTabla elCliente)
        {
            
            return new UsuariosDto
            {
                nombre = elCliente.nombre,
                primer_apellido = elCliente.primer_apellido,
                segundo_apellido = elCliente.segundo_apellido,
                telefono = elCliente.telefono,
                correoElectronico = elCliente.correoElectronico,
                direccion = elCliente.direccion,
                estado = elCliente.estado,
                idCliente = elCliente.idCliente,
                contraseña = elCliente.contraseña
            };
        }
    }
}