
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
        public EmpleadoDto Detalle (string idCliente)
        {
            UsuariosTabla clientesEnBaseDeDatos = _obtenerPorIdAD.Detalle(idCliente);
            EmpleadoDto elClienetAMostrar = ConvertirAPersonaAMostrar(clientesEnBaseDeDatos);
            return elClienetAMostrar;
        }
        private EmpleadoDto ConvertirAPersonaAMostrar(UsuariosTabla elCliente)
        {
            
            return new EmpleadoDto
            {
                nombre = elCliente.nombre,
                primer_apellido = elCliente.primer_apellido,
                segundo_apellido = elCliente.segundo_apellido,
                PhoneNumber = elCliente.PhoneNumber,
                Email = elCliente.Email,
                estado = elCliente.estado,
                Id = elCliente.Id,
                turno = elCliente.turno,
                puesto = elCliente.puesto

            };
        }
    }
}