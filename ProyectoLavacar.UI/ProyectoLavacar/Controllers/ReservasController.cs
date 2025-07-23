
using Antlr.Runtime.Tree;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using ProyectoLavacar.Abstracciones.LN.Interfaces.ModuloBitacora.Registrar;
using ProyectoLavacar.Abstracciones.Modelos.ModuloBitacora;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ListarTodo;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCorreos;
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
using ProyectoLavacar.LN.ModuloCorreos;
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
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.BuscarPorId;
using ProyectoLavacar.LN.ModuloUsuarios.BuscarPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.ObtenerPorId;
using ProyectoLavacar.LN.ModuloServicios.ObtenerPorId;

namespace ProyectoLavacar.Controllers
{



    public class ReservasController : Controller
    {
        IBuscarAsyncSerLN _detalleServicios;
        IBuscarAsyncLN _buscarPorId;
        IEmailSender _emailSender;
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
        IRegistrarBitacoraLN _registrarBitacoraLN;
        public ReservasController()
        {
            _emailSender = (IEmailSender)System.Web.HttpContext.Current.Application["EmailSender"];
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
            _buscarPorId = new BuscarAsyncLN();
            _detalleServicios = new BuscarAsyncSerLN();
        }
        public ReservasController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
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

        public ActionResult FiltrarMisReservas(string fechaInicio, string fechaFin)
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

            return View("MisReservas", reservas);
        }

        // GET: Reservas
        [Authorize(Roles = "Administrador")]

        public ActionResult Reservas() //ReservasAdmin
        {
            List<ReservaCompleta> lalistaDeReservas = _listarReservasAdmin.ListarReservasTodo();
            return View(lalistaDeReservas);
        }
        // GET: Reservas
        [Authorize(Roles = "Usuario,Administrador")]
        public ActionResult MisReservas() //ReservasCliente
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idCliente = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;


