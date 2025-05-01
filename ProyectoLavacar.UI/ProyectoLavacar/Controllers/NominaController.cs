using iTextSharp.text.pdf;
using iTextSharp.text;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.BuscarPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearAccidente;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearAjusteSalariales;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.DetalleNominaCompleta;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.DetallesAjustes;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.DetallesTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarAjustes;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarAjustes;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarGeneral;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ProcesarNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.LN.ModuloAjustesSalariales.CrearAjustesSalariales;
using ProyectoLavacar.LN.ModuloEmpleados.BuscarPorId;
using ProyectoLavacar.LN.ModuloNomina.CrearNomina;
using ProyectoLavacar.LN.ModuloNomina.CrearTramites;
using ProyectoLavacar.LN.ModuloNomina.DetalleAjustes;
using ProyectoLavacar.LN.ModuloNomina.DetalleNominaCompleta;
using ProyectoLavacar.LN.ModuloNomina.DetallesTramites;
using ProyectoLavacar.LN.ModuloNomina.EditarNomina;
using ProyectoLavacar.LN.ModuloNomina.EditarTramites;
using ProyectoLavacar.LN.ModuloNomina.ListarAjustes;
using ProyectoLavacar.LN.ModuloNomina.ListarGeneral;
using ProyectoLavacar.LN.ModuloNomina.ListarTramites;
using ProyectoLavacar.LN.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.LN.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.LN.ModuloNomina.ProcesarNomina;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCorreos;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using System.Xml.Linq;
using ProyectoLavacar.AccesoADatos;

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
        ICrearRebajoLN _crearAccidentes;
        IListarTramitesLN _listarTramites;
        IListarAjustesLN _listarAjustes;
        IEditarTramitesLN _editarTramites;
        IEditarAjusteLN _editarAjustes;
        IDetallesAjustesLN _detallesAjustes;
        IDetallesTramitesLN _detallesTramites;
        IProcesarNominaLN _procesarNomina;
        IBuscarPorIdLN _buscarPorIdEmpleado;
        IEmailSender _emailSender;
        Contexto _context;
        public NominaController()
        {
            _buscarPorIdEmpleado = new BuscarPorIdLN();
            _emailSender = (IEmailSender)System.Web.HttpContext.Current.Application["EmailSender"];
            _crearAjustes = new CrearAjustesSalarialesLN();
            _crearNomina = new CrearNominaLN();
            _crearTramites = new CrearTramitesLN();
            _detalleNominaCompleta = new DetalleNominaCompletoLN();
            _editarNomina = new EditarNominaLN();
            _listarGeneralEmpleadosNom = new ListarGeneralLN();
            _listarNominadelEmpleado = new ListarUnicoEmpleadoLN();
            _obtenerporId = new ObtenerPorIdLN();
            _listarTramites = new ListarTramitesLN();
            _listarAjustes = new ListarAjustesLN();
            _editarTramites = new EditarTramitesLN();
            _detallesAjustes = new DetallesAjustesLN();
             _detallesTramites = new DetallesTramitesLN();
            _procesarNomina = new ProcesarNominaLN();
            _context = new Contexto();

        }
        // GET: Nomina
        [Authorize(Roles = "Administrador, Empleado")]
        public ActionResult Index()
        {
            ViewBag.Title = "Nomina";
            List<GeneralDto> lalistadeNomina = _listarGeneralEmpleadosNom.ListarNomina();

            return View(lalistadeNomina);
        }
        [Authorize(Roles = "Administrador, Empleado")]
        public ActionResult ProcesosYGestiones(int idNomina)
        {
            NominaCompletaDto nomina = _detalleNominaCompleta.Detalle(idNomina);
            return View(nomina);
        }
        [Authorize(Roles = "Administrador, Empleado")]
        public ActionResult Nomina(string idEmpleado)
        {
            ViewBag.Title = "Nomina de Empleado";
            List<UnicoEmpleadoDto> lalistadeNomina = _listarNominadelEmpleado.ListarNomina(idEmpleado);
            return View(lalistadeNomina);
        }
        [Authorize(Roles = "Administrador, Empleado")]
        // GET: Nomina/Details/5
        public ActionResult Details(int id)
        {
            NominaCompletaDto nomina = _detalleNominaCompleta.Detalle(id);
            return View(nomina);
        }

        // GET: Nomina/Create
        [Authorize(Roles = "Administrador, Empleado")]
        public ActionResult Create(string id)
        {
            ViewBag.Periodo = new List<SelectListItem>
    {
        new SelectListItem { Value = "Quincenal", Text = "Quincenal" },
        new SelectListItem { Value = "Mensual", Text = "Mensual" }
    };
            ViewBag.tipo = new List<SelectListItem>
    {
        new SelectListItem { Value = "Indefinido", Text = "Indefinido" },
        new SelectListItem { Value = "CortoPlazo", Text = "Corto Plazo" },
                new SelectListItem { Value = "LargoPlazo", Text = "Largo Plazo" }

    };
            return View();
        }

        // POST: Nomina/Create
        [HttpPost]
        public async Task<ActionResult> Create(NominaDto modeloDeNomina,string id)
        {
            try
            {
               

                    if (modeloDeNomina.FechaDePago < DateTime.Now)
                    {
                        ModelState.AddModelError("Fecha", "La fecha no puede ser anterior a la fecha de hoy.");
                        return View(modeloDeNomina);
                    }
                
                int cantidadDeDatosGuardados = await _crearNomina.RegistrarNomina(modeloDeNomina,  id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Administrador, Empleado")]

        public ActionResult IngresarAjustes(int idNomina)
        {
            ViewBag.tipo = new List<SelectListItem>
    {
        new SelectListItem { Value = "Deduccion", Text = "Deduccion" },
        new SelectListItem { Value = "Bonificacion", Text = "Bonificacion" }
    };

            ViewBag.RazonDeduccion = new List<SelectListItem>
    {
        new SelectListItem { Value = "Sancion", Text = "Sancion por mal comportamiento" },
        new SelectListItem { Value = "Deuda", Text = "Deuda personal" },
        new SelectListItem { Value = "Malgasto", Text = "Malgasto de productos" },
        new SelectListItem { Value = "MalaGestion", Text = "Mala gestion de equipo" }

    };

            ViewBag.RazonBonificacion = new List<SelectListItem>
    {
        new SelectListItem { Value = "TrabajadorDelMes", Text = "Trabajador del mes" },
        new SelectListItem { Value = "MayoresCarrosLavados", Text = "Mayor cantidad de carros lavados" },
        new SelectListItem { Value = "BuenComportamiento", Text = "Buen comportamiento" }

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
                    tipo = modeloDeAjustes.tipo,
                    estado = true
                };

                int cantidadDeDatosGuardados = await _crearAjustes.RegistarAjusteSalariales(ajuste);

                return RedirectToAction("ProcesosYGestiones", new { idNomina = modeloDeAjustes.IdNomina });
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Administrador, Empleado")]

        public ActionResult IngresarTramites(int idNomina)
        {
            ViewBag.tipo = new List<SelectListItem>
    {
        new SelectListItem { Value = "Incapacidad", Text = "Incapacidad" },
        new SelectListItem { Value = "Vacaciones", Text = "Vacaciones" }
    };

            ViewBag.Aseguradora = new List<SelectListItem>
    {
        new SelectListItem { Value = "INS", Text = "INS" },
        new SelectListItem { Value = "CSSS", Text = "CSSS" }
    };

            ViewBag.PorINS = new List<SelectListItem>
    {
        new SelectListItem { Value = "Temporal", Text = "Temporal" },
        new SelectListItem { Value = "Menor Permanente", Text = "Menor Permanente" },
        new SelectListItem { Value = "ParcialPermanente", Text = "Parcial Permanente" },
        new SelectListItem { Value = "TotalPermanente", Text = "Total Permanente" },
        new SelectListItem { Value = "GranInvalido", Text = "Gran Invalido" }
    };

            ViewBag.PorCSSS = new List<SelectListItem>
    {
        new SelectListItem { Value = "Enfermedad", Text = "Enfermedad" },
        new SelectListItem { Value = "LicenciasDeMaternidad", Text = "Licencias De Maternidad" },
        new SelectListItem { Value = "LicenciasDeFaseTerminal", Text = "Licencias De Fase Terminal" },
        new SelectListItem { Value = "LicenciaDeCuido", Text = "Licencia para cuido de persona menor gravemente enferma." },
        new SelectListItem { Value = "LicenciaExtraordinaria", Text = "Licencia Extraordinaria" },
        new SelectListItem { Value = "AccidentesTransito", Text = "Accidentes Transito" }
    };

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> IngresarTramites(TramitesDto modeloDeTramites,int idNomina)
        {
            try
            {
               int cantidadDeDatosGuardados = 0;

                if (modeloDeTramites.tipo == "Vacaciones")
                {
                    TramitesDto vaca = new TramitesDto()
                    {
                        IdTramite = modeloDeTramites.IdTramite,
                        IdNomina = idNomina,
                        duracion = modeloDeTramites.duracion,
                        FechaInicio = modeloDeTramites.FechaInicio,
                        Razon = "Pedido de vacaciones",
                        tipo = modeloDeTramites.tipo,
                        estado = 1,
                        aseguradora = modeloDeTramites.aseguradora
                    };
                    cantidadDeDatosGuardados = await _crearTramites.RegistroTramites(vaca);

                }
                else
                {
                    TramitesDto tramite = new TramitesDto()
                    {
                        IdTramite = modeloDeTramites.IdTramite,
                        IdNomina = idNomina,
                        duracion = modeloDeTramites.duracion,
                        FechaInicio = modeloDeTramites.FechaInicio,
                        Razon = modeloDeTramites.Razon,
                        tipo = modeloDeTramites.tipo,
                        estado = 1,
                        aseguradora = modeloDeTramites.aseguradora
                    };
                    cantidadDeDatosGuardados = await _crearTramites.RegistroTramites(tramite);
                }



                   
                if (cantidadDeDatosGuardados == 0)
                {
                    return RedirectToAction("/Error");
                }
                else
                {
                    return RedirectToAction("ProcesosYGestiones", new { idNomina = modeloDeTramites.IdNomina });
                }


                  
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Administrador, Empleado")]

        public ActionResult IngresarVacaciones()
        {
         
            ViewBag.tipo = new List<SelectListItem>
    {
        new SelectListItem { Value = "Vacaciones", Text = "Vacaciones" }
    };
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> IngresarVacaciones(TramitesDto modeloDeTramites)
        {
            try
            {
                var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
                string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                UnicoEmpleadoDto nomina = _listarNominadelEmpleado.ListarNomina(idEmpleado).LastOrDefault();
                TramitesDto tramite = new TramitesDto()
                {
                    IdTramite = modeloDeTramites.IdTramite,
                    IdNomina = nomina.IdNomina,
                    duracion = modeloDeTramites.duracion,
                    FechaInicio = modeloDeTramites.FechaInicio,
                    Razon = modeloDeTramites.Razon,
                    tipo = "Vacaciones",
                    estado = 0,
                };


                int cantidadDeDatosGuardados = await _crearTramites.RegistroTramites(tramite);
                if (cantidadDeDatosGuardados == 0)
                {
                    return RedirectToAction("/Error");
                }
                else
                {
                    return RedirectToAction("MiPerfil");
                }



            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Administrador, Empleado")]

        public ActionResult AceptarVacacion(int idTramite)
        {
            ViewBag.estado = new SelectList(new List<object>
                {
                 new { Value = 0, Text = "Pendiente" },
                 new { Value = 1, Text = "Aceptada" },
                 new { Value = 2, Text = "Denegada" }
                }, "Value", "Text");


            TramitesDto ajuste = _detallesTramites.Detalle(idTramite);

            DateTime FechaInicio = ajuste.FechaInicio; 
            int duracion = ajuste.duracion; 
            DateTime FechaFinal = FechaInicio.AddDays(duracion);
            ViewBag.FechaInicio = ajuste.FechaInicio.ToString("dd/MM/yyyy");
            ViewBag.FechaFinal = ajuste.FechaInicio.AddDays(ajuste.duracion).ToString("dd/MM/yyyy"); 
            return View(ajuste);
           
        }

        // POST: Nomina/Edit/5
        [HttpPost]
        public async Task<ActionResult> AceptarVacacion(TramitesDto ajuste, int idTramite)
        {
            try
            {
                TramitesDto ajustepasado = _detallesTramites.Detalle(idTramite);
                TramitesDto tramite = new TramitesDto
                {
                    IdTramite = ajustepasado.IdTramite,
                    estado = ajuste.estado,
                    duracion = ajustepasado.duracion,
                    FechaInicio = ajustepasado.FechaInicio,
                    IdNomina = ajustepasado.IdNomina,
                    Razon = ajustepasado.Razon,
                    tipo = ajustepasado.tipo
                };

                int cantidadDeDatosEditados = await _editarTramites.Editar(tramite);

                return RedirectToAction("ListarTramites", new { idNomina = ajustepasado.IdNomina });
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Administrador, Empleado")]

        public ActionResult ListarTramites(int idNomina)
        {
            List<TramitesDto> tramites = _listarTramites.ListarTodo(idNomina);
            ViewBag.idNomina = idNomina;
            return View(tramites);
        }
        [Authorize(Roles = "Administrador, Empleado")]

        public ActionResult ListarAjustes(int idNomina)
        {
            ViewData["idNomina"] = idNomina;
            List<AjustesSalarialesDto> tramites = _listarAjustes.ListarTodo().Where(p => p.IdNomina == idNomina).ToList();
       
            return View(tramites);
        }

        public ActionResult FiltrarPorProducto(int idNomina, bool? estado)
        {
            ViewData["idNomina"] = idNomina; // Mantener idNomina en la vista
            ViewBag.Title = "Ajustes Filtrado";

            var ajustes = _listarAjustes.ListarTodo().Where(p => p.IdNomina == idNomina);

            // Aplicar el filtro solo si estado tiene un valor
            if (estado.HasValue)
            {
                ajustes = ajustes.Where(p => p.estado == estado.Value);
            }

            return View("ListarAjustes", ajustes.ToList());
        }

        public async Task<ActionResult> AnularAjustes(int id)
        {
           

                AjustesSalarialesDto modeloDeAjustes = _detallesAjustes.Detalle(id);

                if(modeloDeAjustes.tipo == "Bonificacion")
                {
                    AjustesSalarialesDto ajuste = new AjustesSalarialesDto()
                    {
                        IdAjusteSalarial = modeloDeAjustes.IdAjusteSalarial,
                        IdNomina = modeloDeAjustes.IdNomina,
                        Monto = modeloDeAjustes.Monto,
                        Razon = "Anulacion de bono",
                        tipo = "Bonificacion",
                        estado = false
                    };

                    int cantidadDeDatosGuardados = await _crearAjustes.RegistarAjusteSalariales(ajuste);
                CambiarEstado(id);
                }
                else
                {
                    AjustesSalarialesDto ajuste = new AjustesSalarialesDto()
                    {
                        IdAjusteSalarial = modeloDeAjustes.IdAjusteSalarial,
                        IdNomina = modeloDeAjustes.IdNomina,
                        Monto = modeloDeAjustes.Monto,
                        Razon = "Anulacion de deduccion",
                        tipo = "Deduccion",
                        estado = false

                    };

                    int cantidadDeDatosGuardados = await _crearAjustes.RegistarAjusteSalariales(ajuste);
                CambiarEstado(id);
            }
            return RedirectToAction("ListarAjustes", new { idNomina = modeloDeAjustes.IdNomina });

        }
        [Authorize(Roles = "Administrador, Empleado")]

        public ActionResult ProcesarNomina(int idNomina)
        {
            NominaDto nomina = _obtenerporId.Detalle(idNomina);
            EmpleadoDto usuario =_buscarPorIdEmpleado.Detalle(nomina.IdEmpleado);
            UnicoEmpleadoDto nominaEmpleado = new UnicoEmpleadoDto
            {
                IdNomina = nomina.IdNomina,
                IdEmpleado = nomina.IdEmpleado,
                SalarioBruto = nomina.SalarioBruto,
                SalarioNeto = nomina.SalarioNeto,
                HorasExtras = nomina.HorasExtras,
                HorasDobles = nomina.HorasDobles,
                HorasOrdinarias = nomina.HorasOrdinarias,
                PeriodoDePago = nomina.PeriodoDePago,
                FechaDePago = nomina.FechaDePago,
                TipoDeContrato = nomina.TipoDeContrato,
                DiasDispoVacaciones = nomina.DiasDispoVacaciones,
                DiasUtiliVacaciones = nomina.DiasUtiliVacaciones,
                Incapacidad = nomina.Incapacidad,
                Estado = nomina.Estado,
                totalBono = nomina.totalBono,
                totalDedu = nomina.totalDedu,
                nombre = usuario.nombre,
                primer_apellido = usuario.primer_apellido
            };
            ViewBag.total = _procesarNomina.Total(idNomina);
            return View(nominaEmpleado);
        }
        

        public async Task<ActionResult> ConfimarNomina(int idNomina)
        {
            NominaDto nomina = _procesarNomina.ProcesarNomina(idNomina);
            List<AjustesSalarialesDto> ajustes = _listarAjustes.ListarTodo().Where(p => p.IdNomina == idNomina).ToList();
            if (nomina == null)
            {
                TempData["ErrorMessage"] = "No se pudo procesar la nómina.";
                return RedirectToAction("Index");
            }

            EmpleadoDto usuario = _buscarPorIdEmpleado.Detalle(nomina.IdEmpleado);
            if (usuario == null || string.IsNullOrEmpty(usuario.Email))
            {
                TempData["ErrorMessage"] = "No se pudo obtener el correo del empleado.";
                return RedirectToAction("Index");
            }

            string asunto = "Confirmación de Nómina";
            string mensaje = $"Estimado {usuario.nombre} {usuario.primer_apellido},<br><br>" +
                             $"Se ha procesado su nómina correspondiente al período {nomina.PeriodoDePago}.<br>" +
                             $"Salario Neto: {nomina.SalarioNeto:C2} <br>" +
                             $"Fecha de Pago: {nomina.FechaDePago:dd/MM/yyyy} <br><br>" +
                             $"Saludos,<br>Administración";

            try
            {
                await _emailSender.SendEmailAsync(usuario.Email, asunto, mensaje);
                TempData["SuccessMessage"] = "Nómina confirmada y correo enviado correctamente.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "La nómina fue confirmada, pero ocurrió un error al enviar el correo.";
            }

            return RedirectToAction("ProcesosYGestiones", new { idNomina = nomina.IdNomina });
        }

        public ActionResult CambiarEstado(int id)
        {

            try
            {
                var ajuste = _context.AjustesSalarialesTabla.Find(id);
                ajuste.estado = !ajuste.estado;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Nomina/Edit/5

        public FileResult DescargarPDFDetalle(int idNomina)
        {
            NominaCompletaDto nomina = _detalleNominaCompleta.Detalle(idNomina);
            List<AjustesSalarialesDto> bonos = _listarAjustes.ListarTodo().Where(p => p.IdNomina == idNomina  && p.tipo == "Bonificacion" && p.estado).ToList();
            List<AjustesSalarialesDto> dedu = _listarAjustes.ListarTodo().Where(p => p.IdNomina == idNomina && p.tipo == "Deduccion" && p.estado).ToList();
            List<TramitesDto> Incapacidades =  _listarTramites.ListarTodo(idNomina).Where(p => p.tipo == "Incapacidad").ToList();
            List<TramitesDto> vaca = _listarTramites.ListarTodo(idNomina).Where(p => p.tipo == "Vacaciones" && p.estado == 1).ToList();

            if (nomina == null)
            {
                return null;
            }

            // Crear PDF
            MemoryStream ms = new MemoryStream();
            Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            writer.CloseStream = false;

            doc.Open();

            // Fuentes y colores
            BaseColor headerColor = new BaseColor(211, 211, 211);
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, headerColor);
            Font subHeaderFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK);
            Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK);
            Font totalFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK);

            // ENCABEZADO 
            PdfPTable headerTable = new PdfPTable(2) { WidthPercentage = 100 };
            headerTable.SetWidths(new float[] { 1, 2 });

            PdfPCell empresaCell = new PdfPCell(new Phrase("LavaCar HERVI \nTel: +(506) 7285 0302 \nCorreo: lavacarhervi@gmail.com", cellFont))
            {
                Border = PdfPCell.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT
            };
            headerTable.AddCell(new PdfPCell(new Phrase("Informe de Nomina", titleFont)) { Border = PdfPCell.NO_BORDER });
            headerTable.AddCell(empresaCell);
            doc.Add(headerTable);

            Paragraph empleado = new Paragraph("Informacion del empleado", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD));
            empleado.Alignment = Element.ALIGN_LEFT;
            empleado.SpacingAfter = 10f; // Espacio después del título
            doc.Add(empleado);

            var tablaEmpleado = new PdfPTable(2); // 2 columnas
            tablaEmpleado.WidthPercentage = 100f; // Establecer el ancho de la tabla a 100%

            // Definir el ancho de las columnas
            float[] anchosColumnas = new float[] { 50f, 50f }; // Las columnas ocuparán el 50% cada una
            tablaEmpleado.SetWidths(anchosColumnas);

            // Crear un color gris claro para el fondo
            BaseColor grisClaro = new BaseColor(211, 211, 211); // Color RGB de gris claro

            // Agregar las celdas con la información del empleado

            // Empleado
            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Empleado: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) { BackgroundColor = grisClaro });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase($"{nomina.nombre} {nomina.primer_apellido} {nomina.segundo_apellido}", cellFont)));

            // Cédula
            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Cédula: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) { BackgroundColor = grisClaro });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase($"{nomina.cedula}", cellFont)));

            // Correo
            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Correo: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) { BackgroundColor = grisClaro });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase($"{nomina.correo}", cellFont)));

            // Puesto
            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Puesto: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) { BackgroundColor = grisClaro });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase($"{nomina.puesto}", cellFont)));

            // Turno
            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Turno: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) { BackgroundColor = grisClaro });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase($"{nomina.turno}", cellFont)));

            // Tipo de contrato
            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Tipo de contrato: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) { BackgroundColor = grisClaro });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase($"{nomina.TipoDeContrato}", cellFont)));

            // Fecha de pago
            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Fecha de Pago: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) { BackgroundColor = grisClaro });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase($"{nomina.FechaDePago:dd/MM/yyyy}", cellFont)));

            // Horas extras
            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Horas extras: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) { BackgroundColor = grisClaro });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase($"₡{nomina.HorasExtras:N2}", cellFont)));

            // Días de vacaciones disponibles
            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Días de vacaciones disponibles: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) { BackgroundColor = grisClaro });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase($"₡{nomina.DiasDispoVacaciones:N2}", cellFont)));

            // Días de vacaciones utilizados
            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Días de vacaciones utilizados: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) { BackgroundColor = grisClaro });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase($"₡{nomina.DiasUtiliVacaciones:N2}", cellFont)));

            // Salario bruto
            tablaEmpleado.AddCell(new PdfPCell(new Phrase("Salario bruto: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) { BackgroundColor = grisClaro });
            tablaEmpleado.AddCell(new PdfPCell(new Phrase($"₡{nomina.SalarioBruto:N2}", cellFont)));

            // Agregar la tabla al documento
            doc.Add(tablaEmpleado);

            // Agregar un salto de línea
            doc.Add(new Paragraph("\n"));



            if (Incapacidades != null)
            {
                // Agregar título a la sección de vacaciones
                Paragraph tituloIncapacidades = new Paragraph("Detalles de  Incapacidades", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD));
                tituloIncapacidades.Alignment = Element.ALIGN_LEFT;
                tituloIncapacidades.SpacingAfter = 10f; // Espacio después del título
                doc.Add(tituloIncapacidades);
                // DETALLES DEL Incapacidades
                PdfPTable incapa = new PdfPTable(3) { WidthPercentage = 100 };
                incapa.SetWidths(new float[] { 3, 2, 3 });
                AgregarEncabezado(incapa, "Aseguradora", cellFont, grisClaro);
                AgregarEncabezado(incapa, "Razon", cellFont, grisClaro);
                AgregarEncabezado(incapa, "Duracion", cellFont, grisClaro);
                foreach (TramitesDto ajuste in Incapacidades)
                {

                    incapa.AddCell(new PdfPCell(new Phrase(ajuste.aseguradora, cellFont)) { Padding = 8, BorderWidth = 1 });
                    incapa.AddCell(new PdfPCell(new Phrase(ajuste.Razon, cellFont)) { Padding = 8, BorderWidth = 1 });
                    incapa.AddCell(new PdfPCell(new Phrase($"₡{ajuste.duracion:N2}", cellFont)) { Padding = 8, BorderWidth = 1 });

                }

                doc.Add(incapa);


                doc.Add(new Paragraph("\n"));
            }


            if (vaca != null)
            {
                // Agregar título a la sección de vacaciones
                Paragraph tituloVacaciones = new Paragraph("Detalles de Vacaciones", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD));
                tituloVacaciones.Alignment = Element.ALIGN_LEFT;
                tituloVacaciones.SpacingAfter = 10f; // Espacio después del título

                doc.Add(tituloVacaciones);

                // DETALLES DEL Vacaciones
                PdfPTable vacaciones = new PdfPTable(2) { WidthPercentage = 100 };
                vacaciones.SetWidths(new float[] { 3, 2 });
                AgregarEncabezado(vacaciones, "Razon", cellFont, headerColor);
                AgregarEncabezado(vacaciones, "Duracion", cellFont, headerColor);

                foreach (TramitesDto ajuste in vaca)
                {
                    vacaciones.AddCell(new PdfPCell(new Phrase(ajuste.Razon, cellFont)) { Padding = 8, BorderWidth = 1 });
                    vacaciones.AddCell(new PdfPCell(new Phrase($"₡{ajuste.duracion:N2}", cellFont)) { Padding = 8, BorderWidth = 1 });
                }
              

                doc.Add(vacaciones);
                doc.Add(new Paragraph("\n"));
            }



            if (bonos != null)
            {

                // Agregar título a la sección de Bonificaciones
                Paragraph tituloBonificaciones = new Paragraph("Detalles de Bonificaciones", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD));
                tituloBonificaciones.Alignment = Element.ALIGN_LEFT;
                tituloBonificaciones.SpacingAfter = 10f; // Espacio después del título

                doc.Add(tituloBonificaciones);
                // DETALLES DEL Bonificaciones
                PdfPTable Bonificaciones = new PdfPTable(2) { WidthPercentage = 100 };
                Bonificaciones.SetWidths(new float[] { 3, 2 });
                AgregarEncabezado(Bonificaciones, "Razon", cellFont, headerColor);
                AgregarEncabezado(Bonificaciones, "Monto", cellFont, headerColor);
                foreach (AjustesSalarialesDto ajuste in bonos)
                {

                    Bonificaciones.AddCell(new PdfPCell(new Phrase(ajuste.Razon, cellFont)) { Padding = 8, BorderWidth = 1 });
                    Bonificaciones.AddCell(new PdfPCell(new Phrase($"₡{ajuste.Monto:N2}", cellFont)) { Padding = 8, BorderWidth = 1 });
                }
                AgregarFila(Bonificaciones, "Total de bonificaciones:", $"₡{nomina.totalBono:N2}", totalFont);

                doc.Add(Bonificaciones);


                doc.Add(new Paragraph("\n"));
            }


           

        


            if (dedu != null)
            {
                // Agregar título a la sección de Bonificaciones
                Paragraph tituloDeducciones = new Paragraph("Detalles de Deducciones", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD));
                tituloDeducciones.Alignment = Element.ALIGN_LEFT;
                tituloDeducciones.SpacingAfter = 10f; // Espacio después del título
                doc.Add(tituloDeducciones);
                // DETALLES DEL Deducciones
                PdfPTable Deducciones = new PdfPTable(2) { WidthPercentage = 100 };
                Deducciones.SetWidths(new float[] { 3, 2 });
                AgregarEncabezado(Deducciones, "Razon", cellFont, headerColor);
                AgregarEncabezado(Deducciones, "Monto", cellFont, headerColor);
                foreach (AjustesSalarialesDto ajuste in dedu)
                {

                    Deducciones.AddCell(new PdfPCell(new Phrase(ajuste.Razon, cellFont)) { Padding = 8, BorderWidth = 1 });
                    Deducciones.AddCell(new PdfPCell(new Phrase($"₡{ajuste.Monto:N2}", cellFont)) { Padding = 8, BorderWidth = 1 });
                }
                AgregarFila(Deducciones, "Total de deducciones:", $"₡{nomina.totalDedu:N2}", totalFont);

                doc.Add(Deducciones);


                doc.Add(new Paragraph("\n"));
            }

            Paragraph titulosalario = new Paragraph("Total a pagar:", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD));
            titulosalario.Alignment = Element.ALIGN_LEFT;
            titulosalario.SpacingAfter = 10f; // Espacio después del título
            doc.Add(titulosalario);


            var salario = new PdfPTable(2); // 2 columnas
            salario.WidthPercentage = 100f; // Establecer el ancho de la tabla a 100%

            // Definir el ancho de las columnas
            float[] sala = new float[] { 50f, 50f }; // Las columnas ocuparán el 50% cada una
            salario.SetWidths(anchosColumnas);



            // Empleado
            salario.AddCell(new PdfPCell(new Phrase("Total Bonificaciones: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) { BackgroundColor = grisClaro });
            salario.AddCell(new PdfPCell(new Phrase($"₡{nomina.totalBono:N2}", cellFont)));

            // Cédula
            salario.AddCell(new PdfPCell(new Phrase("Total Deducciones: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) { BackgroundColor = grisClaro });
            salario.AddCell(new PdfPCell(new Phrase($"₡{nomina.totalDedu:N2}", cellFont)));

            // Correo
            salario.AddCell(new PdfPCell(new Phrase("Neto a pagar: ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14))) { BackgroundColor = grisClaro });
            salario.AddCell(new PdfPCell(new Phrase($"₡{nomina.SalarioNeto:N2}", totalFont)));



            doc.Add(salario);


            doc.Add(new Paragraph("\n"));


           

            doc.Close();
            ms.Position = 0;
            return File(ms, "application/pdf", $"Detalle de Nomina_{nomina.cedula}.pdf");
        }



        private void AgregarFila(PdfPTable table, string titulo, string valor, Font font)
        {
            table.AddCell(new PdfPCell(new Phrase(titulo, font)) { Padding = 8, BorderWidth = 1 });
            table.AddCell(new PdfPCell(new Phrase(valor, font)) { Padding = 8, BorderWidth = 1 });
        }

        private void AgregarEncabezado(PdfPTable table, string texto, Font font, BaseColor backgroundColor)
        {
            PdfPCell cell = new PdfPCell(new Phrase(texto, font))
            {
                BackgroundColor = backgroundColor,
                Padding = 8,
                BorderWidth = 1,
                HorizontalAlignment = Element.ALIGN_CENTER
            };
            table.AddCell(cell);
        }
    }
}
