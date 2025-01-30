using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReseñas.Listar;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ListarTodo;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloReseñas.Listar;
using ProyectoLavacar.AccesoADatos.ModuloReservas.ListarTodo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloReseñas.Listar
{
    public class ListarReseniaLN : IListarReseniaLN
    {
        IListarReseniaAD _listarReseniaAD;
        public ListarReseniaLN()
        {
            _listarReseniaAD = new ListarReseniaAD();
        }

        public List<ReseniaDto> ListarResenia()
        {
            List<ReseniaDto> laListadeServicios = _listarReseniaAD.ListarResenias();

            return laListadeServicios;
        }

        private List<ReseniaDto> ObtenerLaListaConvertida(List<ReseniasTabla> lalistaderesenias)
        {//chequear
            List<ReseniaDto> lalistaServicios = new List<ReseniaDto>();
            foreach (ReseniasTabla elServicio in lalistaderesenias)
            {
                lalistaServicios.Add(ConvertirObjetoServiciosDto(elServicio));
            }
            return lalistaServicios;
        }
        private ReseniaDto ConvertirObjetoServiciosDto(ReseniasTabla laResenia)
        {

            return new ReseniaDto
            {
                idResenia = laResenia.idResenia,
                idCliente = laResenia.idCliente,
                idServicio = laResenia.idServicio,
                fecha = laResenia.fecha.ToString(),
                calificacion = laResenia.calificacion,
                comentarios = laResenia.comentarios,
                estado = laResenia.estado

            };
        }
    }
}
