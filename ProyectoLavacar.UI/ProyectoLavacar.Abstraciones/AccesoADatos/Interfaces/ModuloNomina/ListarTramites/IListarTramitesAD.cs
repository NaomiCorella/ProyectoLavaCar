using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarTramites
{
    public interface IListarTramitesAD
    {
        List<TramitesDto> ListarTodo(int idNomina);
    }
}
