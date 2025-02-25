using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.DetallesTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.DetallesTramites;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloNomina.DetalleTramite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.DetallesTramites
{
   public class DetallesTramitesLN :IDetallesTramitesLN
    {
        IDetallesTramitesAD _obtenerPorIdNominaAD;
        public DetallesTramitesLN()
        {
            _obtenerPorIdNominaAD = new DetalleTramiteAD();
        }
        public TramitesDto Detalle(int idTramite)
        {
            TramitesTabla nominaEnBaseDeDatos = _obtenerPorIdNominaAD.Detalle(idTramite);
            TramitesDto nominaAMostrar = ConvertirANominaAMostrar(nominaEnBaseDeDatos);
            return nominaAMostrar;
        }
        private TramitesDto ConvertirANominaAMostrar(TramitesTabla tramite)
        {

            return new TramitesDto
            {
                IdTramite = tramite.IdTramite,
                IdNomina = tramite.IdNomina,
                duracion = tramite.duracion,
                FechaInicio = tramite.FechaInicio,
                Razon = tramite.Razon,
                tipo = tramite.tipo
            };
        }
    }
}

