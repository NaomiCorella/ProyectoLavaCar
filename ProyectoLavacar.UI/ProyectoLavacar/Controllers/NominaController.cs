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

        }
        // GET: Nomina
        public ActionResult Index()
        {
            ViewBag.Title = "Nomina";
            List<GeneralDto> lalistadeNomina = _listarGeneralEmpleadosNom.ListarNomina();

            return View(lalistadeNomina);
        }
        public ActionResult ProcesosYGestiones(int idNomina)
        {
            NominaCompletaDto nomina = _detalleNominaCompleta.Detalle(idNomina);
            return View(nomina);
        }

        public ActionResult Nomina(string idEmpleado)
        {
            ViewBag.Title = "Nomina de Empleado";
            List<UnicoEmpleadoDto> lalistadeNomina = _listarNominadelEmpleado.ListarNomina(idEmpleado);
            return View(lalistadeNomina);
        }

        // GET: Nomina/Details/5
        public ActionResult Details(int id)
        {
            NominaCompletaDto nomina = _detalleNominaCompleta.Detalle(id);
            return View(nomina);
        }

        // GET: Nomina/Create
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
               
                int cantidadDeDatosGuardados = await _crearNomina.RegistrarNomina(modeloDeNomina,  id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

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
                    return RedirectToAction("Index");
                }


                  
            }
            catch
            {
                return View();
            }
        }


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
                    return RedirectToAction("Index");
                }



            }
            catch
            {
                return View();
            }
        }


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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ListarTramites(int idNomina)
        {
            List<TramitesDto> tramites = _listarTramites.ListarTodo(idNomina);
            ViewBag.idNomina = idNomina;
            return View(tramites);
        }
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

        public async Task<ActionResult> AnularAjustes(int  id)
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
                        tipo ="Deduccion",
                        estado = false
                    };

                    int cantidadDeDatosGuardados = await _crearAjustes.RegistarAjusteSalariales(ajuste);
                }
                else
                {
                    AjustesSalarialesDto ajuste = new AjustesSalarialesDto()
                    {
                        IdAjusteSalarial = modeloDeAjustes.IdAjusteSalarial,
                        IdNomina = modeloDeAjustes.IdNomina,
                        Monto = modeloDeAjustes.Monto,
                        Razon = "Anulacion de deduccion",
                        tipo = "Bonificacion",
                        estado = false

                    };

                    int cantidadDeDatosGuardados = await _crearAjustes.RegistarAjusteSalariales(ajuste);
                }
                    return RedirectToAction("Index");
        
        }
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

            return RedirectToAction("Index");
        }

        public ActionResult Error()
        {

            return View();
        }

        // GET: Nomina/Edit/5

        public FileResult DescargarPDFDetalle(int id)
        {
            NominaCompletaDto nomina = _detalleNominaCompleta.Detalle(id);
            List<AjustesSalarialesDto> listaDeAjustes = _listarAjustes.ListarTodo().Where(p => p.IdNomina == id).ToList();
            if (nomina == null)
            {
                return null;
            }

            // Crear el PDF
            MemoryStream ms = new MemoryStream();
            Document doc = new Document(PageSize.A4, 40, 40, 40, 40); // Márgenes
            PdfWriter.GetInstance(doc, ms).CloseStream = false;

            doc.Open();

            // Colores y fuentes personalizados
            BaseColor headerColor = new BaseColor(27, 50, 85); // Azul oscuro (como en tu vista)
            BaseColor textColor = BaseColor.BLACK;
            BaseColor backgroundColor = new BaseColor(240, 240, 240); // Gris claro para fondo de celdas

            Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.WHITE);
            Font cellFont = FontFactory.GetFont(FontFactory.HELVETICA, 12, textColor);
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, headerColor);

            // Título
            Paragraph title = new Paragraph($"Detalles de al nomina de - {nomina.FechaDePago}\n\n", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            // Crear tabla similar a la vista
            PdfPTable table = new PdfPTable(2) { WidthPercentage = 100 };
            table.SetWidths(new float[] { 1.5f, 2f }); // Ancho de las columnas

            // Encabezado de tabla (como el fondo azul en tu vista)
            PdfPCell headerCell = new PdfPCell(new Phrase("Información de la nomina", headerFont))
            {
                Colspan = 2,
                HorizontalAlignment = Element.ALIGN_CENTER,
                BackgroundColor = headerColor,
                Padding = 10
            };
            table.AddCell(headerCell);

            // Agregar filas con datos

            AgregarFila(table, "Nombre:", nomina.nombre, cellFont, BaseColor.WHITE);
            AgregarFila(table, "Salario Bruto:", nomina.SalarioBruto.ToString(), cellFont, backgroundColor);
            AgregarFila(table, "Horas Extra:", $"₡{nomina.HorasExtras}", cellFont, BaseColor.WHITE);
            AgregarFila(table, "Dias de Vacaciones Disponibles:", $"₡{nomina.DiasDispoVacaciones}", cellFont, BaseColor.WHITE);
            AgregarFila(table, "Dias de Vacaciones Utilizados:", $"₡{nomina.DiasUtiliVacaciones}", cellFont, BaseColor.WHITE);
            AgregarFila(table, "Bonificaciones:", $"₡{nomina.totalBono}", cellFont, BaseColor.WHITE);
            AgregarFila(table, "Deducciones:", $"₡{nomina.totalDedu}", cellFont, BaseColor.WHITE);
            foreach(AjustesSalarialesDto ajuste in listaDeAjustes)
            {
                if(ajuste.tipo == "Bonificacion"&& ajuste.estado)
                {
                    AgregarFilaBon(table, "Bonificacion:", $"₡{ajuste.Monto}", $"₡{ajuste.Razon}", cellFont, BaseColor.WHITE);

                }
               if(ajuste.tipo == "Deduccion" && ajuste.estado)
                {
                    AgregarFilaBon(table, "Deduccion:", $"₡{ajuste.Monto}", $"₡{ajuste.Razon}", cellFont, BaseColor.WHITE);

                }

            }

            doc.Add(table);

            // Fecha de generación del PDF
            Paragraph fecha = new Paragraph($"\n\nFecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10));
            fecha.Alignment = Element.ALIGN_RIGHT;
            doc.Add(fecha);

            doc.Close();

            ms.Position = 0;
            return File(ms, "application/pdf", $"Nomina_{nomina.nombre}.pdf");
        }

        // Método para agregar filas a la tabla con estilos
        private void AgregarFila(PdfPTable table, string titulo, string valor, Font font, BaseColor backgroundColor)
        {
            PdfPCell cellTitulo = new PdfPCell(new Phrase(titulo, font))
            {
                BackgroundColor = backgroundColor,
                Padding = 8,
                BorderWidth = 1
            };

            PdfPCell cellValor = new PdfPCell(new Phrase(valor, font))
            {
                BackgroundColor = backgroundColor,
                Padding = 8,
                BorderWidth = 1
            };

            table.AddCell(cellTitulo);
            table.AddCell(cellValor);
        }
        private void AgregarFilaBon(PdfPTable table, string titulo, string valor,string tipo, Font font, BaseColor backgroundColor)
        {
            PdfPCell cellTitulo = new PdfPCell(new Phrase(titulo, font))
            {
                BackgroundColor = backgroundColor,
                Padding = 8,
                BorderWidth = 1
            };

            PdfPCell cellValor = new PdfPCell(new Phrase(valor, font))
            {
                BackgroundColor = backgroundColor,
                Padding = 8,
                BorderWidth = 1
            };
            PdfPCell cell = new PdfPCell(new Phrase(tipo, font))
            {
                BackgroundColor = backgroundColor,
                Padding = 8,
                BorderWidth = 1
            };

            table.AddCell(cellTitulo);
            table.AddCell(cellValor);
            table.AddCell(cell);
        }
    }
}
