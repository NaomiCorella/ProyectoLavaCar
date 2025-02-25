using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ProcesarNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarRebajos;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ProcesarNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.LN.ModuloNomina.EditarNomina;
using ProyectoLavacar.LN.ModuloNomina.ListarRebajos;
using ProyectoLavacar.LN.ModuloNomina.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.ProcesarNomina
{
    public class ProcesarNominaLN :IProcesarNominaLN
    {
        IListarRebajosLN _listar;
        IEditarNominaLN _editarNomina;
        IObtenerPorIdLN _detallesNomina;
        public ProcesarNominaLN()
        {
            _listar = new ListarRebajosLN();
            _editarNomina = new EditarNominaLN();
            _detallesNomina = new ObtenerPorIdLN();
        }

        public NominaDto ProcesarNomina(int idNomina)
        {
            NominaDto laNomina = _detallesNomina.Detalle(idNomina);
            decimal impuestos = CalcularISR(idNomina);
            decimal rebajosPorSancion = rebajosSancion(idNomina);
            decimal rebajosPorDeuda = rebajosDeuda(idNomina);    
            decimal deducciones = laNomina.totalDedu;
            decimal seguro = CalcularSeguro(idNomina);
            decimal bonosHorasExtra = horasExtra(idNomina);
            decimal bonificaciones = laNomina.totalBono;

            decimal salario = (laNomina.SalarioBruto ?? 0m) + bonosHorasExtra + bonificaciones;
            decimal salarioNeto = salario - impuestos - rebajosPorDeuda - rebajosPorSancion - deducciones;


            NominaDto NominaNueva = new NominaDto
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
                totalBono = laNomina.totalBono,
                totalDedu = laNomina.totalDedu,

                deduccionCCSS = seguro,
                deduccionISR = impuestos,
                bonoHorasExtra = bonosHorasExtra,
                rebajosDeuda = rebajosPorDeuda,
                rebajosSancion = rebajosPorSancion
            };

            _editarNomina.EditarNomina(NominaNueva);
            return NominaNueva;
            
        }

 
        public decimal CalcularISR(int idNomina)
        {
            decimal impuesto = 0;
            NominaDto nomina = _detallesNomina.Detalle(idNomina);
            if (nomina.SalarioBruto >= 941000)
            {
                return impuesto;
            }
            if (nomina.SalarioBruto >= 1331000)
            {
                impuesto = (nomina.SalarioBruto ?? 0m) * 0.10m;
                return impuesto;
            }
            else
            {
                impuesto = (nomina.SalarioBruto ?? 0m) * 0.105m;
                return impuesto;
            }
              
        }
        public decimal CalcularSeguro(int idNomina)
        {
            decimal impuesto = 0;
            NominaDto nomina = _detallesNomina.Detalle(idNomina);
           
                impuesto = (nomina.SalarioBruto ?? 0m) * 0.105m;
                return impuesto;
            

        }

        public decimal horasExtra(int idNomina)
        {
            NominaDto nomina = _detallesNomina.Detalle(idNomina);
            decimal salarioBruto = nomina.SalarioBruto ?? 0m;
            decimal horasExtra = nomina.HorasExtras ?? 0m;//chequear tiene que ser int 
            decimal horasdobles = nomina.HorasDobles ?? 0m;//chequear tiene que ser int 

            decimal totalextra = horasExtra * (salarioBruto / 160) * 1.5m;
            decimal totaldobles = horasdobles * (salarioBruto / 160) * 2m;
            decimal bonosExtra = totalextra + totaldobles;
            return bonosExtra;
        }
        public decimal rebajosDeuda(int idNomina)
        {
            NominaDto nomina = _detallesNomina.Detalle(idNomina);
            List<RebajosDto> rebajos = _listar.Listar(idNomina);
            decimal rebajosTotalesDeuda = 0;
             foreach(RebajosDto rebajo in rebajos)
            {
                if (rebajo.tipo == "Deuda")
                {
                    rebajosTotalesDeuda += rebajo.Monto;
                }
            }
            return rebajosTotalesDeuda;
        }
        public decimal rebajosSancion(int idNomina)
        {
            NominaDto nomina = _detallesNomina.Detalle(idNomina);
            List<RebajosDto> rebajos = _listar.Listar(idNomina);
            decimal rebajosSancion = 0;
            foreach (RebajosDto rebajo in rebajos)
            {
                if (rebajo.tipo == "Sancion")
                {
                    rebajosSancion += rebajo.Monto;
                }
            }
            return rebajosSancion;
        }
    }
}
