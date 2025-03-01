using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using ProyectoLavacar.LN.ModuloServicios;
using ProyectoLavacar.LN.ModuloServicios.ListarServicios;
using ProyectoLavacar.LN.ModuloServicios.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoLavacar.Controllers
{
    public class ServiciosController : Controller
    {
        IListarServiciosLN _listarServicios;
        IDetalleServiciosLN _detallesServicios;
        ICrearServiciosLN _crearServicios;
        public ServiciosController()
        {
            _listarServicios = new ListarServiciosLN();
            _detallesServicios = new DetalleServiciosLN();
            _crearServicios = new CrearServiciosLN();
        }
        public ActionResult FiltrarServicios(string nombre, decimal? precioMin, decimal? precioMax, string modalidad, bool? estado)
        {
            var servicios = _listarServicios.ListarServicios().AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
            {
                servicios = servicios.Where(s => s.nombre.Contains(nombre));
            }

            if (precioMin.HasValue)
            {
                servicios = servicios.Where(s => s.costo >= precioMin.Value);
            }

            if (precioMax.HasValue)
            {
                servicios = servicios.Where(s => s.costo <= precioMax.Value);
            }

            if (!string.IsNullOrEmpty(modalidad))
            {
                servicios = servicios.Where(s => s.modalidad == modalidad);
            }

            if (estado.HasValue)
            {
                servicios = servicios.Where(s => s.estado == estado.Value);
            }

            return View("Index", servicios.ToList());
        }
        // GET: Servicios
        public ActionResult Index()
        {
           
            List<ServiciosDto> lalistaDeReservas = _listarServicios.ListarServicios();
            return View(lalistaDeReservas);
        }

        // GET: Servicios/Details/5
        public ActionResult Details(int id)
        {
            ServiciosDto servicio = _detallesServicios.Detalle(id);
            List<ServiciosDto> lalistaDeReservas = _listarServicios.ListarServicios();
            ViewBag.servicios = lalistaDeReservas;
            return View(servicio);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        [HttpPost]
        public async Task<ActionResult> Create(ServiciosDto elservicio)
        {
            try
            {
                int cantidadDeDatosGuardados = await _crearServicios.Crear(elservicio);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Servicios/Edit/5
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

        // GET: Servicios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Servicios/Delete/5
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
