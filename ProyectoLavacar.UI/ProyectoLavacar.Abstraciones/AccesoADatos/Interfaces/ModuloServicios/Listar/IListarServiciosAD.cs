using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloServicios.Listar
{
    public interface IListarServiciosAD
    {
  List<ServiciosDto> ListarServicios();
    }
}
