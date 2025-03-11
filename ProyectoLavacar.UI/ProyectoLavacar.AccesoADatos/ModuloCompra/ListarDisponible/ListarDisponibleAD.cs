using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.ListarDisponibles;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoLavacar.AccesoADatos.ModuloCompra.ListarDisponible
{
    public class ListarDisponibleAD : IListarDisponiblesAD
    {
         Contexto _elContexto;

        public ListarDisponibleAD()
        {
            _elContexto = new Contexto();
        }

        public List<CompraCompletaDto> ListarComprasCliente(string idCliente)
        {
            var lalistadeCompra = (from compra in _elContexto.CompraTabla
                                   join cliente in _elContexto.UsuariosTabla
                                       on compra.idCliente equals cliente.Id
                                   join servicio in _elContexto.ServiciosTabla
                                       on compra.idServicio equals servicio.idServicio
                                   where compra.idCliente == idCliente
                                   select new CompraCompletaDto
                                   {
                                       idCompra = compra.idCompra,
                                       idCliente = compra.idCliente,
                                       idServicio = compra.idServicio,
                                       Total = compra.Total,
                                       Fecha = compra.fecha.ToString(),
                                       DescripcionServicio = compra.DescripcionServicio,
                                       Estado = compra.Estado,
                                       Nombre = cliente.nombre,
                                       PrimerApellido = cliente.primer_apellido,
                                       SegundoApellido = cliente.segundo_apellido,
                                       Cedula = cliente.cedula,
                                       
                                       nombre = servicio.nombre,
                                       costo = servicio.costo
                                      
                                   }).ToList();

            return lalistadeCompra;
        }
    }
}
