﻿using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearAccidente;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearAjusteSalariales;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.DetalleNominaCompleta;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.DetallesAjustes;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.DetallesTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarAjustes;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarAjustes;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarGeneral;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ProcesarNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.LN.ModuloAjustesSalariales.CrearAjustesSalariales;
using ProyectoLavacar.LN.ModuloNomina.CrearNomina;
using ProyectoLavacar.LN.ModuloNomina.CrearTramites;
using ProyectoLavacar.LN.ModuloNomina.DetalleAjustes;
using ProyectoLavacar.LN.ModuloNomina.DetalleNominaCompleta;
using ProyectoLavacar.LN.ModuloNomina.DetallesTramites;
using ProyectoLavacar.LN.ModuloNomina.EditarNomina;
using ProyectoLavacar.LN.ModuloNomina.ListarAjustes;
using ProyectoLavacar.LN.ModuloNomina.ListarGeneral;
using ProyectoLavacar.LN.ModuloNomina.ListarTramites;
using ProyectoLavacar.LN.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.LN.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.LN.ModuloNomina.ProcesarNomina;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoLavacar.Controllers
{

    public class NominaController : Controller
    {
        ICrearAjusteSalarialesLN _crearAjustes;
        ICrearNominaLN _crearNomina;
        ICrearTramitesLN _crearTramites;
        IDetalleNominaCompletaLN _detalleNominaCompleta;
        IEditarNominaLN _editarNomina;
        IListarGeneralLN _listarGeneralEmpleadosNom;
        IListarUnicoEmpleadoLN _listarNominadelEmpleado;
        IObtenerPorIdLN _obtenerporId;
        ICrearRebajoLN _crearAccidentes;
        IListarTramitesLN _listarTramites;
        IListarAjustesLN _listarAjustes;
        IEditarTramitesLN _editarTramites;
        IEditarAjusteLN _editarAjustes;
        IDetallesAjustesLN _detallesAjustes;
        IDetallesTramitesLN _detallesTramites;
        IProcesarNominaLN _procesarNomina;

        public  NominaController()
        {
            _crearAjustes = new CrearAjustesSalarialesLN();
            _crearNomina = new CrearNominaLN();
            _crearTramites = new CrearTramitesLN();
            _detalleNominaCompleta = new DetalleNominaCompletoLN();
            _editarNomina = new EditarNominaLN();
            _listarGeneralEmpleadosNom = new ListarGeneralLN();
            _listarNominadelEmpleado = new ListarUnicoEmpleadoLN();
            _obtenerporId = new ObtenerPorIdLN();
            _listarTramites = new ListarTramitesLN();
            _listarAjustes = new ListarAjustesLN();
            _editarTramites = new EditarTramitesLN();

            _detallesAjustes = new DetallesAjustesLN();
             _detallesTramites = new DetallesTramitesLN();
            _procesarNomina = new ProcesarNominaLN();

        }
        // GET: Nomina
        public ActionResult Index()
        {
            ViewBag.Title = "Nomina";
            List<GeneralDto> lalistadeNomina = _listarGeneralEmpleadosNom.ListarNomina();

            return View(lalistadeNomina);
        }
        public ActionResult ProcesosYGestiones(int idNomina)
        {
            NominaCompletaDto nomina = _detalleNominaCompleta.Detalle(idNomina);
            return View(nomina);
        }

        public ActionResult Nomina(string idEmpleado)
        {
            ViewBag.Title = "Nomina de Empleado";
            List<UnicoEmpleadoDto> lalistadeNomina = _listarNominadelEmpleado.ListarNomina(idEmpleado);
            return View(lalistadeNomina);
        }

        // GET: Nomina/Details/5
        public ActionResult Details(int idNomina)
        {
            NominaCompletaDto nomina = _detalleNominaCompleta.Detalle(idNomina);
            return View(nomina);
        }

        // GET: Nomina/Create
        public ActionResult Create(string id)
        {
            ViewBag.Periodo = new List<SelectListItem>
    {
        new SelectListItem { Value = "Quincenal", Text = "Quincenal" },
        new SelectListItem { Value = "Mensual", Text = "Mensual" }
    };
            ViewBag.tipo = new List<SelectListItem>
    {
        new SelectListItem { Value = "Indefinido", Text = "Indefinido" },
        new SelectListItem { Value = "CortoPlazo", Text = "Corto Plazo" },
                new SelectListItem { Value = "LargoPlazo", Text = "Largo Plazo" }

    };
            return View();
        }

        // POST: Nomina/Create
        [HttpPost]
        public async Task<ActionResult> Create(NominaDto modeloDeNomina,string id)
        {
            try
            {
               
                int cantidadDeDatosGuardados = await _crearNomina.RegistrarNomina(modeloDeNomina,  id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult IngresarAjustes(int idNomina)
        {
            ViewBag.tipo = new List<SelectListItem>
    {
        new SelectListItem { Value = "Deduccion", Text = "Deduccion" },
        new SelectListItem { Value = "Bonificacion", Text = "Bonificacion" }
    };

            ViewBag.RazonDeduccion = new List<SelectListItem>
    {
        new SelectListItem { Value = "Sancion", Text = "Sancion por mal comportamiento" },
        new SelectListItem { Value = "Deuda", Text = "Deuda personal" },
        new SelectListItem { Value = "Malgasto", Text = "Malgasto de productos" },
        new SelectListItem { Value = "MalaGestion", Text = "Mala gestion de equipo" }

    };

            ViewBag.RazonBonificacion = new List<SelectListItem>
    {
        new SelectListItem { Value = "TrabajadorDelMes", Text = "Trabajador del mes" },
        new SelectListItem { Value = "MayoresCarrosLavados", Text = "Mayor cantidad de carros lavados" },
        new SelectListItem { Value = "BuenComportamiento", Text = "Buen comportamiento" }

    };
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> IngresarAjustes(AjustesSalarialesDto modeloDeAjustes, int idNomina)
        {
            try
            {

                AjustesSalarialesDto ajuste = new AjustesSalarialesDto()
                {
                    IdAjusteSalarial = modeloDeAjustes.IdAjusteSalarial,
                    IdNomina = idNomina,
                    Monto = modeloDeAjustes.Monto,
                    Razon = modeloDeAjustes.Razon,
                    tipo = modeloDeAjustes.tipo
                };

                int cantidadDeDatosGuardados = await _crearAjustes.RegistarAjusteSalariales(ajuste);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult IngresarTramites(int idNomina)
        {
            ViewBag.tipo = new List<SelectListItem>
    {
        new SelectListItem { Value = "Incapacidad", Text = "Incapacidad" },
        new SelectListItem { Value = "Vacaciones", Text = "Vacaciones" }
    };

            ViewBag.Aseguradora = new List<SelectListItem>
    {
        new SelectListItem { Value = "INS", Text = "INS" },
        new SelectListItem { Value = "CSSS", Text = "CSSS" }
    };

            ViewBag.PorINS = new List<SelectListItem>
    {
        new SelectListItem { Value = "Temporal", Text = "Temporal" },
        new SelectListItem { Value = "Menor Permanente", Text = "Menor Permanente" },
        new SelectListItem { Value = "ParcialPermanente", Text = "Parcial Permanente" },
        new SelectListItem { Value = "TotalPermanente", Text = "Total Permanente" },
        new SelectListItem { Value = "GranInvalido", Text = "Gran Invalido" }
    };

            ViewBag.PorCSSS = new List<SelectListItem>
    {
        new SelectListItem { Value = "Enfermedad", Text = "Enfermedad" },
        new SelectListItem { Value = "LicenciasDeMaternidad", Text = "Licencias De Maternidad" },
        new SelectListItem { Value = "LicenciasDeFaseTerminal", Text = "Licencias De Fase Terminal" },
        new SelectListItem { Value = "LicenciaDeCuido", Text = "Licencia para cuido de persona menor gravemente enferma." },
        new SelectListItem { Value = "LicenciaExtraordinaria", Text = "Licencia Extraordinaria" },
        new SelectListItem { Value = "AccidentesTransito", Text = "Accidentes Transito" }
    };

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> IngresarTramites(TramitesDto modeloDeTramites,int idNomina)
        {
            try
            {
               int cantidadDeDatosGuardados = 0;

                if (modeloDeTramites.tipo == "Vacaciones")
                {
                    TramitesDto vaca = new TramitesDto()
                    {
                        IdTramite = modeloDeTramites.IdTramite,
                        IdNomina = idNomina,
                        duracion = modeloDeTramites.duracion,
                        FechaInicio = modeloDeTramites.FechaInicio,
                        Razon = "Pedido de vacaciones",
                        tipo = modeloDeTramites.tipo,
                        estado = 1,
                        aseguradora = modeloDeTramites.aseguradora
                    };
                    cantidadDeDatosGuardados = await _crearTramites.RegistroTramites(vaca);

                }
                else
                {
                    TramitesDto tramite = new TramitesDto()
                    {
                        IdTramite = modeloDeTramites.IdTramite,
                        IdNomina = idNomina,
                        duracion = modeloDeTramites.duracion,
                        FechaInicio = modeloDeTramites.FechaInicio,
                        Razon = modeloDeTramites.Razon,
                        tipo = modeloDeTramites.tipo,
                        estado = 1,
                        aseguradora = modeloDeTramites.aseguradora
                    };
                    cantidadDeDatosGuardados = await _crearTramites.RegistroTramites(tramite);
                }



                   
                if (cantidadDeDatosGuardados == 0)
                {
                    return RedirectToAction("/Error");
                }
                else
                {
                    return RedirectToAction("Index");
                }


                  
            }
            catch
            {
                return View();
            }
        }


        public ActionResult IngresarVacaciones()
        {
         
            ViewBag.tipo = new List<SelectListItem>
    {
        new SelectListItem { Value = "Vacaciones", Text = "Vacaciones" }
    };
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> IngresarVacaciones(TramitesDto modeloDeTramites)
        {
            try
            {
                var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
                string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                UnicoEmpleadoDto nomina = _listarNominadelEmpleado.ListarNomina(idEmpleado).LastOrDefault();
                TramitesDto tramite = new TramitesDto()
                {
                    IdTramite = modeloDeTramites.IdTramite,
                    IdNomina = nomina.IdNomina,
                    duracion = modeloDeTramites.duracion,
                    FechaInicio = modeloDeTramites.FechaInicio,
                    Razon = modeloDeTramites.Razon,
                    tipo = "Vacaciones",
                    estado = 0,
                };


                int cantidadDeDatosGuardados = await _crearTramites.RegistroTramites(tramite);
                if (cantidadDeDatosGuardados == 0)
                {
                    return RedirectToAction("/Error");
                }
                else
                {
                    return RedirectToAction("Index");
                }



            }
            catch
            {
                return View();
            }
        }


        public ActionResult AceptarVacacion(int idTramite)
        {
            ViewBag.estado = new SelectList(new List<object>
                {
                 new { Value = 0, Text = "Pendiente" },
                 new { Value = 1, Text = "Aceptada" },
                 new { Value = 2, Text = "Denegada" }
                }, "Value", "Text");


            TramitesDto ajuste = _detallesTramites.Detalle(idTramite);

            DateTime FechaInicio = ajuste.FechaInicio; 
            int duracion = ajuste.duracion; 
            DateTime FechaFinal = FechaInicio.AddDays(duracion);
            ViewBag.FechaInicio = ajuste.FechaInicio.ToString("dd/MM/yyyy");
            ViewBag.FechaFinal = ajuste.FechaInicio.AddDays(ajuste.duracion).ToString("dd/MM/yyyy"); 
            return View(ajuste);
           
        }

        // POST: Nomina/Edit/5
        [HttpPost]
        public async Task<ActionResult> AceptarVacacion(TramitesDto ajuste, int idTramite)
        {
            try
            {
                TramitesDto ajustepasado = _detallesTramites.Detalle(idTramite);
                TramitesDto tramite = new TramitesDto
                {
                    IdTramite = ajustepasado.IdTramite,
                    estado = ajuste.estado,
                    duracion = ajustepasado.duracion,
                    FechaInicio = ajustepasado.FechaInicio,
                    IdNomina = ajustepasado.IdNomina,
                    Razon = ajustepasado.Razon,
                    tipo = ajustepasado.tipo
                };

                int cantidadDeDatosEditados = await _editarTramites.Editar(tramite);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ListarTramites(int idNomina)
        {
            List<TramitesDto> tramites = _listarTramites.ListarTodo(idNomina);
            ViewBag.idNomina = idNomina;
            return View(tramites);
        }
        public ActionResult ListarAjustes(int idNomina)
        {
            List<AjustesSalarialesDto> tramites = _listarAjustes.ListarTodo();
            ViewBag.idNomina = idNomina;
            return View(tramites);
        }


        [HttpPost]
        public async Task<ActionResult> AnularAjustes(int  id)
        {
            try
            {

                AjustesSalarialesDto modeloDeAjustes = _detallesAjustes.Detalle(id);

                if(modeloDeAjustes.tipo == "Bonificacion")
                {
                    AjustesSalarialesDto ajuste = new AjustesSalarialesDto()
                    {
                        IdAjusteSalarial = modeloDeAjustes.IdAjusteSalarial,
                        IdNomina = modeloDeAjustes.IdNomina,
                        Monto = modeloDeAjustes.Monto,
                        Razon = "Anulacion de bono",
                        tipo ="Deduccion"
                    };

                    int cantidadDeDatosGuardados = await _crearAjustes.RegistarAjusteSalariales(ajuste);
                }
                else
                {
                    AjustesSalarialesDto ajuste = new AjustesSalarialesDto()
                    {
                        IdAjusteSalarial = modeloDeAjustes.IdAjusteSalarial,
                        IdNomina = modeloDeAjustes.IdNomina,
                        Monto = modeloDeAjustes.Monto,
                        Razon = "Anulacion de deduccion",
                        tipo = "Bonificacion"
                    };

                    int cantidadDeDatosGuardados = await _crearAjustes.RegistarAjusteSalariales(ajuste);
                }


                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ProcesarNomina(int idNomina)
        {
            NominaDto nomina = _obtenerporId.Detalle(idNomina);
            return View(nomina);
        }
        public ActionResult ConfimarNomina(int idNomina)
        {
            NominaDto nomina = _procesarNomina.ProcesarNomina(idNomina);

            return RedirectToAction("Index");
        }
        public ActionResult Error()
        {

            return View();
        }

        // GET: Nomina/Edit/5
       
        
    }
}
