using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.Crear;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.RegistrarMovimiento;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.BuscarPorIdInventario;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.RegistrarMovimiento;
using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloInventario.Crear;
using ProyectoLavacar.AccesoADatos.ModuloInventario.RegistrarMovimiento;
using ProyectoLavacar.LN.General.Fecha;
using ProyectoLavacar.LN.ModuloInventario.Actualizar;
using ProyectoLavacar.LN.ModuloInventario.BuscarPorId;
using ProyectoLavacar.LN.ModuloInventario.Editar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloInventario.RegistrarMovimiento
{
    public class RegistrarMovimientoLN : IRegistrarMovimientoLN
    {
        IRegistrarMovimientoAD _crearMovimientoAD;
        IFecha _fecha;
        IEditarInventarioLN _actualizarCantidad;
        IBuscarPorIdInventarioLN _BuscarPorIdInventario;
        public RegistrarMovimientoLN()
        {
            _fecha = new Fecha();
            _crearMovimientoAD = new RegistrarMovimientoAD();
            _actualizarCantidad =new  EditarInventarioLN();
            _BuscarPorIdInventario = new BuscarPorIdInventarioLN();
        }

        public async Task<int> Registrar(MovimientoDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _crearMovimientoAD.Registrar(ConvertirObjetoInventarioTabla(modelo));
            int cantidad = await ActualizarCantidad(modelo);
            return cantidadDeDatosAlmacenados;
        }

        private MovimientoTabla ConvertirObjetoInventarioTabla(MovimientoDto movimiento)
        {
            return new MovimientoTabla()
            {
               idMovimiento = movimiento.idMovimiento,
               idProducto = movimiento.idProducto,
               nombre = movimiento.nombre,
               cantidad = movimiento.cantidad,
               fecha = _fecha.ObtenerFecha()

            };
        }
        private async Task<int> ActualizarCantidad(MovimientoDto movimiento)
        {
            InventarioDto modelo = _BuscarPorIdInventario.Detalle(movimiento.idProducto);
            int cantidad =modelo.cantidadDisponible;
            int nuevaCantidad = 0;
            if (movimiento.nombre == "Salida")
            {
                nuevaCantidad = cantidad - movimiento.cantidad;
            }
            else
            {
                nuevaCantidad = cantidad + movimiento.cantidad;
            }

                InventarioDto inventario = new InventarioDto()
                {
                    idProducto = modelo.idProducto,
                    nombre = modelo.nombre,
                    categoria = modelo.categoria,
                    cantidadDisponible = nuevaCantidad,
                    precioUnitario = modelo.precioUnitario,
                    estado = true
                };
            int cantidadDeDatosEditados = await _actualizarCantidad.EditarInventario(inventario);
            return cantidadDeDatosEditados;
        }

    }
}
