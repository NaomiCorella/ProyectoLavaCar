using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.Crear;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloUsuarios.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.Crear;
using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloInventario.Crear;
using ProyectoLavacar.AccesoADatos.ModuloUsuarios.Crear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloInventario.Crear
{
    public class CrearInventarioLN : ICrearInventarioLN
    {
        ICrearInventarioAD _crearInventarioAD;

        public CrearInventarioLN()
        {

            _crearInventarioAD = new CrearInventarioAD();
        }

        public async Task<int> CrearInventario(InventarioDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _crearInventarioAD.CrearInventario(ConvertirObjetoInventarioTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }

        private InventarioTabla ConvertirObjetoInventarioTabla(InventarioDto elInventario)
        {
            return new InventarioTabla()
            {
                nombre = elInventario.nombre,
                categoria = elInventario.categoria,
                cantidadDisponible = elInventario.cantidadDisponible,
                precioUnitario = elInventario.precioUnitario,

                estado = elInventario.estado,
                idProducto = elInventario.idProducto,

            };
        }
    }
}
