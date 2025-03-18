using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Extensions.Logging;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.DetalleCompraCompleta;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.ListarDisponibles;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCompra.ObtenerPorId;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using ProyectoLavacar.AccesoADatos;
using ProyectoLavacar.LN.ModuloCompra.Crear;
using ProyectoLavacar.LN.ModuloCompra.DetalleCompraCompleto;
using ProyectoLavacar.LN.ModuloCompra.Listar;
using ProyectoLavacar.LN.ModuloCompra.ListarDisponible;
using ProyectoLavacar.LN.ModuloCompra.ObtenerPorId;
using ProyectoLavacar.LN.ModuloEmpleados.Listar;
using ProyectoLavacar.LN.ModuloServicios.ListarServicios;
using ProyectoLavacar.LN.ModuloUsuarios.Listar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;


namespace ProyectoLavacar.Controllers
{
    public class CompraController : Controller
    {
        ICrearCompraLN _crearCompra;
        IListarDisponibleLN _listarCompraCliente;
        IListarLN _listarComprasAdmin;
        IObtenerPorIdLN _detallesCompra;
        IListarServiciosLN _listarServicios;

        IDetalleCompraCompletaLN _detallesCompraCompleta;
        IListarUsuarioLN _listarClientes;
        IListarEmpleadoLN _listarEmpleado;
        Contexto _context;


        public CompraController()
        {

            _crearCompra = new CrearCompraLN();
            _listarCompraCliente = new ListarDisponibleLN();
            _listarComprasAdmin = new ListarCompraLN();
            _detallesCompra = new ObtenerPorIdLN();
            _listarServicios = new ListarServiciosLN();
            _detallesCompraCompleta = new DetalleCompraCompletaLN();
            _listarClientes = new ListarUsuarioLN();
            _listarEmpleado = new ListarEmpleadoLN();
            _context = new Contexto();
        }


        public ActionResult Filtro(string fechaInicio, string fechaFin)
        {

            List<CompraCompletaDto> lalistaDeCompras = _listarComprasAdmin.ListarCompra();


            DateTime fechaInicioDT, fechaFinDT;
            bool tieneFechaInicio = DateTime.TryParse(fechaInicio, out fechaInicioDT);
            bool tieneFechaFin = DateTime.TryParse(fechaFin, out fechaFinDT);


            if (tieneFechaInicio)
            {
                lalistaDeCompras = lalistaDeCompras.Where(c => DateTime.Parse(c.Fecha) >= fechaInicioDT).ToList();
            }


            if (tieneFechaFin)
            {
                lalistaDeCompras = lalistaDeCompras.Where(c => DateTime.Parse(c.Fecha) <= fechaFinDT).ToList();
            }

            return View("Index", lalistaDeCompras);
            ;
        }



        // GET: Compra
        public ActionResult Index()
        {
            List<CompraCompletaDto> lalistaDeCompras = _listarComprasAdmin.ListarCompra();
            return View(lalistaDeCompras);
        }

        public ActionResult MisCompra() //ComprasCliente
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idCliente = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;


            List<CompraCompletaDto> lalistaDeCompras = _listarCompraCliente.Listar(idCliente);
            return View(lalistaDeCompras);
        }

        // GET: Compra/Details/5
        public ActionResult DetallesCompra(Guid IdCompra)
        {
            CompraCompletaDto compra = _detallesCompraCompleta.Detalle(IdCompra);
            return View(compra);
        }


        // GET: Compra/Create
        public ActionResult Create()
        {
            var servicios = _listarServicios.ListarServicios()
    .Where(a => a.estado == true) .ToList();
            ViewBag.Servicios = servicios;
       
            return View();
        }

