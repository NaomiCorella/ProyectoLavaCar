using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.LN.ModuloReseñas.Crear;
using ProyectoLavacar.LN.ModuloReseñas.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoLavacar.Controllers
{
    public class ReseniasController : Controller
    {

        ICrearReseniaLN _crearResenia;
         IListarReseniaLN _listarResenia;
        public ReseniasController()
        {
            _crearResenia = new CrearReseniaLN();
            _listarResenia = new ListarReseniaLN();
        }
        // GET: Reseñas
        public ActionResult Index()
        {
            List<ReseniaDto> lalistadeArchivos = _listarResenia.ListarResenia();
            return View(lalistadeArchivos);
        }

        // GET: Reseñas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reseñas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reseñas/Create
        [HttpPost]
        public async Task<ActionResult> Create(ReseniaDto modeloDeResenia)
        {
            try
            {
                int cantidadDeDatosGuardados = await _crearResenia.CrearResenia(modeloDeResenia);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Reseñas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reseñas/Edit/5
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

        // GET: Reseñas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reseñas/Delete/5
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
