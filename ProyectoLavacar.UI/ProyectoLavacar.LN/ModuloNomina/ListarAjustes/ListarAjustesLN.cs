using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarAjustes;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarGeneral;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarAjustes;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.AccesoADatos.ModuloNomina.ListarAjustes;
using ProyectoLavacar.AccesoADatos.ModuloNomina.ListarGeneral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.ListarAjustes
{
   public  class ListarAjustesLN:IListarAjustesLN
    {
        IListarAjustesAD _listarAjustesAD;

        public ListarAjustesLN()
        {
            _listarAjustesAD = new ListarAjustesAD();
        }


        public List<AjustesSalarialesDto> ListarTodo()
        {
            List<AjustesSalarialesDto> laListaDeNominasEmpleado = _listarAjustesAD.ListarTodo();
            return laListaDeNominasEmpleado;
        }
    }
}
