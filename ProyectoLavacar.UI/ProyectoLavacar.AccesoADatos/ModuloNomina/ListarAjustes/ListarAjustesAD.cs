using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarAjustes;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.ListarAjustes
{
    public class ListarAjustesAD : IListarAjustesAD
    {
        Contexto _elContexto;

        public ListarAjustesAD()
        {
            _elContexto = new Contexto();
        }

        public List<AjustesSalarialesDto> ListarTodo()
        {
            List<AjustesSalarialesDto> lalistaGeneral = (from ajustes in _elContexto.AjustesSalarialesTabla
                                                         join nomina in _elContexto.NominaTabla
                                                         on ajustes.IdNomina equals nomina.IdNomina
                                                         select new AjustesSalarialesDto
                                                         {
                                                             IdAjusteSalarial = ajustes.IdAjusteSalarial,
                                                             IdNomina = ajustes.IdNomina,
                                                             Monto = ajustes.Monto,
                                                             Razon = ajustes.Razon
                                                         })
                                              .Distinct() // Elimina duplicados
                                              .ToList();

            return lalistaGeneral;
        }
    }
}

