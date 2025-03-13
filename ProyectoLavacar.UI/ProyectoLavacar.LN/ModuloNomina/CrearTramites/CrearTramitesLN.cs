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
using System.Net;
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
            if (nomina != 0)
            {
                int cantidadDeDatosAlmacenados = await _crearTramitessAD.RegistrarTramites(ConvertirObjetoTramitessTabla(modelo));
                return cantidadDeDatosAlmacenados;
            }
            else
            {
                return 0;
            }

           
        }

        private TramitesTabla ConvertirObjetoTramitessTabla(TramitesDto elTramites)
        {


            return new TramitesTabla()
            {
                IdTramite = elTramites.IdTramite,
                IdNomina = elTramites.IdNomina,
                FechaInicio = elTramites.FechaInicio,
                duracion = elTramites.duracion,
                Razon = elTramites.Razon,
                tipo = elTramites.tipo,
                estado= elTramites.estado,
                aseguradora = elTramites.aseguradora



            };
        }

        private decimal Validacion(TramitesDto elTramites)
        {

            if (elTramites.tipo == "Incapacidad")
            {
                if(elTramites.aseguradora == "CSSS")
                {
                    decimal csss = CSSS(elTramites);
                    if (csss != 0)
                    {
                        decimal cantidad = incapacidad(elTramites, csss);
                        return 1;
                    }
                }
                else
                {
                    decimal ins = INS(elTramites);
                    if (ins != 0)
                    {
                        decimal cantidad = incapacidad(elTramites, ins);
                        return 1;
                    }
                }

              
            }
            if(elTramites.tipo =="Vacaciones")
            {


            decimal vacacio = vacaciones(elTramites);
                if (vacacio == 0)
                {
                    return 0;
                }
                return vacacio;
            }
            else
            {
                decimal bonificacion = Accidente(elTramites);
                return bonificacion;
            }
          
        }

        private decimal CSSS(TramitesDto eltramites)
        {
            NominaDto nomina = _obtenerNomina.Detalle(eltramites.IdNomina);
            int duracion = eltramites.duracion;
            decimal salarioNeto = nomina.SalarioNeto;
            decimal deduccion = 0;
            decimal salarioBase = 250430m;
            decimal salarioPromedioFaseTerminal = salarioNeto; 
            decimal subsidioTotal = 0;
            switch (eltramites.Razon)
            {
                case "Enfermedad":
                   
                    decimal salarioPromedio = salarioNeto; 
                    decimal subsidioDiario = (salarioPromedio * 0.15m * 4) / 30;
                    if (duracion <= 3)
                    {
                        deduccion = subsidioDiario * duracion;
                    }
                    else
                    {
                        deduccion = subsidioDiario * 3; 
                    }
                    return deduccion;
                case "LicenciasDeMaternidad":
                    decimal salarioPromedioTresMeses = salarioNeto; 
                    decimal salarioDiario = salarioPromedioTresMeses / 30;
                    decimal salarioPatrono = salarioDiario * 0.5m * duracion;
                    deduccion = salarioPatrono;
                    return deduccion;
                case "LicenciasDeFaseTerminal":
                     salarioPromedioFaseTerminal = salarioNeto; 
                     subsidioTotal = 0;

                    if (salarioPromedioFaseTerminal <= 2 * salarioBase)
                    {
                        subsidioTotal = salarioPromedioFaseTerminal * duracion;
                    }
                    else if (salarioPromedioFaseTerminal <= 3 * salarioBase)
                    {
                        subsidioTotal = (2 * salarioBase * duracion) + ((salarioPromedioFaseTerminal - 2 * salarioBase) * 0.8m * duracion);
                    }
                    else
                    {
                        subsidioTotal = (2 * salarioBase * duracion) + (salarioBase * 0.8m * duracion) + ((salarioPromedioFaseTerminal - 3 * salarioBase) * 0.6m * duracion);
                    }

                    deduccion = subsidioTotal;
                    return deduccion;
                case "LicenciaDeCuido":
                     salarioPromedioFaseTerminal = salarioNeto; 
                     subsidioTotal = 0;

                    if (salarioPromedioFaseTerminal <= 2 * salarioBase)
                    {
                        subsidioTotal = salarioPromedioFaseTerminal * duracion;
                    }
                    else if (salarioPromedioFaseTerminal <= 3 * salarioBase)
                    {
                        subsidioTotal = (2 * salarioBase * duracion) + ((salarioPromedioFaseTerminal - 2 * salarioBase) * 0.8m * duracion);
                    }
                    else
                    {
                        subsidioTotal = (2 * salarioBase * duracion) + (salarioBase * 0.8m * duracion) + ((salarioPromedioFaseTerminal - 3 * salarioBase) * 0.6m * duracion);
                    }

                    deduccion = subsidioTotal;
                    return deduccion;
                case "LicenciaExtraordinaria":
                     salarioPromedioFaseTerminal = salarioNeto; 
                     subsidioTotal = 0;

                    if (salarioPromedioFaseTerminal <= 2 * salarioBase)
                    {
                        subsidioTotal = salarioPromedioFaseTerminal * duracion;
                    }
                    else if (salarioPromedioFaseTerminal <= 3 * salarioBase)
                    {
                        subsidioTotal = (2 * salarioBase * duracion) + ((salarioPromedioFaseTerminal - 2 * salarioBase) * 0.8m * duracion);
                    }
                    else
                    {
                        subsidioTotal = (2 * salarioBase * duracion) + (salarioBase * 0.8m * duracion) + ((salarioPromedioFaseTerminal - 3 * salarioBase) * 0.6m * duracion);
                    }

                    deduccion = subsidioTotal;
                    return deduccion;
                case "AccidentesTransito":
                     salarioPromedioFaseTerminal = salarioNeto; 
                     subsidioTotal = 0;

                    if (salarioPromedioFaseTerminal <= 2 * salarioBase)
                    {
                        subsidioTotal = salarioPromedioFaseTerminal * duracion;
                    }
                    else if (salarioPromedioFaseTerminal <= 3 * salarioBase)
                    {
                        subsidioTotal = (2 * salarioBase * duracion) + ((salarioPromedioFaseTerminal - 2 * salarioBase) * 0.8m * duracion);
                    }
                    else
                    {
                        subsidioTotal = (2 * salarioBase * duracion) + (salarioBase * 0.8m * duracion) + ((salarioPromedioFaseTerminal - 3 * salarioBase) * 0.6m * duracion);
                    }

                    deduccion = subsidioTotal;
                    return deduccion;
                default:

                    return deduccion;
            }
        }
        private decimal INS(TramitesDto elTramites)
        {
            NominaDto nomina = _obtenerNomina.Detalle(elTramites.IdNomina);
            int duracion = elTramites.duracion;
            decimal salarioNeto = nomina.SalarioNeto;
            decimal salarioMinimo = 250430m; 
            decimal deduccion = 0;
            decimal rentaMensual = 0;
            decimal pagoTotal = 0;
            decimal limiteRegimen = 20442000m;
            switch (elTramites.Razon)
            {
                case "Temporal":
                    if (duracion <= 3)
                    {
                      
                        deduccion = (salarioNeto / 30m) * duracion;
                    }
                    else if (duracion <= 45)
                    {
                  
                        deduccion = ((salarioNeto / 30m) * 3) + ((salarioNeto / 30m) * (duracion - 3) * 0.4m);

                    }
                    else
                    {
                        decimal salarioExcedente = salarioNeto - salarioMinimo;
                        decimal deduccionInicial = ((salarioNeto / 30m) * 3) + ((salarioNeto / 30m) * 42 * 0.4m);
                        decimal deduccionPosterior = ((salarioMinimo / 30m) * (duracion - 45)) + ((salarioExcedente / 30m) * (duracion - 45) * 0.4m);
                        deduccion = deduccionInicial + deduccionPosterior;
                    }
                    return deduccion;
                
                case "Menor Permanente":

                     rentaMensual = salarioNeto * 0.6m;
                     pagoTotal = rentaMensual * 60; 

                    if (pagoTotal <= limiteRegimen)
                    {
                        deduccion = pagoTotal * 0.4m;
                    }
                    else
                    {
                        deduccion = rentaMensual * 0.4m; 
                    }


                    return deduccion;
                case "ParcialPermanente":
                     rentaMensual = salarioNeto * 0.6m;

                 
                    decimal adelantoAnual = rentaMensual * 12;

         
                    decimal decimoTercerMes = rentaMensual;


                    decimal ajusteAnual = 1.05m;

           
                    decimal totalRenta5Anios = 0;

                    for (int i = 1; i <= 5; i++)
                    {
                        totalRenta5Anios += rentaMensual * 12;
                        rentaMensual *= ajusteAnual;
                    }

                 
                    decimal totalPagos = adelantoAnual + decimoTercerMes + totalRenta5Anios;

                    decimal deduccionPatrono = totalPagos * 0.4m;

                    return deduccionPatrono;
                case "TotalPermanente":
                    decimal indemnizacion = salarioNeto * 12; 
                    decimal vacacionesNoUtilizadas = (salarioNeto / 30m) * nomina.DiasDispoVacaciones; 
                    deduccion = indemnizacion + vacacionesNoUtilizadas;
                    return deduccion;
                case "GranInvalido":
                   
                    decimal plusRenta = salarioNeto * 0.1m; 
                    rentaMensual = salarioNeto * 0.6m + plusRenta;

                    decimal adelantoRenta = rentaMensual * 24;

                   
                    decimal seguroEnfermedad = 100000m;

                    
                    decimal decimoTercerMesRenta = rentaMensual;

                 
                    for (int i = 1; i <= 5; i++)
                    {
                        rentaMensual *= 1.05m; 
                    }

                    deduccion =   adelantoRenta + seguroEnfermedad + decimoTercerMesRenta + (rentaMensual * 60);
                     decimal deduccionT = deduccion * 0.4m;
                    return deduccionT;
                default:
                    deduccion = 0;
                    return deduccion;
            }

        }
        private decimal incapacidad(TramitesDto elTramites,decimal cantidad)
        {
            NominaDto nomina = _obtenerNomina.Detalle(elTramites.IdNomina);
            int duracion = elTramites.duracion;
           
            AjustesSalarialesDto ajuste = new AjustesSalarialesDto()
            {
                IdAjusteSalarial= 0,
                IdNomina=elTramites.IdNomina,
                Monto=cantidad,
                Razon="Ingreso de incapacidad",
                tipo="Bonificacion"
           
            };
            _crearAjusteSalarial.RegistarAjusteSalariales(ajuste);
            return cantidad;

        }
        public decimal Accidente(TramitesDto eltramite)
        {

            NominaDto nomina = _obtenerNomina.Detalle(eltramite.IdNomina);
            int duracion = eltramite.duracion;
            decimal bonificacion = (nomina.SalarioNeto / 30m) * duracion;
            AjustesSalarialesDto ajuste = new AjustesSalarialesDto()
            {
                IdAjusteSalarial = 0,
                IdNomina =  eltramite.IdNomina,
                Monto = bonificacion,
                Razon = "Bonificacion de accidente Laboral",
                tipo = "Bonificacion"
            };
            _crearAjusteSalarial.RegistarAjusteSalariales(ajuste);
            return bonificacion; 
        }

        private decimal vacaciones (TramitesDto eltramites)
        {
            NominaDto laNomina = _obtenerNomina.Detalle(eltramites.IdNomina);
            int diasUtilizados = laNomina.DiasUtiliVacaciones;
            if (laNomina.DiasUtiliVacaciones < laNomina.DiasDispoVacaciones)
            {
                DateTime fechaInicio = eltramites.FechaInicio;
                int duracion = eltramites.duracion;
                diasUtilizados += duracion;
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
                    DiasUtiliVacaciones = diasUtilizados,
                    Incapacidad = laNomina.Incapacidad,
                    Estado = laNomina.Estado,
                    totalBono = laNomina.totalBono,
                    totalDedu = laNomina.totalDedu
                };


                if(diasUtilizados <= laNomina.DiasDispoVacaciones)
                {
                    _editarNomina.EditarNomina(nominaModificada);
                    return 2;
                }
                else
                {
                    return 0;
                }
               
               
            }
            else
            {
                return 0;
            }

          
        }

    }
}



