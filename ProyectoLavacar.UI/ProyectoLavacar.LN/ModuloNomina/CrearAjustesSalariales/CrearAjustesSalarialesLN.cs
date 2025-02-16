
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.CrearAjusteSalariales;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearAjusteSalariales;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloNomina.CrearAjusteSalariales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloAjustesSalariales.CrearAjustesSalariales
{
    public class CrearAjustesSalarialesLN : ICrearAjusteSalarialesLN
    {
        ICrearAjusteSalarialesAD _crearAjustesSalarialessAD;


        public CrearAjustesSalarialesLN()
        {

            _crearAjustesSalarialessAD = new CrearAjustesSalarialesAD();
        }


        public async Task<int> RegistarAjusteSalariales(AjustesSalarialesDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _crearAjustesSalarialessAD.RegistrarAjusteSalarial(ConvertirObjetoAjustesSalarialessTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }



        private AjustesSalarialesTabla ConvertirObjetoAjustesSalarialessTabla(AjustesSalarialesDto elAjustesSalariales)
        {


            return new AjustesSalarialesTabla()
            {
                IdAjusteSalarial = elAjustesSalariales.IdAjusteSalarial,
                IdEmpleado = elAjustesSalariales.IdEmpleado,
                Monto = elAjustesSalariales.Monto,
                Razon = elAjustesSalariales.Razon



            };
        }
    }
}




