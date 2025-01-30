using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.AccesoADatos;
using ProyectoLavacar.LN.ModuloReseñas.Crear;
using ProyectoLavacar.LN.ModuloReseñas.Editar;
using ProyectoLavacar.LN.ModuloReseñas.Listar;
using ProyectoLavacar.LN.ModuloReseñas.ObtenerPorId;
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
        Contexto _context;
        IEditarReseniaLN _editarResenia;
        IObtenerPorIdLN _obtenerPorId;
        public ReseniasController()
        {
            _crearResenia = new CrearReseniaLN();
            _listarResenia = new ListarReseniaLN();
            _context = new Contexto();
            _obtenerPorId = new ObtenerPorIdLN();
            _editarResenia = new EditarReseniaLN();
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
            ReseniaDto reseña =_obtenerPorId.Detalle(id);
            return View(reseña);
        }

        // POST: Reseñas/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(ReseniaDto modeloResenia)
        {
            try
            {
                int cantidadDeDatosEditados = await _editarResenia.EditarPersonas(modeloResenia);

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

        public ActionResult CambiarEstado(int id)
        {

            try
            {
                var resenia = _context.ReseniasTabla.Find(id);
                resenia.estado = !resenia.estado;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
