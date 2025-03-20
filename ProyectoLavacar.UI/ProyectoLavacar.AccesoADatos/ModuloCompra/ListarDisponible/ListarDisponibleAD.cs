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

        public List<CompraAdminDto> ListarComprasCliente(string idCliente)
        {
            var lalistadeCompra = (from compra in _elContexto.CompraTabla
                                   join cliente in _elContexto.UsuariosTabla
                                       on compra.idCliente equals cliente.Id
                                   
                                   where compra.idCliente == idCliente
                                   select new CompraAdminDto
                                   {
                                       idCompra = compra.idCompra,
                                       idCliente = compra.idCliente,
                                    
                                       Total = compra.Total,
                                       Fecha = compra.fecha.ToString(),
                                       DescripcionServicio = compra.DescripcionServicio,
                                    
                                       Nombre = cliente.nombre,
                                       PrimerApellido = cliente.primer_apellido,
                                       SegundoApellido = cliente.segundo_apellido,
                                       Cedula = cliente.cedula,
                                       
                                      
                                      
                                   }).ToList();

            return lalistadeCompra;
        }
    }
}
