
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.RegistrarMovimiento;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.BuscarPorIdInventario;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.Listar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.ListarMovimiento;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.RegistrarMovimiento;
using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.AccesoADatos;
using ProyectoLavacar.LN.ModuloInventario.BuscarPorId;
using ProyectoLavacar.LN.ModuloInventario.Crear;
using ProyectoLavacar.LN.ModuloInventario.Editar;
using ProyectoLavacar.LN.ModuloInventario.Listar;
using ProyectoLavacar.LN.ModuloInventario.ListarMovimiento;
using ProyectoLavacar.LN.ModuloInventario.RegistrarMovimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing.Printing;
using System.Xml.Linq;
using System.Web.Services.Description;

namespace ProyectoLavacar.Controllers
{
    public class InventarioController : Controller
    {
        IListarMovimientoLN _listarMovimientos;
        IRegistrarMovimientoLN _registrarMovimiento;
        IListarInventarioLN _listarInventario;
        IEditarInventarioLN _editarInventario;
        IBuscarPorIdInventarioLN _BuscarPorIdInventario;
        ICrearInventarioLN _crearInventario;
        Contexto _context;

        public InventarioController()
        {
            _listarMovimientos = new ListarMovimientoLN();
            _registrarMovimiento = new RegistrarMovimientoLN();
            _listarInventario = new ListarInventarioLN();
            _crearInventario = new CrearInventarioLN();
            _editarInventario = new EditarInventarioLN();
            _BuscarPorIdInventario = new BuscarPorIdInventarioLN();
            _context = new Contexto();
        }


        public ActionResult FiltrarPorProducto(string nombreProducto)
        {
            ViewBag.Title = "Inventario Filtrado";


            string filtroNormalizado = nombreProducto.ToLower().TrimEnd('s');

            List<InventarioDto> productosFiltrados = _listarInventario.ListarInventario()
                .Where(p => p.estado == true &&
                    p.nombre.ToLower().TrimEnd('s').Contains(filtroNormalizado))
                .ToList();

            return View("Index", productosFiltrados);
        }


        // GET: Inventario
        [Authorize(Roles = "Administrador, Empleado")]
        public ActionResult Index()
        {
            ViewBag.Title = "Inventario";
            List<InventarioDto> laListaDeInventario = _listarInventario.ListarInventario().Where(p => p.estado == true).ToList();
            return View(laListaDeInventario);
        }
        public ActionResult lista(int id)
        {

            InventarioDto elInventario = _BuscarPorIdInventario.Detalle(id);
            return PartialView("_lista", elInventario);
        }
        // GET: Inventario/Details/5
        [Authorize(Roles = "Administrador, Empleado")]
        public ActionResult Details(int id)
        {
            InventarioDto elInventario = _BuscarPorIdInventario.Detalle(id);
            return View(elInventario);
        }

        [Authorize(Roles = "Administrador, Empleado")]
        // GET: Inventario/Create
        public ActionResult Create()
        {
            ViewBag.Categorias = new List<SelectListItem>
                     {
                         new SelectListItem { Value = "Limpieza", Text = "Productos de limpieza" },
                         new SelectListItem { Value = "Protección", Text = "Productos de protección" },
                         new SelectListItem { Value = "Accesorios", Text = "Accesorios" },
                         new SelectListItem { Value = "Herramientas y equipos", Text = "Herramientas y equipos" },
                         };
            return View();
        }

