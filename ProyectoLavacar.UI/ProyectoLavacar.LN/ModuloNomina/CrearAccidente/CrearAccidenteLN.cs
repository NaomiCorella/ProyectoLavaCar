using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.CrearAccidente;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearAccidente;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearAjusteSalariales;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloNomina.CrearAccidente;
using ProyectoLavacar.LN.ModuloAjustesSalariales.CrearAjustesSalariales;
using ProyectoLavacar.LN.ModuloNomina.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.CrearAccidente
{
    public class CrearAccidenteLN : ICrearAccidenteLN
    {
        ICrearAccidenteAD _crearAccidente;
        ICrearAjusteSalarialesLN _crearAjustes;
        IObtenerPorIdLN _obtenerNomina;
        public CrearAccidenteLN()
        {
            _crearAccidente = new CrearAccidenteAD();
            _crearAjustes = new CrearAjustesSalarialesLN();
            _obtenerNomina = new ObtenerPorIdLN();
        }

        public async Task<int> RegistroTramites(AccidenteDto modelo)
        {

            int cantidadDeDatosAlmacenados = await _crearAccidente.RegistrarTramites(ConvertirObjetoTramitessTabla(modelo));
            NominaDto nomina = _obtenerNomina.Detalle(modelo.IdNomina);
            AjustesSalarialesDto ajuste = new AjustesSalarialesDto()
            {
                IdAjusteSalarial = 0,
                IdNomina = modelo.IdNomina,
                Monto = (nomina.SalarioNeto / 30m) * modelo.duracion,
                Razon = modelo.Razon,
                tipo = "Bonificacion"
            };
            int cantidad = await _crearAjustes.RegistarAjusteSalariales(ajuste);
            return cantidadDeDatosAlmacenados;
        }
        private AccidenteTabla ConvertirObjetoTramitessTabla(AccidenteDto elAccidente)
        {


            return new AccidenteTabla()
            {
                idAccidente = elAccidente.idAccidente,
                IdNomina = elAccidente.IdNomina,
                FechaInicio = elAccidente.FechaInicio,
                duracion = elAccidente.duracion,
                Razon = elAccidente.Razon,
                tipo = elAccidente.tipo

            };
        }
    }
}
