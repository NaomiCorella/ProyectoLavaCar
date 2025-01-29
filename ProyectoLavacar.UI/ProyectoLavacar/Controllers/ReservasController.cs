using Antlr.Runtime.Tree;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ListarTodo;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.EditarCliente;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ListarDisponibles;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ListarEncargo;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ListarTodo;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.LN.ModuloReservas.Crear;
using ProyectoLavacar.LN.ModuloReservas.Editar;
using ProyectoLavacar.LN.ModuloReservas.EditarCliente;
using ProyectoLavacar.LN.ModuloReservas.ListarDisponibles;
using ProyectoLavacar.LN.ModuloReservas.ListarEncargo;
using ProyectoLavacar.LN.ModuloReservas.ListarTodo;
using ProyectoLavacar.LN.ModuloReservas.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoLavacar.Controllers
{

  

    public class ReservasController : Controller
    {
        ICrearReservaLN _crearReserva;
        IEditarReservaLN _editarReservaAdmin;
        IEditarClienteLN _editarReservaCliente;
        IListarDisponiblesLN _listarReservasClientes;
        IListarEncargoLN _listarReservasEmpleado;
        IListarTodoReservaLN _listarReservasAdmin;
        IObtenerPorIdReservaLN _detallesReserva; 
        public ReservasController()
        {
            _crearReserva = new CrearReservaLN();
            _editarReservaAdmin = new EditarReservaLN();
            _editarReservaCliente = new EditarClienteLN();
            _listarReservasClientes = new ListarDisponiblesLN();
            _listarReservasEmpleado = new ListarEncargoLN();
            _listarReservasAdmin = new ListarTodoReservaLN();
            _detallesReserva = new ObtenerPorIdReservaLN();
        }
        // GET: Reservas
        public ActionResult Reservas() //ReservasAdmin
        {
            List<ReservasDto> lalistaDeReservas = _listarReservasAdmin.ListarReservasTodo();
            return View(lalistaDeReservas);
        }

        public ActionResult MisReservas(string idCliente) //ReservasCliente
        {
            List<ReservasDto> lalistaDeReservas = _listarReservasClientes.Listar(idCliente);
            return View(lalistaDeReservas);
        }

        public ActionResult ReservasEncargadas(int idEmpleado) //ReservasAdmin
        {
            List<ReservasDto> lalistaDeReservas = _listarReservasEmpleado.Listar(idEmpleado);
            return View(lalistaDeReservas);
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        public async Task<ActionResult> Create(ReservasDto modeloDeReserva)
        {
            try
            {
                int cantidadDeDatosGuardados = await _crearReserva.CrearReserva(modeloDeReserva);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        /// //////////////// Admin //////////////////

        // GET: Reservas/Edit/5
        public ActionResult Edit(int idReserva)
        {
            ReservasDto laPersona = _detallesReserva.Detalle(idReserva);
            return View();
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        public async Task<ActionResult> EditarReserva(ReservasDto modeloReserva)
        {
            try
            {
                int cantidadDeDatosEditados = await _editarReservaAdmin.EditarPersonas(modeloReserva);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        /// ////////////////  //////////////////

        /// //////////////// Cliente //////////////////

        public ActionResult Editar(int idReserva)
        {
            ReservasDto laPersona = _detallesReserva.Detalle(idReserva);
            return View();
        }


        // POST: Reservas/Edit/5
        [HttpPost]
        public async Task<ActionResult> EditarMiReserva(ReservasDto modeloReserva)
        {
            try
            {
                int cantidadDeDatosEditados = await _editarReservaCliente.EditarPersonas(modeloReserva);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        /// ////////////////  //////////////////
        // GET: Reservas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservas/Delete/5
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
