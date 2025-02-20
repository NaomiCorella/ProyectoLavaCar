using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.CrearNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloNomina.CrearNomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.CrearNomina
{
    public class CrearNominaLN : ICrearNominaLN
    {
        ICrearNominaAD _crearNominasAD;


    public CrearNominaLN()
    {

        _crearNominasAD = new CrearNominaAD();
    }


        public async Task<int> RegistrarNomina(NominaDto modelo)
    {
        int cantidadDeDatosAlmacenados = await _crearNominasAD.RegistrarNomina(ConvertirObjetoNominasTabla(modelo));
        return cantidadDeDatosAlmacenados;
    }



    private NominaTabla ConvertirObjetoNominasTabla(NominaDto laNomina)
    {


        return new NominaTabla()
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
            Estado = laNomina.Estado



        };
    }
}
}




