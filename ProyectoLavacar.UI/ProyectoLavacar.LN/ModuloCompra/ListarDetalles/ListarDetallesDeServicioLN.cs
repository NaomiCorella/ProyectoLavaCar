using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.ListarDetalles;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using ProyectoLavacar.AccesoADatos.ModuloCompra.Listar;
using ProyectoLavacar.AccesoADatos.ModuloCompra.ListarDetalles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloCompra.ListarDetalles
{
    public class ListarDetallesDeServicioLN : IListarDetallesDeServiciosLN
    {
        IListarDetallesDeServiciosAD _listarCompraAD;
        public ListarDetallesDeServicioLN()
        {
            _listarCompraAD = new ListarDetallesDeServicioAD();
        }

        public List<CompraServiciosDto> ListarCompra(Guid idCompra)
        {
            List<CompraServiciosDto> laListadeCompra = _listarCompraAD.ListarCompra(idCompra);

            return laListadeCompra;
        }
    }
}
