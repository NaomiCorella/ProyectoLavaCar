using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.ListarDisponibles;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.ListarDisponibles;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloCompra.ListarDisponible;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloCompra.ListarDisponible
{
    public class ListarDisponibleLN : IListarDisponibleLN
    {
        IListarDisponiblesAD _listarDisponiblesComprasAD;
        public ListarDisponibleLN()
        {
            _listarDisponiblesComprasAD = new ListarDisponibleAD();
        }

        public List<CompraAdminDto> Listar(string idCliente)
        {
            List<CompraAdminDto> laListaDeActividadesPersona = _listarDisponiblesComprasAD.ListarComprasCliente(idCliente);

            return laListaDeActividadesPersona;
        }

      


       
    }
}


