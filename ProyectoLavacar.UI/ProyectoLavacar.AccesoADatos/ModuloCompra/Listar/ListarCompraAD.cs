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

        public List<CompraAdminDto> ListarCompra()
        {
            List<CompraAdminDto> listaDeCompra = (from compra in _elcontexto.CompraTabla
                                                     join elCliente in _elcontexto.UsuariosTabla
                                                     on compra.idCliente equals elCliente.Id
                                                     select new CompraAdminDto
                                                     {
                                                         idCompra = compra.idCompra,
                                                         idCliente = compra.idCliente,
                                                         Nombre = elCliente.nombre,
                                                         PrimerApellido = elCliente.primer_apellido,
                                                         Cedula = elCliente.cedula,
                                                         Fecha = compra.fecha.ToString(),  
                                                         Total = compra.Total,
                                                         DescripcionServicio = compra.DescripcionServicio,
                                                     }).ToList();

            return listaDeCompra;
        }
    }
}
