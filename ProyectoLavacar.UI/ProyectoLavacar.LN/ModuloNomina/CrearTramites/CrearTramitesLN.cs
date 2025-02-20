using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEmpleados.Crear;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.CrearTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearTramites;
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloEmpleados.Crear;
using ProyectoLavacar.AccesoADatos.ModuloNomina.CrearTramites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.CrearTramites
{
    public class CrearTramitesLN : ICrearTramitesLN
    {
        ICrearTramitesAD _crearTramitessAD;


        public CrearTramitesLN()
        {

            _crearTramitessAD = new CrearTramitesAD();
        }
        public async Task<int> RegistroTramites(TramitesDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _crearTramitessAD.RegistrarTramites(ConvertirObjetoTramitessTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }



        private TramitesTabla ConvertirObjetoTramitessTabla(TramitesDto elTramites)
        {


            return new TramitesTabla()
            {
                IdTramite = elTramites.IdTramite,
                IdEmpleado = elTramites.IdEmpleado,
                FechaInicio = elTramites.FechaInicio,
                FechaFin = elTramites.FechaFin,
                Razon = elTramites.Razon


            };
        }
    }
}



