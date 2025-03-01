using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarAjustes;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarTramites;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.AccesoADatos.ModuloNomina.ListarAjustes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.ListarTramites
{
    public class ListarTramitesLN :IListarTramitesLN
    {
        IListarTramitesAD _listartramitesAD;

        public ListarTramitesLN()
        {
            _listartramitesAD = new ListarTramitesAD();
        }


        public List<TramitesDto> ListarTodo(int idNomina)
        {
            List<TramitesDto> laListaDeNominasEmpleado = _listartramitesAD.ListarTodo(idNomina);
            return laListaDeNominasEmpleado;
        }
    }
}
