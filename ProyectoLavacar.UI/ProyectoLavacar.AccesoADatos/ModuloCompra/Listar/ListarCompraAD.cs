using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;

namespace ProyectoLavacar.AccesoADatos.ModuloCompra.Listar
{
    public class ListarCompraAD : IListarCompraAD
    {
        Contexto _elcontexto;

        public ListarCompraAD()
        {
            _elcontexto = new Contexto();
        }

        public List<CompraCompletaDto> ListarCompra()
        {
            List<CompraCompletaDto> listaDeCompra = (from compra in _elcontexto.CompraTabla
                                                     join elCliente in _elcontexto.UsuariosTabla
                                                     on compra.idCliente equals elCliente.Id
                                                     join servicio in _elcontexto.ServiciosTabla
                                                     on compra.idServicio equals servicio.idServicio
                                                     select new CompraCompletaDto
                                                     {
                                                         idCompra = compra.idCompra,
                                                         idCliente = compra.idCliente,
                                                         idServicio = compra.idServicio,

                                                         Total = compra.Total,
                                                         Fecha = compra.fecha.ToString(), 
                                                         DescripcionServicio = compra.DescripcionServicio,
                                                         Estado = compra.Estado,

                                                         Nombre = elCliente.nombre,
                                                         PrimerApellido = elCliente.primer_apellido,
                                                         SegundoApellido = elCliente.segundo_apellido,
                                                         Cedula = elCliente.cedula,

                                                         nombre = servicio.nombre,
                                                         costo = servicio.costo


                                                     }).ToList();

            return listaDeCompra;
        }
    }
}
