using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.BuscarPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.LN.ModuloUsuarios.BuscarPorId;
using ProyectoLavacar.LN.ModuloUsuarios.Crear;
using ProyectoLavacar.LN.ModuloUsuarios.Editar;
using ProyectoLavacar.LN.ModuloUsuarios.Listar;

namespace ProyectoLavacar.Controllers
{
    public class UsuarioController : Controller
    {
        ICrearUsuarioLN _crearUsuario;
        IListarUsuarioLN _listarUsuario;
        IEditarUsuarioLN _editarUsuario;
        IBuscarPorIdLN _buscarPorId;

        public UsuarioController()
        {
            _crearUsuario = new CrearUsuarioLN();
            _listarUsuario = new ListarUsuarioLN();
            _editarUsuario = new EditarUsuarioLN();
            _buscarPorId = new BuscarPorIdLN();
        }
    
        // GET: Usuario
        public ActionResult Index()
        {
            ViewBag.Title = "La Listas de finanzas";
            List<UsuariosDto> laListaDeFinanzas = _listarUsuario.ListarUsuarios();
            return View(laListaDeFinanzas);
        }


        // GET: Usuario/Details/5
        public ActionResult Details(string id)
        {
           

            UsuariosDto Finanzas = _buscarPorId.Detalle(id);
            return View(Finanzas);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public async Task<ActionResult> Create(UsuariosDto modeloDeUsuarios)
        {
            try
            {
                // TODO: Add insert logic here
                int cantidadDeDatosGuardados = await _crearUsuario.RegistrarUsuarios(modeloDeUsuarios);
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(string id)
        {
            UsuariosDto laFinanza = _buscarPorId.Detalle(id);

            return View(laFinanza);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(UsuariosDto elUsuario)
        {
            try
            {
                int cantidadDeDatosEditados = await _editarUsuario.EditarUsuarios(elUsuario);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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
