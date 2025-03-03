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
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult DetallesCompra(int IdCompra)
        {
            CompraCompletaDto compra = _detallesCompraCompleta.Detalle(IdCompra);
            return View(compra);
        }


        // GET: Compra/Create
        public ActionResult Create()
        {
            var servicios = _listarServicios.ListarServicios()
              .Where(a => a.estado == true)
              .ToList();
            ViewBag.Servicios = servicios;

            return View();
        }


        // POST: Compra/Create
        [HttpPost]
        public async Task<ActionResult> Create(CompraDto modeloDeCompra, int numeroCedula)
        {
            try
            {
                // Verificar si se ingresó la cédula
                if (numeroCedula == 0)
                {
                    ModelState.AddModelError("", "Debe ingresar una cédula.");
                    return View(modeloDeCompra);
                }

                // Buscar al cliente por cédula
                var cliente = _listarClientes.ListarUsuarios()
                    .FirstOrDefault(c => c.cedula == numeroCedula);

                if (cliente == null)
                {
                    ModelState.AddModelError("", "No se encontró un cliente con esa cédula.");
                    return View(modeloDeCompra);
                }

                // Mostrar el nombre del cliente encontrado
                TempData["ClienteEncontrado"] = $"Cliente encontrado: {cliente.nombre} {cliente.primer_apellido}";

                // Crear el objeto CompraDto con los datos del cliente encontrado
                CompraDto compra = new CompraDto()
                {
                    idCompra = modeloDeCompra.idCompra,
                    idCliente = cliente.Id,
                    idServicio = modeloDeCompra.idServicio,
                    DescripcionServicio = modeloDeCompra.DescripcionServicio,
                    fecha = modeloDeCompra.fecha,
                    Total = modeloDeCompra.Total,
                    Estado = modeloDeCompra.Estado
                };

                // Intentar guardar la compra en la base de datos
                int cantidadDeDatosGuardados = await _crearCompra.CrearCompra(compra);

                if (cantidadDeDatosGuardados > 0)
                {
                    return RedirectToAction("Index");
                }

                // Si no se pudo guardar la compra, agregar un error al ModelState
                ModelState.AddModelError("", "Error al guardar la compra.");
                return View(modeloDeCompra);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción inesperada
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
                return Json(new { success = true, nombre = cliente.nombre, apellido = cliente.primer_apellido });
            }
            else
            {
                return Json(new { success = false });
            }
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
