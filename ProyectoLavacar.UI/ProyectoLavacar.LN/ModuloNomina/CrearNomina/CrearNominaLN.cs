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


        public async Task<int> RegistrarNomina(NominaDto modelo, string id)
    {
        int cantidadDeDatosAlmacenados = await _crearNominasAD.RegistrarNomina(ConvertirObjetoNominasTabla(modelo,id));
        return cantidadDeDatosAlmacenados;
    }



    private NominaTabla ConvertirObjetoNominasTabla(NominaDto laNomina,string id)
    {


        return new NominaTabla()
        {
            IdNomina = laNomina.IdNomina,
            IdEmpleado = id,
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
            Estado = true,
            totalBono =0,
            totalDedu=0,
            deduccionCCSS=0,
            deduccionISR = 0,
            bonoHorasExtra = 0
              



    };
    }

     
}
}




