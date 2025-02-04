
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.BuscarPorIdInventario;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.Editar;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloInventario.Listar;
using ProyectoLavacar.Abstraciones.Modelos.ModeloInventario;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.AccesoADatos;
using ProyectoLavacar.LN.ModuloInventario.BuscarPorId;
using ProyectoLavacar.LN.ModuloInventario.Crear;
using ProyectoLavacar.LN.ModuloInventario.Editar;
using ProyectoLavacar.LN.ModuloInventario.Listar;
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

        IListarInventarioLN _listarInventario;
        IEditarInventarioLN _editarInventario;
        IBuscarPorIdInventarioLN _BuscarPorIdInventario;
        ICrearInventarioLN _crearInventario;
        Contexto _context;

        public InventarioController()
        {
            
            _listarInventario = new ListarInventarioLN();
            _crearInventario = new CrearInventarioLN();
            _editarInventario = new EditarInventarioLN();
            _BuscarPorIdInventario = new BuscarPorIdInventarioLN();
            _context = new Contexto();
        }

        // GET: Inventario
        public ActionResult Index()
        {
            ViewBag.Title = "Inventario";
            List<InventarioDto> laListaDeInventario = _listarInventario.ListarInventario();
            return View(laListaDeInventario);
        }
        public ActionResult lista()
        {
            List<InventarioDto> laListaDeInventario = _listarInventario.ListarInventario();
            return PartialView("_lista", laListaDeInventario);
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
                    estado = modeloDeInvetario.estado
                    
                };

                int cantidadDeDatosGuardados = await _crearInventario.CrearInventario(inventario);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Inventario/Edit/5
        public ActionResult Edit()
        {
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

        public ActionResult Actualizar()
        {
            InventarioDto elInventario = _BuscarPorIdInventario.Detalle(1);
      
            return View(elInventario);
        }
 
        // POST: Inventario/Edit/5
        [HttpPost]
        public async Task<ActionResult> Actualizar(InventarioDto modeloInventario)
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
