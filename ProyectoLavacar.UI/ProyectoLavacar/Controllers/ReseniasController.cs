using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.CrearRespuesta;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.AccesoADatos;
using ProyectoLavacar.LN.ModuloReseñas.Crear;
using ProyectoLavacar.LN.ModuloReseñas.CrearRespuesta;
using ProyectoLavacar.LN.ModuloReseñas.Editar;
using ProyectoLavacar.LN.ModuloReseñas.Listar;
using ProyectoLavacar.LN.ModuloReseñas.ObtenerPorId;
using ProyectoLavacar.LN.ModuloServicios.ListarServicios;
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
        ICrearRespuestaLN _crearRespuesta;
        ICrearReseniaLN _crearResenia;
        IListarReseniaLN _listarResenia;
        Contexto _context;
        IEditarReseniaLN _editarResenia;
        IObtenerPorIdLN _obtenerPorId;
        IListarServiciosLN _listarServicios;
        public ReseniasController()
        {
            _listarServicios = new ListarServiciosLN();
            _crearResenia = new CrearReseniaLN();
            _listarResenia = new ListarReseniaLN();
            _context = new Contexto();
            _obtenerPorId = new ObtenerPorIdLN();
            _editarResenia = new EditarReseniaLN();
            _crearRespuesta = new CrearRespuestaLN();
        }
        // GET: Reseñas
        public ActionResult Index(string ordenarPor = "fecha", string orden = "asc")
        {
            List<ReseniaConRespuesta> lalistadeArchivos = _listarResenia.ListarResenia();

            // Ordenar según los parámetros
            if (ordenarPor == "fecha")
            {
                lalistadeArchivos = orden == "asc"
                    ? lalistadeArchivos.OrderBy(r => r.fecha).ToList()
                    : lalistadeArchivos.OrderByDescending(r => r.fecha).ToList();
            }
            else if (ordenarPor == "calificacion")
            {
                lalistadeArchivos = orden == "asc"
                    ? lalistadeArchivos.OrderBy(r => r.calificacion).ToList()
                    : lalistadeArchivos.OrderByDescending(r => r.calificacion).ToList();
            }

            return View(lalistadeArchivos);
        }

        public ActionResult IndexAdmin(string filtroFecha = "", string filtroUsuario = "", string filtroContenido = "")
        {
            List<ReseniaConRespuesta> lalistadeArchivos = _listarResenia.ListarResenia();

            if (!string.IsNullOrEmpty(filtroUsuario))
            {
                lalistadeArchivos = lalistadeArchivos.Where(r => r.idCliente.ToString().Contains(filtroUsuario)).ToList();
            }

            if (!string.IsNullOrEmpty(filtroContenido))
            {
                lalistadeArchivos = lalistadeArchivos.Where(r => r.comentarios.Contains(filtroContenido)).ToList();
            }

            if (!string.IsNullOrEmpty(filtroFecha))
            {
                lalistadeArchivos = lalistadeArchivos.Where(r => r.fecha.ToString() == filtroFecha).ToList();
            }

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
            var servicios = _listarServicios.ListarServicios()
             .Where(a => a.estado == true)
             .ToList();
            ViewBag.Servicios = servicios;
            return View();
        }

        // POST: Reseñas/Create
        [HttpPost]
        public async Task<ActionResult> Create(ReseniaDto modeloDeResenia)
        {
            try
            {
                var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
                string idCliente = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                ReseniaDto resenia = new ReseniaDto()
                {
                    idResenia = modeloDeResenia.idResenia,
                    idCliente = idCliente,
                    idServicio = modeloDeResenia.idServicio,
                    calificacion = modeloDeResenia.calificacion,
                    comentarios = modeloDeResenia.comentarios,
                    fecha = modeloDeResenia.fecha,
                    estado = modeloDeResenia.estado
                };

                int cantidadDeDatosGuardados = await _crearResenia.CrearResenia(resenia);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Reseñas/Edit/5
        public ActionResult Edit(int id)
        {
            ReseniaDto reseña = _obtenerPorId.Detalle(id);
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
        public ActionResult ResponderReseña()
        {
            return View();
        }

        // POST: Reseñas/Create
        [HttpPost]
        public async Task<ActionResult> ResponderReseña(RespuestaDto modeloDeRespuesta, int id)
        {
            try
            {
                var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
                string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                RespuestaDto respuesta = new RespuestaDto()
                {
                    idRespuesta = modeloDeRespuesta.idRespuesta,
                    idResenia = id,
                    idEmpleado = idEmpleado,
                    comentarios = modeloDeRespuesta.comentarios,
                    fecha = modeloDeRespuesta.fecha,
                    estado = modeloDeRespuesta.estado

                };

                int cantidadDeDatosGuardados = await _crearRespuesta.CrearRespuesta(respuesta);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
