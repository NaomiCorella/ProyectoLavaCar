using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.DetalleCompraCompleto;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloCompra.DetalleCompraCompleta
{
    public class DetalleCompraCompletaAD : IDetalleCompraCompletaAD
    {
        Contexto _elcontexto;

        public DetalleCompraCompletaAD()
        {
            _elcontexto = new Contexto();
        }
        public CompraCompletaDto Detalle(int idCompra)
        {
            var CompraCompleta = (from compra in _elcontexto.CompraTabla
                                  join elCliente in _elcontexto.UsuariosTabla
                                  on compra.idCliente equals elCliente.Id
                                  join servicio in _elcontexto.ServiciosTabla
                                  on compra.idServicio equals servicio.idServicio
                                  where compra.idCompra == idCompra 
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

                                  }).FirstOrDefault(); 

            return CompraCompleta; 
        }



    }
}

