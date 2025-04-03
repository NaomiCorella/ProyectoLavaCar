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
    public class BuscarAsyncLN : IBuscarAsyncLN
    {
        IBuscarAsyncAD _obtenerPorIdAD;
        public BuscarAsyncLN()
        {
            _obtenerPorIdAD = new BuscarAsyncAD();
        }

        // Método asincrónico
        public async Task<EmpleadoDto> DetalleAsync(string idCliente)
        {
            UsuariosTabla clientesEnBaseDeDatos = await _obtenerPorIdAD.DetalleAsync(idCliente);
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