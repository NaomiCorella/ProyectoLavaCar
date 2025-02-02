
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.BuscarPorIdInventario;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.BuscarPorIdInventario;
using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloInventario.BuscarPorIdInventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloInventario.BuscarPorId
{
    public class BuscarPorIdInventarioLN : IBuscarPorIdInventarioLN

    {
        IBuscarPorIdInventarioAD _buscarPorIdInventarioAD;

        public BuscarPorIdInventarioLN()
        {
            _buscarPorIdInventarioAD = new BuscarPorIdInventarioAD();
        }

        public InventarioDto Detalle(int idInventario)
        {
            InventarioTabla InventarioEnBaseDeDatos = _buscarPorIdInventarioAD.Detalle(idInventario);
            InventarioDto elInventarioAMostrar = ConvertirAInventarioAMostrar(InventarioEnBaseDeDatos);
            return elInventarioAMostrar;
        }

        private InventarioDto ConvertirAInventarioAMostrar(InventarioTabla elInventario)
        {

            return new InventarioDto
            {
                nombre = elInventario.nombre,
                categoria = elInventario.categoria,
                cantidadDisponible = elInventario.cantidadDisponible,
                precioUnitario = elInventario.precioUnitario,

                estado = elInventario.estado,
                idInventario = elInventario.idInventario,
            };
        }


    }
}

