using Antlr.Runtime.Tree;
using Microsoft.AspNet.Identity;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ListarTodo;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.DetallesReservaCompleta;
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
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos;
using ProyectoLavacar.LN.ModuloEmpleados.Listar;
using ProyectoLavacar.LN.ModuloReservas.Crear;
using ProyectoLavacar.LN.ModuloReservas.DetallesReservaCompleta;
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
        IListarEmpleadoLN _listarEmpleado;
        IDetallesReservaCompletaLN _detallesReservaCompleta;

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
            _listarEmpleado = new ListarEmpleadoLN();
            _detallesReservaCompleta = new DetallesReservaCompletaLN();
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

        public ActionResult FiltrarReservas(string fechaInicio, string fechaFin)
        {
            var reservas = _listarReservasAdmin.ListarReservasTodo().ToList(); // Obtener datos primero

            // Intentar convertir los valores de entrada a DateTime
            DateTime fechaInicioDT, fechaFinDT;
            bool tieneFechaInicio = DateTime.TryParse(fechaInicio, out fechaInicioDT);
            bool tieneFechaFin = DateTime.TryParse(fechaFin, out fechaFinDT);

            if (tieneFechaInicio)
            {
                reservas = reservas.Where(r => DateTime.Parse(r.fecha) >= fechaInicioDT).ToList();
            }

            if (tieneFechaFin)
            {
                reservas = reservas.Where(r => DateTime.Parse(r.fecha) <= fechaFinDT).ToList();
            }

            return View("Reservas", reservas);
        }

        // GET: Reservas
        public ActionResult Reservas() //ReservasAdmin
        {
            List<ReservaCompleta> lalistaDeReservas = _listarReservasAdmin.ListarReservasTodo();
            return View(lalistaDeReservas);
        }
        // GET: Reservas
        public ActionResult MisReservas() //ReservasCliente
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idCliente = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;


            List<ReservaCompleta> lalistaDeReservas = _listarReservasClientes.Listar(idCliente);
            return View(lalistaDeReservas);
        }

        public ActionResult ReservasEncargadas() //ReservasEmpleado
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            List<ReservaCompleta> lalistaDeReservas = _listarReservasEmpleado.Listar(idEmpleado)
                .OrderByDescending(r => r.estado)
                .ToList();

            return View(lalistaDeReservas);
        }




        // GET: Reservas/Details/5
        public ActionResult DetallesReserva(int idReserva)
        {
            ReservaCompleta reserva = _detallesReservaCompleta.Detalle(idReserva);
            return View(reserva);
        }


        // Método para obtener fechas y horas disponibles
        public List<DateTime> ObtenerFechasYHorasDisponibles(int idServicio)
        {
            // Obtener las reservas ocupadas desde la base de datos (sin manipulación de fecha)
            var reservas = _context.ReservasTabla
                .Where(r => r.idServicio == idServicio)
                .ToList(); // Trae los datos primero para manipularlos en memoria

            // Transformar la lista de reservas a una lista de DateTime con la combinación de fecha y hora
            var reservasOcupadas = reservas.Select(r => r.fecha + r.hora).ToList();

            var fechasYHorasDisponibles = new List<DateTime>();

            // Generar fechas disponibles para los próximos 30 días
            for (var fecha = DateTime.Today; fecha <= DateTime.Today.AddDays(30); fecha = fecha.AddDays(1))
            {
                for (int hora = 8; hora < 20; hora++) // Horario de 8:00 a 20:00
                {
                    DateTime fechaHora = fecha.AddHours(hora);

                    if (!reservasOcupadas.Contains(fechaHora))
                    {
                        fechasYHorasDisponibles.Add(fechaHora);
                    }
                }
            }

            return fechasYHorasDisponibles;
        }

        // GET: Reservas/Create
        public ActionResult Create(int id)
        {
            var fechasYHorasDisponibles = ObtenerFechasYHorasDisponibles(id);
            ViewBag.FechasYHorasDisponibles = fechasYHorasDisponibles;
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
             
                DateTime fechaSeleccionada = DateTime.Parse(modeloDeReserva.fecha);
                TimeSpan horaSeleccionada = TimeSpan.Parse(modeloDeReserva.hora);
                DateTime fechaHoraSeleccionada = fechaSeleccionada.Add(horaSeleccionada);

            
                bool existeReserva = _context.ReservasTabla
                    .Any(r => r.idServicio == id && r.fecha == fechaSeleccionada && r.hora == horaSeleccionada);

                if (existeReserva)
                {
                 
                    ModelState.AddModelError("", "La fecha y hora seleccionada ya está ocupada. Por favor elige otra.");
                    return View(modeloDeReserva);
                }

          
                ReservasDto reserva = new ReservasDto()
                {
                    idReserva = 1,
                    idCliente = idCliente,
                    idServicio = id,
                    idEmpleado = idCliente,
                    fecha = modeloDeReserva.fecha, 
                    hora = modeloDeReserva.hora,  
                    estado = true
                };

                int cantidadDeDatosGuardados = await _crearReserva.CrearReserva(reserva);

                return RedirectToAction("/MisReservas");
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return View();
            }
        }

        // GET: Reservas/Create
        public ActionResult ReservarCita ()
        {
            var servicios = _listarServicios.ListarServicios()
               .Where(a => a.estado == true)
               .ToList();
            ViewBag.Servicios = servicios;
           
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        public async Task<ActionResult> ReservarCita(ReservasDto modeloDeReserva)
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idCliente = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            try
            {

                ReservasDto reserva = new ReservasDto()
                {
                    idReserva = 1,
                    idCliente = idCliente,
                    idServicio = modeloDeReserva.idServicio,
                    idEmpleado = idCliente,
                    fecha = modeloDeReserva.fecha,
                    hora = modeloDeReserva.hora,
                    estado = true
                };

                int cantidadDeDatosGuardados = await _crearReserva.CrearReserva(reserva);

                return RedirectToAction("/MisReservas");
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return View();
            }
        }




        /// //////////////// Admin //////////////////

        // GET: Reservas/Edit/5
        public ActionResult Edit(int idReserva)
        {
            var servicios = _listarServicios.ListarServicios()
               .Where(a => a.estado == true)
               .ToList();
            ViewBag.Servicios = servicios;
            var empleados = _listarEmpleado.ListarEmpleados()
               .Where(a => a.estado == true)
               .ToList();
            ViewBag.empleados = empleados;
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

                return RedirectToAction("Reservas");
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

                return RedirectToAction("/MisReservas");
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



        public ActionResult CambiarEstadoCancelacion(int id)
        {

            try
            {
                var reserva = _context.ReservasTabla.Find(id);
                reserva.estado = !reserva.estado;
                _context.SaveChanges();

                return RedirectToAction("MisReservas");
            }
            catch (Exception ex)
            {

                return RedirectToAction("MisReservas");
            }
        }
        public ActionResult CambiarEstadoEncargo(int id)
        {

            try
            {
                var reserva = _context.ReservasTabla.Find(id);
                reserva.estado = !reserva.estado;
                _context.SaveChanges();

                return RedirectToAction("ReservasEncargadas");
            }
            catch (Exception ex)
            {

                return RedirectToAction("ReservasEncargadas");
            }
        }
    }
}
