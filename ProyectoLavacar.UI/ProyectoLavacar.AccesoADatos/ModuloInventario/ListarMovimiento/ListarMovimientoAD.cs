using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.ListarMovimiento;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloInventario.ListarMovimiento
{
    public class ListarMovimientoAD : IListarMovimientoAD
    {
        Contexto _elContexto;

        public ListarMovimientoAD()
        {
            _elContexto = new Contexto();
        }

        public List<MovimientoDto> ListarMovimiento()
        {
            List<MovimientoDto> laListaDeInventario = (from movimiento in _elContexto.MovimientoTabla

                                                       select new MovimientoDto
                                                       {
                                                           idMovimiento = movimiento.idMovimiento,
                                                           idProducto = movimiento.idProducto,
                                                           nombre = movimiento.nombre,
                                                           cantidad = movimiento.cantidad,
                                                           fecha = movimiento.fecha.ToString()


                                                       }).ToList();
            return laListaDeInventario;
        }
    }
}
