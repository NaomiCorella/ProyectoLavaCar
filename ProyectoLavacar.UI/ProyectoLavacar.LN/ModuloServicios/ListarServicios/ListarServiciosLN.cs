using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloServicios.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloServicios.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoLavacar.LN.ModuloServicios.ListarServicios.ListarServiciosLN;

namespace ProyectoLavacar.LN.ModuloServicios.ListarServicios
{
    public class ListarServiciosLN : IListarServiciosLN
    {

        IListarServiciosAD _listarServiciosAD;
        public ListarServiciosLN()
        {
            _listarServiciosAD = new ListarServiciosAD();
        }

        public List<ServiciosDto> ListarServicios()
        {
            List<ServiciosDto> laListadeServicios = _listarServiciosAD.ListarServicios();

            return laListadeServicios;
        }

        private List<ServiciosDto> ObtenerLaListaConvertida(List<ServiciosTabla> laListasDeServicios)
        {//chequear
            List<ServiciosDto> lalistaServicios = new List<ServiciosDto>();
            foreach (ServiciosTabla elServicio in laListasDeServicios)
            {
                lalistaServicios.Add(ConvertirObjetoServiciosDto(elServicio));
            }
            return lalistaServicios;
        }
        private ServiciosDto ConvertirObjetoServiciosDto(ServiciosTabla elServicio)
        {

            return new ServiciosDto
            {
                idServicio = elServicio.idServicio,
                costo = elServicio.costo,
                nombre = elServicio.nombre,
                descripcion = elServicio.descripcion,
                tiempoDuracion = elServicio.tiempoDuracion,
                estado = elServicio.estado,
                modalidad = elServicio.modalidad,
                precio = elServicio.precio
            };
        }
    }
}


