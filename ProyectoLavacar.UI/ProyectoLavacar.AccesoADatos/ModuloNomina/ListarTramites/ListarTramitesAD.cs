using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarTramites;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.ListarAjustes
{
    public class ListarTramitesAD: IListarTramitesAD
    {
        Contexto _elContexto;

        public ListarTramitesAD()
        {
            _elContexto = new Contexto();
        }

        public List<TramitesDto> ListarTodo(int idNomina)
        {
            List<TramitesDto> lalistaGeneral = _elContexto.TramitesTabla
     .Where(tramite => tramite.IdNomina == idNomina) // Filtra en lugar de hacer JOIN
     .Select(tramite => new TramitesDto
     {
         IdTramite = tramite.IdTramite,
         IdNomina = tramite.IdNomina,
         duracion = tramite.duracion,
         FechaInicio = tramite.FechaInicio,
         Razon = tramite.Razon,
         tipo = tramite.tipo,
         estado = tramite.estado,
         aseguradora = tramite.aseguradora
     })
     .ToList();


            return lalistaGeneral;
        }
    }
}
