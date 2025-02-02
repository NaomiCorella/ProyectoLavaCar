using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEmpleados.Listar;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloEmpleados.Listar;
using ProyectoLavacar.AccesoADatos.ModuloInventario.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloInventario.Listar
{
    public class ListarInventarioLN : IListarInventarioLN
    {
        IListarInventarioAD _listarInventarioAD;

        public ListarInventarioLN()
        {
            _listarInventarioAD = new ListarInventarioAD();
        }


        public List<InventarioDto> ListarInventario()
        {
            List<InventarioDto> laListasDeEmpleados = _listarInventarioAD.ListarInventario();
            return laListasDeEmpleados;
        }

        private List<InventarioDto> ObtenerLaListaConvertida(List<InventarioTabla> laListasDeInventario)
        {
            List<InventarioDto> laListaDeInventario = new List<InventarioDto>();
            foreach (InventarioTabla elInventario in laListasDeInventario)
            {
                laListaDeInventario.Add(ConvertirObjetoInventarioDto(elInventario));
            }
            return laListaDeInventario;

        }

        private InventarioDto ConvertirObjetoInventarioDto(InventarioTabla elInventario)
        {
            if (elInventario == null)
            {

                throw new ArgumentNullException(nameof(elInventario), "El objeto  no puede ser null.");
            }
            return new InventarioDto
            {
                nombre = elInventario.nombre,
                categoria = elInventario.categoria,
                cantidadDisponible = elInventario.cantidadDisponible,
                precioUnitario = elInventario.precioUnitario,

                estado = elInventario.estado,
                idInventario = elInventario.idInventario,
            };
        }
    }
}
