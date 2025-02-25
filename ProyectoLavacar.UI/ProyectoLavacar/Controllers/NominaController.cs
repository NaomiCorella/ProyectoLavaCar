using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.EditarTramite;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearAccidente;
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
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.LN.ModuloAjustesSalariales.CrearAjustesSalariales;
using ProyectoLavacar.LN.ModuloNomina.CrearAccidente;
using ProyectoLavacar.LN.ModuloNomina.CrearNomina;
using ProyectoLavacar.LN.ModuloNomina.CrearTramites;
using ProyectoLavacar.LN.ModuloNomina.DetalleAjustes;
using ProyectoLavacar.LN.ModuloNomina.DetalleNominaCompleta;
using ProyectoLavacar.LN.ModuloNomina.DetallesTramites;
using ProyectoLavacar.LN.ModuloNomina.EditarAjustes;
using ProyectoLavacar.LN.ModuloNomina.EditarNomina;
using ProyectoLavacar.LN.ModuloNomina.EditarTramites;
using ProyectoLavacar.LN.ModuloNomina.ListarAjustes;
using ProyectoLavacar.LN.ModuloNomina.ListarGeneral;
using ProyectoLavacar.LN.ModuloNomina.ListarTramites;
using ProyectoLavacar.LN.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.LN.ModuloNomina.ObtenerPorId;
using System;
using System.Collections.Generic;
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
        ICrearAccidenteLN _crearAccidentes;
        IListarTramitesLN _listarTramites;
        IListarAjustesLN _listarAjustes;
        IEditarTramitesLN _editarTramites;
        IEditarAjusteLN _editarAjustes;
        IDetallesAjustesLN _detallesAjustes;
        IDetallesTramitesLN _detallesTramites;

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
            _crearAccidentes = new CrearAccidenteLN();
            _listarTramites = new ListarTramitesLN();
            _listarAjustes = new ListarAjustesLN();
            _editarTramites = new EditarTramitesLN();
            _editarAjustes = new EditarAjustesLN();
             _detallesAjustes = new DetallesAjustesLN();
             _detallesTramites = new DetallesTramitesLN();

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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nomina/Create
        [HttpPost]
        public async Task<ActionResult> Create(NominaDto modeloDeNomina)
        {
            try
            {
               
                int cantidadDeDatosGuardados = await _crearNomina.RegistrarNomina(modeloDeNomina);

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
                         new SelectListItem { Value = "Vacaciones", Text = "Vacaciones" },
                          new SelectListItem { Value = "AccidenteLaboral", Text = "Accidente Laboral" }
                         };
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> IngresarTramites(TramitesDto modeloDeTramites,int idNomina)
        {
            try
            {
                TramitesDto tramite = new TramitesDto()
                {
                    IdTramite = modeloDeTramites.IdTramite,
                    IdNomina = idNomina,
                    duracion = modeloDeTramites.duracion,
                    FechaInicio= modeloDeTramites.FechaInicio,
                    Razon = modeloDeTramites.Razon,
                    tipo = modeloDeTramites.tipo,
                    estado= 1
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


        public ActionResult IngresarVacaciones()
        {
           
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
            return View(ajuste);
        }

        // POST: Nomina/Edit/5
        [HttpPost]
        public async Task<ActionResult> AceptarVacacion(TramitesDto ajuste)
        {
            try
            {
                TramitesDto tramite = new TramitesDto
                {
                    IdTramite = ajuste.IdTramite,
                    estado = ajuste.estado,
                    duracion = ajuste.duracion,
                    FechaInicio = ajuste.FechaInicio,
                    IdNomina = ajuste.IdNomina,
                    Razon = ajuste.Razon,
                    tipo = ajuste.tipo
                };
                int cantidadDeDatosEditados = await _editarTramites.Editar(ajuste);

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

            return View(tramites);
        }
        public ActionResult ListarAjustes(int idNomina)
        {
            List<AjustesSalarialesDto> tramites = _listarAjustes.ListarTodo();

            return View(tramites);
        }


        public ActionResult EditarAjustes(int idAjustes)
        {
            AjustesSalarialesDto ajuste = _detallesAjustes.Detalle(idAjustes);
            return View(ajuste);
        }

        // POST: Nomina/Edit/5
        [HttpPost]
        public async Task<ActionResult>  EditarAjustes( AjustesSalarialesDto ajuste)
        {
            try
            {
                int cantidadDeDatosEditados = await _editarAjustes.Editar(ajuste);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditarTramites(int idTramite)
        {
            TramitesDto ajuste = _detallesTramites.Detalle(idTramite);
            return View(ajuste);
        }

        // POST: Nomina/Edit/5
        [HttpPost]
        public async Task<ActionResult> EditarTramites(TramitesDto ajuste)
        {
            try
            {
                int cantidadDeDatosEditados = await _editarTramites.Editar(ajuste);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Error()
        {

            return View();
        }

        // GET: Nomina/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        
    }
}
