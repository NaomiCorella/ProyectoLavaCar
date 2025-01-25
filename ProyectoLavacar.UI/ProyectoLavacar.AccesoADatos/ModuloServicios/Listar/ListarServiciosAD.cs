using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloServicios.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloServicios.Listar
{
    public class ListarServiciosAD : IListarServiciosAD
    {
        Contexto _elContexto;

        public ListarServiciosAD()
        {
            _elContexto = new Contexto();
        }

        public List<ServiciosDto> ListarServicios()
        {
            List<ServiciosDto> lalistadeServicios = (from elServicio in _elContexto.ServiciosTabla
                                                     select new ServiciosDto
                                                    {
                                                        idServicio = elServicio.idServicio,
                                                        costo = elServicio.costo,
                                                        nombre= elServicio.nombre,
                                                        descripcion = elServicio.descripcion,
                                                        tiempoDuracion = elServicio.tiempoDuracion,
                                                        estado = elServicio .estado
                                                              
                                                      }).ToList();
            return lalistadeServicios;
        }
    }
}



