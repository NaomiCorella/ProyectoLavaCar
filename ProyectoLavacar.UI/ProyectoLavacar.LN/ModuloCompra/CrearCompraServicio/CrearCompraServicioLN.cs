using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.Crear;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.CrearCompraServicios;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.CrearCompraServicios;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloCompra.Crear;
using ProyectoLavacar.AccesoADatos.ModuloCompra.CrearCompraServicio;
using ProyectoLavacar.LN.General.Fecha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloCompra.CrearCompraServicio
{
    public class CrearCompraServicioLN :ICrearCompraServiciosLN
    {
        ICrearCompraServicioAD _crearCompra;
        IFecha _fecha;

        public CrearCompraServicioLN()
        {
            _fecha = new Fecha();
            _crearCompra = new CrearCompraServicioAD();
        }

        public async Task<int> CrearCompra(CompraServiciosDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _crearCompra.CrearCompra(ConvertirObjetoArchivosTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }

        public CompraServiciosTabla ConvertirObjetoArchivosTabla(CompraServiciosDto Compra)
        {
            return new CompraServiciosTabla
            {
                idCompra = Compra.idCompra,
                idCompraServicios= Compra.idCompraServicios,
                idServicio = Compra.idServicio
                
            };
        }
    }
}