        // POST: Compra/Create
        [HttpPost]
        public async Task<ActionResult> Create(CompraDto modeloDeCompra, int numeroCedula)
        {
            try
            {
                modeloDeCompra.listaServicios = modeloDeCompra.listaServicios ?? new List<int>();

                if (numeroCedula == 0)
                {
                    ModelState.AddModelError("", "Debe ingresar una cédula.");
                    return View(modeloDeCompra);
                }

                var cliente = _listarClientes.ListarUsuarios()
                    .FirstOrDefault(c => c.cedula == numeroCedula);

                if (cliente == null)
                {
                    ModelState.AddModelError("", "No se encontró un cliente con esa cédula.");
                    return View(modeloDeCompra);
                }

                TempData["ClienteEncontrado"] = $"Cliente encontrado: {cliente.nombre} {cliente.primer_apellido}";

                // Aquí procesas los servicios seleccionados
                foreach (int idServicio in modeloDeCompra.listaServicios)
                {
                    // Lógica para procesar cada servicio seleccionado
                    // Puedes buscar el servicio en la base de datos y asociarlo con la compra
                    var servicio = _listarServicios.ListarServicios().FirstOrDefault(s => s.idServicio == idServicio);

                    if (servicio == null)
                    {
                        ModelState.AddModelError("", $"No se encontró el servicio con ID {idServicio}");
                        return View(modeloDeCompra);
                    }

                    // Agregar lógica adicional si es necesario para cada servicio
                }

                CompraDto compra = new CompraDto()
                {
                    idCompra = Guid.NewGuid(),
                    idCliente = cliente.Id,
                    DescripcionServicio = modeloDeCompra.DescripcionServicio,
                    fecha = modeloDeCompra.fecha,
                    Estado = true,
                    Total = 1000,
                    listaServicios=modeloDeCompra.listaServicios
                };

                int cantidadDeDatosGuardados = await _crearCompra.CrearCompra(compra);

                if (cantidadDeDatosGuardados > 0)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Error al guardar la compra.");
                return View(modeloDeCompra);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error inesperado.");
                return View(modeloDeCompra);
            }
        }


        public JsonResult BuscarClientePorCedula(int numeroCedula)
        {
            var cliente = _listarClientes.ListarUsuarios()
                .FirstOrDefault(c => c.cedula == numeroCedula);

            if (cliente != null)
            {
                return Json(new { success = true, nombre = cliente.nombre, apellido = cliente.primer_apellido }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult ObtenerPrecioServicio(int idServicio)
        {
            var servicio = _listarServicios.ListarServicios()
                .FirstOrDefault(s => s.idServicio == idServicio);

            if (servicio != null)
            {
                return Json(new { success = true, precio = servicio.costo }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }


        public FileResult DescargarPDFCompra(Guid idCompra)
        {
            CompraCompletaDto compra = _detallesCompraCompleta.Detalle(idCompra);

            if (compra == null)
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
            Font totalFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14,  BaseColor.BLACK);

            // ENCABEZADO 
            PdfPTable headerTable = new PdfPTable(2) { WidthPercentage = 100 };
            headerTable.SetWidths(new float[] { 1, 2 });

            PdfPCell empresaCell = new PdfPCell(new Phrase("LavaCar HERVI \nTel: +(506) 7285 0302 \nCorreo: lavacarhervi@gmail.com", cellFont))
            {
                Border = PdfPCell.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT
            };
            headerTable.AddCell(new PdfPCell(new Phrase("INFORME DE SERVICIOS", titleFont)) { Border = PdfPCell.NO_BORDER });
            headerTable.AddCell(empresaCell);
            doc.Add(headerTable);

            // TÍTULO
            Paragraph title = new Paragraph($"Informe #{idCompra}\n\n", titleFont)
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
            PdfPTable servicioTable = new PdfPTable(3) { WidthPercentage = 100 };
            servicioTable.SetWidths(new float[] { 3, 5, 2 });

            AgregarEncabezado(servicioTable, "Servicio", cellFont, headerColor);
            AgregarEncabezado(servicioTable, "Descripción", cellFont, headerColor);
            AgregarEncabezado(servicioTable, "Costo", cellFont, headerColor);

            
            servicioTable.AddCell(new PdfPCell(new Phrase(compra.nombre, cellFont)) { Padding = 8, BorderWidth = 1 });
            servicioTable.AddCell(new PdfPCell(new Phrase(compra.DescripcionServicio, cellFont)) { Padding = 8, BorderWidth = 1 });
            servicioTable.AddCell(new PdfPCell(new Phrase($"₡{compra.costo:N2}", cellFont)) { Padding = 8, BorderWidth = 1 });

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
            return File(ms, "application/pdf", $"Factura_Servicio_{idCompra}.pdf");
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

































//// GET: Compra/Edit/5
//public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: Compra/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Compra/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Compra/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
