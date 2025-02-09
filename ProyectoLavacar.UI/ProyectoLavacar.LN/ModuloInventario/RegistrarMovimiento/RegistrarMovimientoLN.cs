using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.Crear;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.RegistrarMovimiento;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.RegistrarMovimiento;
using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloInventario.Crear;
using ProyectoLavacar.AccesoADatos.ModuloInventario.RegistrarMovimiento;
using ProyectoLavacar.LN.General.Fecha;
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
        public RegistrarMovimientoLN()
        {
            _fecha = new Fecha();
            _crearMovimientoAD = new RegistrarMovimientoAD();
        }

        public async Task<int> Registrar(MovimientoDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _crearMovimientoAD.Registrar(ConvertirObjetoInventarioTabla(modelo));
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
    }
}
