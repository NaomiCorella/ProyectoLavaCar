using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEmpleados.Crear;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.CrearTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearAjusteSalariales;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloEmpleados.Crear;
using ProyectoLavacar.AccesoADatos.ModuloNomina.CrearAjusteSalariales;
using ProyectoLavacar.AccesoADatos.ModuloNomina.CrearTramites;
using ProyectoLavacar.LN.ModuloAjustesSalariales.CrearAjustesSalariales;
using ProyectoLavacar.LN.ModuloNomina.EditarNomina;
using ProyectoLavacar.LN.ModuloNomina.ObtenerPorId;
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
        IObtenerPorIdLN _obtenerNomina;
        IEditarNominaLN _editarNomina;
        ICrearAjusteSalarialesLN _crearAjusteSalarial;
        public CrearTramitesLN()
        {
            _obtenerNomina = new ObtenerPorIdLN();
            _editarNomina = new EditarNominaLN();
            _crearTramitessAD = new CrearTramitesAD();
            _crearAjusteSalarial = new CrearAjustesSalarialesLN();
        }
        public async Task<int> RegistroTramites(TramitesDto modelo)
        {
            decimal nomina = Validacion(modelo);
            int cantidadDeDatosAlmacenados = await _crearTramitessAD.RegistrarTramites(ConvertirObjetoTramitessTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }



        private TramitesTabla ConvertirObjetoTramitessTabla(TramitesDto elTramites)
        {


            return new TramitesTabla()
            {
                IdTramite = elTramites.IdTramite,
                IdNomina = elTramites.IdNomina,
                FechaInicio = elTramites.FechaInicio,
                FechaFin = elTramites.FechaFin,
                Razon = elTramites.Razon,
                tipo = elTramites.tipo


            };
        }


        private decimal Validacion(TramitesDto elTramites)
        {

            if (elTramites.tipo == "Incapacidad")
            {
                decimal deduccion = incapacidad(elTramites);
                return deduccion;
            }
            else
            {
                return 0;
            }
          
        }

        private decimal incapacidad(TramitesDto elTramites)
        {
            NominaDto nomina = _obtenerNomina.Detalle(elTramites.IdNomina);
            DateTime fechaInicio = elTramites.FechaInicio;
            DateTime fechaFin = elTramites.FechaFin;
            int diasDiferencia = Math.Abs((fechaInicio - fechaFin).Days);
            decimal deduccion = (nomina.SalarioNeto / 30m) * diasDiferencia;
            AjustesSalarialesDto ajuste = new AjustesSalarialesDto()
            {
                IdAjusteSalarial= 0,
                IdNomina=elTramites.IdNomina,
                Monto=deduccion,
                Razon="Ingreso de capacidad",
                tipo="Deduccion"
            };
            _crearAjusteSalarial.RegistarAjusteSalariales(ajuste);
            return deduccion;

        }

    }
}



