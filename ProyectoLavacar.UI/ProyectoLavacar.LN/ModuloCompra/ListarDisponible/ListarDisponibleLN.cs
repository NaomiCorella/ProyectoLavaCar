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

        public List<CompraCompletaDto> Listar(string idCliente)
        {
            List<CompraCompletaDto> laListaDeActividadesPersona = _listarDisponiblesComprasAD.ListarComprasCliente(idCliente);

            return laListaDeActividadesPersona;
        }

        private List<CompraDto> ObtenerLaListaConvertida(List<CompraTabla> lalistadeCompras, List<UsuariosTabla> lalistadeClientes)
        {
            List<CompraDto> laListaDeActividades = new List<CompraDto>();

            var joinLista = from Compra in lalistadeCompras
                            join clientes in lalistadeClientes on Compra.idCliente equals clientes.Id
                            select new { Compra, clientes };

            foreach (var item in joinLista)
            {
                laListaDeActividades.Add(ConvertirObjetoServiciosDto(item.Compra, item.clientes));
            }

            return laListaDeActividades;
        }


        private CompraDto ConvertirObjetoServiciosDto(CompraTabla Compra, UsuariosTabla clientes)
        {

            return new CompraDto
            {
                idCompra = Compra.idCompra,
                idCliente = clientes.Id,
        
                DescripcionServicio = Compra.DescripcionServicio,
                fecha = Compra.fecha.ToString(),
                Total = Compra.Total,
                Estado = Compra.Estado



            };
        }
    }
}


