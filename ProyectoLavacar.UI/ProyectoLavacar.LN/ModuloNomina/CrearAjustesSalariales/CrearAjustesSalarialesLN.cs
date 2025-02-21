
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.CrearAjusteSalariales;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearAjusteSalariales;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloNomina.CrearAjusteSalariales;
using ProyectoLavacar.LN.ModuloNomina.EditarNomina;
using ProyectoLavacar.LN.ModuloNomina.ObtenerPorId;
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
        IObtenerPorIdLN _obtenerNomina;
        IEditarNominaLN _editarNomina;

        public CrearAjustesSalarialesLN()
        {
            _obtenerNomina = new ObtenerPorIdLN();
            _crearAjustesSalarialessAD = new CrearAjustesSalarialesAD();
            _editarNomina = new EditarNominaLN();
        }


        public async Task<int> RegistarAjusteSalariales(AjustesSalarialesDto modelo)
        {
            NominaDto nomin = Modificar(modelo);
            int cantidadDeDatosAlmacenados = await _crearAjustesSalarialessAD.RegistrarAjusteSalarial(ConvertirObjetoAjustesSalarialessTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }



        private AjustesSalarialesTabla ConvertirObjetoAjustesSalarialessTabla(AjustesSalarialesDto elAjustesSalariales)
        {


            return new AjustesSalarialesTabla()
            {
                IdAjusteSalarial = elAjustesSalariales.IdAjusteSalarial,
                IdNomina = elAjustesSalariales.IdNomina,
                Monto = elAjustesSalariales.Monto,
                Razon = elAjustesSalariales.Razon,
                tipo = elAjustesSalariales.tipo



            };
        }

        private  NominaDto Modificar(AjustesSalarialesDto elAjustesSalariales)
        {

            NominaDto laNomina = _obtenerNomina.Detalle(elAjustesSalariales.IdNomina);
            decimal nuevoTotalDedu = laNomina.totalDedu;
            decimal nuevoTotalBono = laNomina.totalBono;

            if (elAjustesSalariales.tipo == "Deduccion")
            {
                nuevoTotalDedu += elAjustesSalariales.Monto; 
            }
            else
            {
                nuevoTotalBono += elAjustesSalariales.Monto; 
            }

            NominaDto nominaModificada = new NominaDto()
            {
                IdNomina = laNomina.IdNomina,
                IdEmpleado = laNomina.IdEmpleado,
                SalarioBruto = laNomina.SalarioBruto,
                SalarioNeto = laNomina.SalarioNeto,
                HorasExtras = laNomina.HorasExtras,
                HorasDobles = laNomina.HorasDobles,
                HorasOrdinarias = laNomina.HorasOrdinarias,
                PeriodoDePago = laNomina.PeriodoDePago,
                FechaDePago = laNomina.FechaDePago,
                TipoDeContrato = laNomina.TipoDeContrato,
                DiasDispoVacaciones = laNomina.DiasDispoVacaciones,
                DiasUtiliVacaciones = laNomina.DiasUtiliVacaciones,
                Incapacidad = laNomina.Incapacidad,
                Estado = laNomina.Estado,
                totalBono = nuevoTotalBono, 
                totalDedu = nuevoTotalDedu  
            };

            _editarNomina.EditarNomina(nominaModificada);
            return nominaModificada;



        }
    }
}




