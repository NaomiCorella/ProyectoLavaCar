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

                return RedirectToAction("ProcesosYGestiones", new { idNomina = modeloDeAjustes.IdNomina });
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
                    return RedirectToAction("ProcesosYGestiones", new { idNomina = modeloDeTramites.IdNomina });
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
                    return RedirectToAction("MiPerfil");
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

                return RedirectToAction("ListarTramites", new { idNomina = ajustepasado.IdNomina });
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
            return RedirectToAction("ListarAjustes", new { idNomina = modeloDeAjustes.IdNomina });

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

            return RedirectToAction("ProcesosYGestiones", new { idNomina = nomina.IdNomina });
        }

        public ActionResult Error()
        {

            return View();
        }

        // GET: Nomina/Edit/5

        public FileResult DescargarPDFCompra(int idNomina)
        {
            NominaCompletaDto nomina = _detalleNominaCompleta.Detalle(idNomina);

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
            BaseColor headerColor = new BaseColor(100, 150, 200);
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
            headerTable.AddCell(new PdfPCell(new Phrase("INFORME DE Nomina", titleFont)) { Border = PdfPCell.NO_BORDER });
            headerTable.AddCell(empresaCell);
            doc.Add(headerTable);

            // TÍTULO
            Paragraph title = new Paragraph($"Informe \n\n", titleFont)
            {
                Alignment = Element.ALIGN_CENTER
            };
            doc.Add(title);

            // DATOS DEL CLIENTE
            PdfPTable clienteTable = new PdfPTable(2) { WidthPercentage = 100 };
            clienteTable.SetWidths(new float[] { 1.5f, 2f });

            AgregarFila(clienteTable, "Cliente:", $"{compra.Nombre} {compra.PrimerApellido} {compra.SegundoApellido}", cellFont);
            AgregarFila(clienteTable, "Cédula:", compra.Cedula.ToString(), cellFont);
            AgregarFila(clienteTable, "Fecha de Compra:", DateTime.Parse(compra.Fecha).ToString("dd/MM/yyyy"), cellFont);

            doc.Add(clienteTable);

            doc.Add(new Paragraph("\n"));

            // DETALLES DEL SERVICIO
            PdfPTable servicioTable = new PdfPTable(2) { WidthPercentage = 100 };
            servicioTable.SetWidths(new float[] { 3, 2 });
            AgregarEncabezado(servicioTable, "Servicio", cellFont, headerColor);
            AgregarEncabezado(servicioTable, "Precio", cellFont, headerColor);
            foreach (ServiciosDto servicio in compra.listaDeServicios)
            {


                servicioTable.AddCell(new PdfPCell(new Phrase(servicio.nombre, cellFont)) { Padding = 8, BorderWidth = 1 });
                servicioTable.AddCell(new PdfPCell(new Phrase($"₡{servicio.precio:N2}", cellFont)) { Padding = 8, BorderWidth = 1 });
            }
            AgregarEncabezado(servicioTable, "Comentarios del servicio", cellFont, headerColor);
            servicioTable.AddCell(new PdfPCell(new Phrase(compra.DescripcionServicio, cellFont)) { Padding = 8, BorderWidth = 1 });


            doc.Add(servicioTable);


            doc.Add(new Paragraph("\n"));

            // TOTAL
            PdfPTable totalTable = new PdfPTable(2) { WidthPercentage = 50, HorizontalAlignment = Element.ALIGN_RIGHT };
            totalTable.SetWidths(new float[] { 1.5f, 2f });

            AgregarFila(totalTable, "Total:", $"₡{compra.Total:N2}", totalFont);
            doc.Add(totalTable);

            // PIE DE PÁGINA
            Paragraph footer = new Paragraph("\nGracias por confiar en nosotros.\nLavaCar HERVI", FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10))
            {
                Alignment = Element.ALIGN_CENTER
            };
            doc.Add(footer);

            doc.Close();
            ms.Position = 0;
            return File(ms, "application/pdf", $"Factura_Servicio_{idNomina}.pdf");
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
