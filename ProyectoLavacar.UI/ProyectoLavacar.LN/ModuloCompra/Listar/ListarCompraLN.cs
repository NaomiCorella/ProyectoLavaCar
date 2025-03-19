using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using ProyectoLavacar.AccesoADatos.ModuloCompra.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloCompra.Listar
{
    public class ListarCompraLN : IListarLN
    {
        IListarCompraAD _listarCompraAD;
        public ListarCompraLN()
        {
            _listarCompraAD = new ListarCompraAD();
        }

        public List<CompraDto> ListarCompra()
        {
            List<CompraDto> laListadeCompra = _listarCompraAD.ListarCompra();
            return laListadeCompra;
        }
    }
}


