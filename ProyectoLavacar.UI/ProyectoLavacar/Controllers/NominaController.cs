using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearAccidente;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearAjusteSalariales;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.DetalleNominaCompleta;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarGeneral;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.LN.ModuloAjustesSalariales.CrearAjustesSalariales;
using ProyectoLavacar.LN.ModuloNomina.CrearAccidente;
using ProyectoLavacar.LN.ModuloNomina.CrearNomina;
using ProyectoLavacar.LN.ModuloNomina.CrearTramites;
using ProyectoLavacar.LN.ModuloNomina.DetalleNominaCompleta;
using ProyectoLavacar.LN.ModuloNomina.EditarNomina;
using ProyectoLavacar.LN.ModuloNomina.ListarGeneral;
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
                         new SelectListItem { Value = "Vacaciones", Text = "Vacaciones" }
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
                    tipo = modeloDeTramites.tipo
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

        public ActionResult IngresarAccidente(int idNomina)
        {
           
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> IngresarAccidente(AccidenteDto modelo, int idNomina)
        {
            try
            {

                AccidenteDto accidente = new AccidenteDto()
                {
                    idAccidente = 0,
                    IdNomina = idNomina,
                   duracion =modelo.duracion,
                   FechaInicio =modelo.FechaInicio,
                   Razon = modelo.Razon,
                   tipo="Bonificacion",
                };

                int cantidadDeDatosGuardados = await _crearAccidentes.RegistroTramites(accidente);

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

        // POST: Nomina/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Nomina/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Nomina/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
