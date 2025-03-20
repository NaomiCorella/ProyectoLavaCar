using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.ListarDetalles;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloCompra.ListarDetalles
{
    public class ListarDetallesDeServicioAD :IListarDetallesDeServiciosAD
    {
        Contexto _elcontexto;

        public ListarDetallesDeServicioAD()
        {
            _elcontexto = new Contexto();
        }

        public List<CompraServiciosDto> ListarCompra(Guid idCompra)
        {
            List<CompraServiciosDto> listaDeCompra = (from compraservicio in _elcontexto.CompraServiciosTabla
                                                      join laCompra in _elcontexto.CompraTabla
                                                      on compraservicio.idCompra equals laCompra.idCompra
                                                      where compraservicio.idCompra == idCompra  // Filtrar por el parámetro
                                                      select new CompraServiciosDto
                                                      {
                                                          idCompra = compraservicio.idCompra,
                                                          idServicio = compraservicio.idServicio,
                                                          idCompraServicios = compraservicio.idCompraServicios
                                                      }).ToList();

            return listaDeCompra;
        }

    }
}
