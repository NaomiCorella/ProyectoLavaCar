
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
        public ActionResult Index()
        {
            ViewBag.Title = "Inventario";
            List<InventarioDto> laListaDeInventario = _listarInventario.ListarInventario();
            return View(laListaDeInventario);
        }
        public ActionResult lista(int id)
        {

            InventarioDto elInventario = _BuscarPorIdInventario.Detalle(id);
            return PartialView("_lista", elInventario);
        }
        // GET: Inventario/Details/5
        public ActionResult Details(int id)
        {

            InventarioDto elInventario = _BuscarPorIdInventario.Detalle(id);
            return View(elInventario);
        }


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
                InventarioDto inventario = new InventarioDto()
                {
                    idProducto = modeloDeInvetario.idProducto,
                    nombre = modeloDeInvetario.nombre,
                    categoria =modeloDeInvetario.categoria,
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
        public ActionResult HistorialDeMovimientos()
        {
            ViewBag.Title = "Historial de Movimientos";
            var productos = _listarInventario.ListarInventario();
            ViewBag.Productos = productos;
            List<MovimientoDto> lalistademovimientos = _listarMovimientos.ListarInventario();

            return View(lalistademovimientos);
        }

        // GET: Inventario/Edit/5
        public ActionResult Edit()
        {
            ViewBag.Categorias = new List<SelectListItem>
                     {
                         new SelectListItem { Value = "Limpieza", Text = "Productos de limpieza" },
                         new SelectListItem { Value = "Protección", Text = "Productos de protección" },
                            new SelectListItem { Value = "Accesorios", Text = "Accesorios" },
                                new SelectListItem { Value = "Herramientas y equipos", Text = "Herramientas y equipos" },
                         };
            InventarioDto elInventario = _BuscarPorIdInventario.Detalle(1);

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
                return View();
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

       

    }
}
