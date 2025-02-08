using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.Listar;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.ListarMovimiento;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.ListarMovimiento;
using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloInventario.Listar;
using ProyectoLavacar.AccesoADatos.ModuloInventario.ListarMovimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloInventario.ListarMovimiento
{
    public class ListarMovimientoLN : IListarMovimientoLN
    {
        IListarMovimientoAD _listarMovimientoAD;

        public ListarMovimientoLN()
        {
            _listarMovimientoAD = new ListarMovimientoAD();
        }


        public List<MovimientoDto> ListarInventario()
        {
            List<MovimientoDto> laListasDeEmpleados = _listarMovimientoAD.ListarMovimiento();
            return laListasDeEmpleados;
        }

        private List<MovimientoDto> ObtenerLaListaConvertida(List<MovimientoTabla> laListasDeMovimientosTabla)
        {
            List<MovimientoDto> LalistaDeMovimiento = new List<MovimientoDto>();
            foreach (MovimientoTabla elInventario in laListasDeMovimientosTabla)
            {
                LalistaDeMovimiento.Add(ConvertirObjetoInventarioDto(elInventario));
            }
            return LalistaDeMovimiento;

        }

        private MovimientoDto ConvertirObjetoInventarioDto(MovimientoTabla movimiento)
        {
        
            return new MovimientoDto
            {
                idMovimiento = movimiento.idMovimiento,
                idProducto = movimiento.idProducto,
                nombre = movimiento.nombre,
                cantidad = movimiento.cantidad,
                fecha = movimiento.fecha.ToString()
            };
        }
    }
}

