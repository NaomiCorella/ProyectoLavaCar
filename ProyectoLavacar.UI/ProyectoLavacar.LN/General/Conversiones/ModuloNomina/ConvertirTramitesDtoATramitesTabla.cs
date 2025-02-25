using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.General.Conversiones.ModuloNomina
{
    public class ConvertirTramitesDtoATramitesTabla : IConvertirTramitesDtoATramitesTabla
    {
        public TramitesTabla ConvertirTramites(TramitesDto elTramites)
        {
            return new TramitesTabla
            {
                IdTramite = elTramites.IdTramite,
                //IdNomina = elTramites.IdNomina,
                //FechaInicio = elTramites.FechaInicio,
                duracion = elTramites.duracion,
                estado = elTramites.estado
                //Razon = elTramites.Razon,
                //tipo = elTramites.tipo


            };
        }
    }
} 

