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
    public class CrearRebajoLN : ICrearRebajoLN
    {
        ICrearRebajoAD _crearAccidente;
        ICrearAjusteSalarialesLN _crearAjustes;
        IObtenerPorIdLN _obtenerNomina;
        public CrearRebajoLN()
        {
            _crearAccidente = new CrearRebajoAD();
            _crearAjustes = new CrearAjustesSalarialesLN();
            _obtenerNomina = new ObtenerPorIdLN();
        }

        public async Task<int> RegistroTramites(RebajosDto modelo)
        {

            int cantidadDeDatosAlmacenados = await _crearAccidente.RegistrarTramites(ConvertirObjetoTramitessTabla(modelo));
            
            return cantidadDeDatosAlmacenados;
        }
        private RebajosTabla ConvertirObjetoTramitessTabla(RebajosDto elAccidente)
        {


            return new RebajosTabla()
            {
                idRebajo = elAccidente.idRebajo,
                IdNomina = elAccidente.IdNomina,
                Monto = elAccidente.Monto,
                Razon = elAccidente.Razon,
                tipo = elAccidente.tipo
                


            };
        }
    }
}