        // POST: Inventario/Create
        [HttpPost]
        public async Task<ActionResult> Create(InventarioDto modeloDeInvetario)
        {
            try
            {

                var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
                string idCliente = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                List<InventarioDto> inventarioDtos = _listarInventario.ListarInventario()
                    .Where(a => a.estado == true)
                .ToList();

                foreach (var item in inventarioDtos)
                {
                    if (item.nombre == modeloDeInvetario.nombre)
                    {
                        ModelState.AddModelError("nombre", "El producto ya esta registrado en el inventario.");
                        return View(modeloDeInvetario);
                    }
                }
                InventarioDto inventario = new InventarioDto()
                {
                    idProducto = modeloDeInvetario.idProducto,
                    nombre = modeloDeInvetario.nombre,
                    categoria = modeloDeInvetario.categoria,
                    cantidadDisponible = modeloDeInvetario.cantidadDisponible,
                    precioUnitario = modeloDeInvetario.precioUnitario,
                    estado = true

                };

                int cantidadDeDatosGuardados = await _crearInventario.CrearInventario(inventario);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [Authorize(Roles = "Administrador, Empleado")]
        public ActionResult RegistrarMovimiento()
        {
            var productos = _listarInventario.ListarInventario()
                .Where(a => a.estado == true)
                .ToList();


            ViewBag.Productos = productos;

            ViewBag.Nombres = new List<SelectListItem>
                     {
                         new SelectListItem { Value = "Entrada", Text = "Entrada" },
                         new SelectListItem { Value = "Salida", Text = "Salida" },

                         };
            return PartialView("_registrarMovimiento");
        }
        [HttpPost]
        public async Task<ActionResult> RegistrarMovimiento(MovimientoDto modeMovimiento)
        {

            int cantidadDeDatosGuardados = await _registrarMovimiento.Registrar(modeMovimiento);
            InventarioDto modelo = _BuscarPorIdInventario.Detalle(modeMovimiento.idProducto);
           
            int cantidadDeDatosEditados = await _editarInventario.EditarInventario(modelo);

            return RedirectToAction("Index");


        }
        [Authorize(Roles = "Administrador, Empleado")]
        public ActionResult HistorialDeMovimientos()
        {
            ViewBag.Title = "Historial de Movimientos";
            var productos = _listarInventario.ListarInventario();
            ViewBag.Productos = productos;
            List<MovimientoDto> lalistademovimientos = _listarMovimientos.ListarInventario();

            return View(lalistademovimientos);
        }

        // GET: Inventario/Edit/5
        [Authorize(Roles = "Administrador, Empleado")]
        public ActionResult Edit(int id)
        {
            ViewBag.Categorias = new List<SelectListItem>
                     {
                         new SelectListItem { Value = "Limpieza", Text = "Productos de limpieza" },
                         new SelectListItem { Value = "Protección", Text = "Productos de protección" },
                            new SelectListItem { Value = "Accesorios", Text = "Accesorios" },
                                new SelectListItem { Value = "Herramientas y equipos", Text = "Herramientas y equipos" },
                         };
            InventarioDto elInventario = _BuscarPorIdInventario.Detalle(id);

            return View(elInventario);
        }

        // POST: Inventario/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(InventarioDto modeloInventario)
        {
            try
            {
                InventarioDto elInventario = new InventarioDto()
                {
                    nombre = modeloInventario.nombre,
                    categoria = modeloInventario.categoria,
                    cantidadDisponible = modeloInventario.cantidadDisponible,
                    precioUnitario = modeloInventario.precioUnitario,
                    estado = modeloInventario.estado,
                    idProducto = modeloInventario.idProducto,
                };
                int cantidadDeDatosEditados = await _editarInventario.EditarInventario(elInventario);

                return RedirectToAction("Index");


            }
            catch
            {
                return View("Index");
            }
        }


        // POST: Inventario/Edit/5
        [HttpPost]



        // GET: Inventario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventario/Delete/5
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
                var Inventario = _context.InventarioTabla.Find(id);
                Inventario.estado = !Inventario.estado;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult DescargarPDF()
        {
            List<InventarioDto> inventario = _listarInventario.ListarInventario();

            MemoryStream ms = new MemoryStream();
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, ms).CloseStream = false;

            doc.Open();

            var titulo = new Paragraph("Listado de Inventario\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);


            PdfPTable tabla = new PdfPTable(3);
            tabla.WidthPercentage = 100;



            tabla.AddCell("Nombre");
            tabla.AddCell("Categoría");
            tabla.AddCell("Cantidad Disponible");


            foreach (var item in inventario)
            {
                tabla.AddCell(item.idProducto.ToString());
                tabla.AddCell(item.nombre);
                tabla.AddCell(item.categoria);
                tabla.AddCell(item.cantidadDisponible.ToString());
            }

            doc.Add(tabla);
            doc.Close();

            ms.Position = 0;
            return File(ms, "application/pdf", "Inventario.pdf");
        }



        public FileResult DescargarPDFDetalle(int id)
        {
            InventarioDto elInventario = _BuscarPorIdInventario.Detalle(id);

            if (elInventario == null)
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
            Paragraph title = new Paragraph($"Detalles del Producto - {elInventario.nombre}\n\n", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            // Crear tabla similar a la vista
            PdfPTable table = new PdfPTable(2) { WidthPercentage = 100 };
            table.SetWidths(new float[] { 1.5f, 2f }); // Ancho de las columnas

            // Encabezado de tabla (como el fondo azul en tu vista)
            PdfPCell headerCell = new PdfPCell(new Phrase("Información del Inventario", headerFont))
            {
                Colspan = 2,
                HorizontalAlignment = Element.ALIGN_CENTER,
                BackgroundColor = headerColor,
                Padding = 10
            };
            table.AddCell(headerCell);

            // Agregar filas con datos

            AgregarFila(table, "Nombre:", elInventario.nombre, cellFont, BaseColor.WHITE);
            AgregarFila(table, "Categoría:", elInventario.categoria, cellFont, backgroundColor);
            AgregarFila(table, "Precio Unitario:", $"₡{elInventario.precioUnitario:N2}", cellFont, BaseColor.WHITE);

            AgregarFila(table, "Cantidad Disponible:", elInventario.cantidadDisponible.ToString(), cellFont, backgroundColor);

            doc.Add(table);

            // Fecha de generación del PDF
            Paragraph fecha = new Paragraph($"\n\nFecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10));
            fecha.Alignment = Element.ALIGN_RIGHT;
            doc.Add(fecha);

            doc.Close();

            ms.Position = 0;
            return File(ms, "application/pdf", $"Producto_{elInventario.nombre}.pdf");
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



    }
}
