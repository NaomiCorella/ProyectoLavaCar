using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarRebajos;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.ListarRebajos
{
    public class ListarRebajosAD : IListarRebajosAD
    {
        Contexto _elContexto;

        public ListarRebajosAD()
        {
            _elContexto = new Contexto();
        }

        public List<RebajosDto> Listar(int idNomina)
        {
            List<RebajosDto> lalistaGeneral = (from rebajos in _elContexto.RebajosTabla
                                                         join nomina in _elContexto.NominaTabla
                                               on rebajos.IdNomina equals idNomina

                                                         select new RebajosDto
                                                         {
                                                             idRebajo = rebajos.idRebajo,
                                                             IdNomina = rebajos.IdNomina,
                                                             Monto = rebajos.Monto,
                                                             Razon =    rebajos.Razon,
                                                             tipo = rebajos.tipo
                                                             

                                                         }).ToList();

            return lalistaGeneral;
        }
    }
}