            List<ReservaCompleta> lalistaDeReservas = _listarReservasClientes.Listar(idCliente);
            return View(lalistaDeReservas);
        }
        [Authorize(Roles = "Empleado")]

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
        //[Authorize(Roles = "Administrador, Empleado, Usuario")]

        //public ActionResult Create(int id)
        //{
        //    var fechasYHorasDisponibles = ObtenerFechasYHorasDisponibles(id);
        //    ViewBag.FechasYHorasDisponibles = fechasYHorasDisponibles;
        //    return View();
        //}

        //// POST: Reservas/Create
        //[HttpPost]
        //public async Task<ActionResult> Create(ReservasDto modeloDeReserva, int id)
        //{
        //    var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
        //    string idCliente = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        //    try
        //    {

        //        DateTime fechaSeleccionada = DateTime.Parse(modeloDeReserva.fecha);
        //        TimeSpan horaSeleccionada = TimeSpan.Parse(modeloDeReserva.hora);
        //        DateTime fechaHoraSeleccionada = fechaSeleccionada.Add(horaSeleccionada);


        //        bool existeReserva = _context.ReservasTabla
        //            .Any(r => r.idServicio == id && r.fecha == fechaSeleccionada && r.hora == horaSeleccionada);

        //        if (existeReserva)
        //        {

        //            ModelState.AddModelError("", "La fecha y hora seleccionada ya está ocupada. Por favor elige otra.");
        //            return View(modeloDeReserva);
        //        }

        //        DateTime fechaInicio;
        //        if (DateTime.TryParse(modeloDeReserva.fecha, out fechaInicio))
        //        {

        //            if (fechaInicio < DateTime.Now)
        //            {
        //                ModelState.AddModelError("Fecha", "La fecha no puede ser anterior a la fecha de hoy.");
        //                return View(modeloDeReserva);
        //            }
        //        }
        //        ReservasDto reserva = new ReservasDto()
        //        {
        //            idReserva = 1,
        //            idCliente = idCliente,
        //            idServicio = id,
        //            idEmpleado = idCliente,
        //            fecha = modeloDeReserva.fecha, 
        //            hora = modeloDeReserva.hora,  
        //            estado = true
        //        };

        //        int cantidadDeDatosGuardados = await _crearReserva.CrearReserva(reserva);

        //        return RedirectToAction("/MisReservas");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo de errores
        //        return View();
        //    }
        //}

        // GET: Reservas/Create
        [Authorize(Roles = "Administrador, Empleado, Usuario")]

        public ActionResult Create(int id)
        {
            
            var servicio = _context.ServiciosTabla.Find(id);
            string modalidad = servicio?.modalidad ?? "";

            ViewBag.idServicio = id;
            ViewBag.modalidad = modalidad;

            var modelo = new ReservasDto();
            return View(modelo);


        }

        // AJAX: Obtener horas disponibles
        public JsonResult ObtenerHorasDisponibles(int idServicio, string fecha)
        {
            List<string> todasLasHoras = new List<string>
    {
        "08:00", "09:00", "10:00", "11:00", "13:00", "14:00", "15:00", "16:00"
    };

            DateTime fechaSeleccionada = DateTime.Parse(fecha);

            // Agrupar por hora sin filtrar por servicio
            var reservasPorHora = _context.ReservasTabla
                .Where(r => r.fecha == fechaSeleccionada)
                .ToList() // Traer los datos a memoria para evitar error con ToString()
                .GroupBy(r => r.hora)
                .Select(g => new
                {
                    Hora = g.Key.ToString(@"hh\:mm"),
                    Cantidad = g.Count()
                })
                .ToList();

            var horasDisponibles = todasLasHoras.Select(h => new
            {
                Hora = h,
                EspaciosDisponibles = 4 - (reservasPorHora.FirstOrDefault(r => r.Hora == h)?.Cantidad ?? 0)
            })
            .Where(h => h.EspaciosDisponibles > 0)
            .ToList();

            return Json(horasDisponibles, JsonRequestBehavior.AllowGet);
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReservasDto modeloDeReserva, int id)
        {
            string idCliente = User.Identity.GetUserId();

            try
            {
                DateTime fechaSeleccionada = DateTime.Parse(modeloDeReserva.fecha);
                TimeSpan horaSeleccionada = TimeSpan.Parse(modeloDeReserva.hora);

                bool existeReserva = _context.ReservasTabla.Any(r =>
                    r.idServicio == id && r.fecha == fechaSeleccionada && r.hora == horaSeleccionada);

                //if (existeReserva)
                //{
                //    ModelState.AddModelError("", "La fecha y hora seleccionada ya está ocupada.");
                //    return View(modeloDeReserva);
                //}

                if (fechaSeleccionada < DateTime.Today)
                {
                    ModelState.AddModelError("Fecha", "La fecha no puede ser anterior a hoy.");
                    return View(modeloDeReserva);
                }

                var servicio = _context.ServiciosTabla.Find(id);
                if (servicio != null && (servicio.modalidad?.ToLower() == "domicilio" || servicio.modalidad?.ToLower() == "a domicilio"))
                {
                    if (string.IsNullOrWhiteSpace(modeloDeReserva.direccion))
                    {
                        ModelState.AddModelError("direccion", "La dirección es obligatoria para reservas a domicilio.");
                        return View(modeloDeReserva);
                    }
                }

                var nuevaReserva = new ReservasTabla
                {
                    idCliente = idCliente,
                    idEmpleado = idCliente,  // según tu lógica, igual que cliente
                    idServicio = id,
                    fecha = fechaSeleccionada,
                    hora = horaSeleccionada,
                    estado = true,
                    direccion = modeloDeReserva.direccion
                };

                _context.ReservasTabla.Add(nuevaReserva);
                await _context.SaveChangesAsync();

                return RedirectToAction("MisReservas");
            }
            catch (Exception)
            {
                return View(modeloDeReserva);
            }
        }

        //get
        [Authorize(Roles = "Administrador, Empleado, Usuario")]

        public ActionResult ReservarCita()
        {
            CargarServicios();
            ViewBag.modalidad = "";
            return View();
        }

        private void CargarServicios()
        {
            var servicios = _listarServicios.ListarServicios()
                .Where(a => a.estado == true)
                .ToList();

            Console.WriteLine($" Cantidad de servicios encontrados: {servicios.Count}");

            foreach (var servicio in servicios)
            {
                Console.WriteLine($"✅ Servicio: {servicio.nombre} - Estado: {servicio.estado}");
            }

            ViewBag.Servicios = servicios;
        }

        [HttpPost]
        public async Task<ActionResult> ReservarCita(ReservasDto modeloDeReserva)
        {
            DateTime fechaInicio;
            if (DateTime.TryParse(modeloDeReserva.fecha, out fechaInicio))
            {
                if (fechaInicio < DateTime.Today)
                {
                    ModelState.AddModelError("Fecha", "La fecha no puede ser anterior a hoy.");
                    CargarServicios();
                    return View(modeloDeReserva);
                }
            }




            // Validar datos
            if (modeloDeReserva.idServicio == 0 || modeloDeReserva.fecha == null || modeloDeReserva.hora == null)
            {
                Console.WriteLine("⚠️ Los datos del formulario son inválidos.");
                CargarServicios();
                return View(); // O redirige a alguna página que maneje esto
            }

            // Verificar usuario logueado
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string idCliente = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(idCliente))
            {
                Console.WriteLine("⚠️ No se pudo obtener el ID del usuario logueado.");
                return RedirectToAction("Login", "Account");
            }

            // Buscar usuario en la base de datos
            var usuario = await _buscarPorId.DetalleAsync(idCliente);
            if (usuario == null)
            {
                Console.WriteLine("⚠️ Usuario no encontrado.");
                return RedirectToAction("Login", "Account");
            }

            // Obtener el nombre del servicio usando el idServicio
            var servicio = await _detalleServicios.DetalleAsync(modeloDeReserva.idServicio);
            if (servicio == null)
            {
                Console.WriteLine("⚠️ Servicio no encontrado.");
                CargarServicios();
                return View(modeloDeReserva);
            }

            if (servicio.modalidad != null && servicio.modalidad.ToLower().Contains("domicilio"))
            {
                if (string.IsNullOrWhiteSpace(modeloDeReserva.direccion))
                {
                    ModelState.AddModelError("direccion", "La dirección es obligatoria para servicios a domicilio.");
                    CargarServicios();
                    return View(modeloDeReserva);
                }
            }

            // Validar cantidad máxima
            DateTime fechaSeleccionada = DateTime.Parse(modeloDeReserva.fecha);
            TimeSpan horaSeleccionada = TimeSpan.Parse(modeloDeReserva.hora);
            int reservasExistentes = _context.ReservasTabla.Count(r =>
                r.idServicio == modeloDeReserva.idServicio &&
                r.fecha == fechaSeleccionada &&
                r.hora == horaSeleccionada);

            if (reservasExistentes >= 4)
            {
                ModelState.AddModelError("", "Ya hay 4 reservas para esa hora. Por favor elige otra.");
                CargarServicios();
                return View(modeloDeReserva);
            }

            // Crear la reserva
            ReservasDto reserva = new ReservasDto()
            {
                idCliente = idCliente,
                idServicio = modeloDeReserva.idServicio,
                idEmpleado = idCliente,
                fecha = modeloDeReserva.fecha,
                hora = modeloDeReserva.hora,
                estado = true,
                direccion = modeloDeReserva.direccion
            };

            // Guardar la reserva
            int cantidadDeDatosGuardados = await _crearReserva.CrearReserva(reserva);
            Console.WriteLine($"Cantidad de registros guardados: {cantidadDeDatosGuardados}");

            if (cantidadDeDatosGuardados > 0)
            {
                // Enviar correo con el nombre del servicio
                string asunto = "Confirmación de reserva";
                string mensaje = $"Estimado {usuario.nombre},\n\nSu reserva ha sido confirmada con éxito.\n\n" +
                                 $"📅 Fecha: {modeloDeReserva.fecha}\n" +
                                 $"⏰ Hora: {modeloDeReserva.hora}\n" +
                                 $"🛠 Servicio: {servicio.nombre}\n\n" +
                                 $"Gracias por elegirnos.";

                await _emailSender.SendEmailAsync(usuario.Email, asunto, mensaje);

                return RedirectToAction("MisReservas");
            }
            else
            {
                Console.WriteLine("⚠️ No se pudo guardar la reserva.");

                var servicios = _listarServicios.ListarServicios()
                    .Where(a => a.estado == true)
                    .ToList();
                ViewBag.Servicios = servicios;
                CargarServicios();
                return View(modeloDeReserva);
            }
        }




        // AJAX: Obtener horas disponibles
        public JsonResult ObtenerHorasDisponibless(int idServicio, string fecha)
        {
            List<string> todasLasHoras = new List<string>
    {
        "08:00", "09:00", "10:00", "11:00", "13:00", "14:00", "15:00", "16:00"
    };

            DateTime fechaSeleccionada = DateTime.Parse(fecha);

            // Agrupar por hora sin filtrar por servicio
            var reservasPorHora = _context.ReservasTabla
                .Where(r => r.fecha == fechaSeleccionada)
                .ToList() // Traer los datos a memoria para evitar error con ToString()
                .GroupBy(r => r.hora)
                .Select(g => new
                {
                    Hora = g.Key.ToString(@"hh\:mm"),
                    Cantidad = g.Count()
                })
                .ToList();

            var horasDisponibles = todasLasHoras.Select(h => new
            {
                Hora = h,
                EspaciosDisponibles = 4 - (reservasPorHora.FirstOrDefault(r => r.Hora == h)?.Cantidad ?? 0)
            })
            .Where(h => h.EspaciosDisponibles > 0)
            .ToList();

            return Json(horasDisponibles, JsonRequestBehavior.AllowGet);
        }











        /// //////////////// Admin //////////////////

        // GET: Reservas/Edit/5
        [Authorize(Roles = "Administrador")]

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

            var servicioSeleccionado = servicios.FirstOrDefault(s => s.idServicio == modeloReserva.idServicio);
            ViewBag.ModalidadServicio = servicioSeleccionado?.modalidad ?? "";

            return View(modeloReserva);
            
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ReservasDto modeloReserva,string ModalidadServicio)
        {
            try
            {

                if (ModalidadServicio == "Domicilio" && string.IsNullOrWhiteSpace(modeloReserva.direccion))
                {
                    ModelState.AddModelError("direccion", "La dirección es requerida para servicio a domicilio.");
                    CargarListasVista();
                    return View(modeloReserva);
                }


                DateTime fechaSeleccionada = DateTime.Parse(modeloReserva.fecha);
                TimeSpan horaSeleccionada = TimeSpan.Parse(modeloReserva.hora);

                if (fechaSeleccionada < DateTime.Today)
                {
                    ModelState.AddModelError("fecha", "La fecha no puede ser anterior a hoy.");
                    CargarListasVista(); // recargar dropdowns
                    return View(modeloReserva);
                }

                // Verificar cantidad de reservas existentes en la hora
                var reservasEnHora = _context.ReservasTabla
                    .Count(r => r.fecha == fechaSeleccionada && r.hora == horaSeleccionada && r.idReserva != modeloReserva.idReserva);

                if (reservasEnHora >= 4)
                {
                    ModelState.AddModelError("hora", "Ya hay 4 reservas registradas en esta hora.");
                    CargarListasVista(); // recargar dropdowns
                    return View(modeloReserva);
                }

                string datosanteriores = TempData["DatosAnteriores"] as string;
                int resultado = await _editarReservaAdmin.EditarPersonas(modeloReserva, datosanteriores);

               

                var reservaEnDb = _context.ReservasTabla.Find(modeloReserva.idReserva);
                if (reservaEnDb == null)
                {
                    ModelState.AddModelError("", "Reserva no encontrada.");
                    CargarListasVista();
                    return View(modeloReserva);
                }

                reservaEnDb.direccion = modeloReserva.direccion; // Guardar dirección
                                                                 // Actualiza otros campos si tienes...

                // Guardar cambios
                await _context.SaveChangesAsync();

                return RedirectToAction("Reservas");
            }
            catch
            {
                CargarListasVista();
                return View(modeloReserva);
            }
        }

        private void CargarListasVista()
        {
            ViewBag.Servicios = _listarServicios.ListarServicios().Where(s => s.estado).ToList();
            ViewBag.Empleados = _listarEmpleado.ListarEmpleados().Where(e => e.estado).ToList();
        }

        // AJAX: Horas disponibles sin importar el servicio
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public JsonResult ObtenerHorasDisponiblesAdmin(string fecha)
        {
            List<string> todasLasHoras = new List<string>
    {
        "08:00", "09:00", "10:00", "11:00",
        "13:00", "14:00", "15:00", "16:00"
    };

            DateTime fechaSeleccionada = DateTime.Parse(fecha);

            var reservasPorHora = _context.ReservasTabla
                .Where(r => r.fecha == fechaSeleccionada)
                .ToList()
                .GroupBy(r => r.hora)
                .Select(g => new
                {
                    Hora = g.Key.ToString(@"hh\:mm"),
                    Cantidad = g.Count()
                })
                .ToList();

            var horasDisponibles = todasLasHoras.Select(h => new
            {
                Hora = h,
                EspaciosDisponibles = 4 - (reservasPorHora.FirstOrDefault(r => r.Hora == h)?.Cantidad ?? 0)
            })
            .Where(h => h.EspaciosDisponibles > 0)
            .ToList();

            return Json(horasDisponibles, JsonRequestBehavior.AllowGet);
        }




        // GET: Reservas/Edit/5
    
        [Authorize(Roles = "Usuario")]
        public async Task<ActionResult> EditarMiReserva(int idReserva)
        {
            var modelo = _detallesReserva.Detalle(idReserva);

            // Obtengo la modalidad del servicio asociado
            var servicio = await _detalleServicios.DetalleAsync(modelo.idServicio);
            ViewBag.ModalidadServicio = servicio?.modalidad ?? "";

            return View(modelo);
        }

        // POST: Reservas/EditarMiReserva
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Usuario")]
        public async Task<ActionResult> EditarMiReserva(ReservasDto modeloReserva, string ModalidadServicio)
        {
            try
            {
                var servicio = await _detalleServicios.DetalleAsync(modeloReserva.idServicio);
                string modalidad = servicio?.modalidad ?? "";

                // Validación de dirección si es domicilio
                if (modalidad.ToLower().Contains("domicilio") && string.IsNullOrWhiteSpace(modeloReserva.direccion))
                {
                    ModelState.AddModelError("direccion", "La dirección es requerida para servicio a domicilio.");
                }

                DateTime fechaSeleccionada;
                TimeSpan horaSeleccionada;

                if (!DateTime.TryParse(modeloReserva.fecha, out fechaSeleccionada))
                {
                    ModelState.AddModelError("fecha", "Fecha inválida.");
                    return View(modeloReserva);
                }

                if (!TimeSpan.TryParse(modeloReserva.hora, out horaSeleccionada))
                {
                    ModelState.AddModelError("hora", "Hora inválida.");
                    return View(modeloReserva);
                }

                // Validar que la fecha no sea pasada
                if (fechaSeleccionada.Date < DateTime.Today)
                {
                    ModelState.AddModelError("fecha", "La fecha no puede ser anterior a hoy.");
                    return View(modeloReserva);
                }

                // Validar si está dentro del horario de atención
                var horaApertura1 = new TimeSpan(8, 0, 0);   // 08:00 AM
                var horaCierre1 = new TimeSpan(12, 0, 0);    // 12:00 PM

                var horaApertura2 = new TimeSpan(13, 0, 0);  // 01:00 PM
                var horaCierre2 = new TimeSpan(17, 0, 0);    // 05:00 PM

                bool esHoraValida =
                    (horaSeleccionada >= horaApertura1 && horaSeleccionada < horaCierre1) ||
                    (horaSeleccionada >= horaApertura2 && horaSeleccionada < horaCierre2);

                if (!esHoraValida)
                {
                    ModelState.AddModelError("hora", "La hora seleccionada está fuera del horario de atención (08:00–12:00 y 13:00–17:00).");
                    return View(modeloReserva);
                }

                // Guardar cambios
                int cantidadDeDatosEditados = await _editarReservaCliente.EditarPersonas(modeloReserva);

                

                var reservaEnDb = _context.ReservasTabla.Find(modeloReserva.idReserva);
                if (reservaEnDb == null)
                {
                    ModelState.AddModelError("", "Reserva no encontrada.");
                    CargarListasVista();
                    return View(modeloReserva);
                }

                reservaEnDb.direccion = modeloReserva.direccion; // Guardar dirección
                                                                

                // Guardar cambios
                await _context.SaveChangesAsync();

                return RedirectToAction("MisReservas");
            }
            catch
            {
                return View(modeloReserva);
            }
        }

        public JsonResult ObtenerHorasDisponiblesEditar(string fecha)
        {
            List<string> todasLasHoras = new List<string>
    {
        "08:00", "09:00", "10:00", "11:00",
        "13:00", "14:00", "15:00", "16:00"
    };

            DateTime fechaSeleccionada = DateTime.Parse(fecha);

            // Agrupar todas las reservas por hora, sin filtrar por servicio
            var reservasPorHora = _context.ReservasTabla
                .Where(r => r.fecha == fechaSeleccionada)
                .ToList()
                .GroupBy(r => r.hora)
                .Select(g => new
                {
                    Hora = g.Key.ToString(@"hh\:mm"),
                    Cantidad = g.Count()
                })
                .ToList();

            var horasDisponibles = todasLasHoras.Select(h => new
            {
                Hora = h,
                EspaciosDisponibles = 4 - (reservasPorHora.FirstOrDefault(r => r.Hora == h)?.Cantidad ?? 0)
            })
            .Where(h => h.EspaciosDisponibles > 0)
            .ToList();

            return Json(horasDisponibles, JsonRequestBehavior.AllowGet);
        }



        /// ////////////////  //////////////////



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
