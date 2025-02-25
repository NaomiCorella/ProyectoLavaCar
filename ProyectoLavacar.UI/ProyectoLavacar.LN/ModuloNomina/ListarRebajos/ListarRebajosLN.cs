using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarAjustes;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarRebajos;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarAjustes;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarRebajos;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.AccesoADatos.ModuloNomina.ListarAjustes;
using ProyectoLavacar.AccesoADatos.ModuloNomina.ListarRebajos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.ListarRebajos
{
    public class ListarRebajosLN :IListarRebajosLN
    {
        IListarRebajosAD _listarAjustesAD;

        public ListarRebajosLN()
        {
            _listarAjustesAD = new ListarRebajosAD();
        }


        public List<RebajosDto> Listar(int idNomina)
        {
            List<RebajosDto> laListaDeNominasEmpleado = _listarAjustesAD.Listar(idNomina);
            return laListaDeNominasEmpleado;
        }
    }
}
