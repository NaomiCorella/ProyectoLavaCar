using Antlr.Runtime.Tree;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ListarTodo;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.EditarCliente;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ListarDisponibles;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ListarEncargo;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ListarTodo;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.AccesoADatos;
using ProyectoLavacar.LN.ModuloReservas.Crear;
using ProyectoLavacar.LN.ModuloReservas.Editar;
using ProyectoLavacar.LN.ModuloReservas.EditarCliente;
using ProyectoLavacar.LN.ModuloReservas.ListarDisponibles;
using ProyectoLavacar.LN.ModuloReservas.ListarEncargo;
using ProyectoLavacar.LN.ModuloReservas.ListarTodo;
using ProyectoLavacar.LN.ModuloReservas.ObtenerPorId;
using ProyectoLavacar.LN.ModuloServicios.ListarServicios;
using ProyectoLavacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        IListarServiciosLN _listarServicios;
        Contexto _context;
   

        public ReservasController()
        {
    
            _crearReserva = new CrearReservaLN();
            _editarReservaAdmin = new EditarReservaLN();
            _editarReservaCliente = new EditarClienteLN();
            _listarReservasClientes = new ListarDisponiblesLN();
            _listarReservasEmpleado = new ListarEncargoLN();
            _listarReservasAdmin = new ListarTodoReservaLN();
            _detallesReserva = new ObtenerPorIdReservaLN();
            _listarServicios = new ListarServiciosLN();
            _context = new Contexto();
        }

        //Listar Servicios
        public ActionResult Index() //Servicios
        {
            List<ServiciosDto> lalistaDeReservas = _listarServicios.ListarServicios();
            return View(lalistaDeReservas);
        }
        // GET: Reservas
        public ActionResult Reservas() //ReservasAdmin
        {
            List<ReservasDto> lalistaDeReservas = _listarReservasAdmin.ListarReservasTodo();
            return View(lalistaDeReservas);
        }
        // GET: Reservas
        public ActionResult MisReservas() //ReservasCliente
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idCliente = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

           
            List<ReservasDto> lalistaDeReservas = _listarReservasClientes.Listar(idCliente);
            return View(lalistaDeReservas);
        }

        public ActionResult ReservasEncargadas() //ReservasEmpleado
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
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
        public async Task<ActionResult> Create(ReservasDto modeloDeReserva, int id)
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idCliente = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            try
            {
                ReservasDto reserva = new ReservasDto()
                {
                    idReserva=1,
                    idCliente = idCliente,
                    idServicio = id,
                    idEmpleado= "c2d2b03b-96f7-45a3-b2e1-f9107234dbf3",
                    fecha= modeloDeReserva.fecha,
                    hora = modeloDeReserva.hora,
                    estado = modeloDeReserva.estado
                    
                };
                int cantidadDeDatosGuardados = await _crearReserva.CrearReserva(reserva);

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
            ReservasDto modeloReserva = _detallesReserva.Detalle(idReserva);
            return View(modeloReserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(ReservasDto modeloReserva)
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
        /// //////////////// Admin //////////////////

        // GET: Reservas/Edit/5
        public ActionResult EditarMiReserva(int idReserva)
        {
            ReservasDto modeloReserva = _detallesReserva.Detalle(idReserva);
            return View(modeloReserva);
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

        public ActionResult CambiarEstado(int id)
        {

            try
            {
                var reserva = _context.ReservasTabla.Find(id);
                reserva.estado = !reserva.estado;
                _context.SaveChanges();

                return RedirectToAction("Reservas/Reservas");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Home");
            }
        }
    }
}
