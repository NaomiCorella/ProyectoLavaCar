
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEvaluaciones;
using ProyectoLavacar.Abstraciones.Modelos.ModeloEvaluaciones;
using ProyectoLavacar.AccesoADatos;
using ProyectoLavacar.LN.ModuloEvaluaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoLavacar.Controllers
{
    public class ReporteEmpController : Controller
    {
        Contexto _context;
        IListarEvaluacionesLN _listar;
        // GET: ReporteEmp

        public ReporteEmpController()
        {
            _context = new Contexto();
            _listar = new ListarEvaluacionesLN();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listar()
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            List<EvaluacionesDto> lalistaDeReservas = _listar.ListarEvaluaciones(idEmpleado);

            return PartialView("_listar", lalistaDeReservas); // Pasar la lista a la vista parcial
        }
        

        public ActionResult ObtenerVentasEmpleado()
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Obtener total de ventas del empleado basado en las reservas
            var totalVentasEmpleado = _context.ReservasTabla
                .Join(_context.ServiciosTabla,
                    reserva => reserva.idServicio,  // Relacionamos las reservas con los servicios
                    servicio => servicio.idServicio,  // Relacionamos por idServicio
                    (reserva, servicio) => new
                    {
                        TotalVenta = servicio.precio, // Precio del servicio como total de la venta
                        idEmpleado = reserva.idEmpleado // Usamos el idEmpleado de la reserva
                    })
                .Where(x => x.idEmpleado == idEmpleado) // Filtramos por el idEmpleado
                .Sum(x => x.TotalVenta); // Sumamos todas las ventas del empleado

            ViewBag.TotalVentasEmpleado = totalVentasEmpleado;

            return PartialView("_TotalVentasEmpleado"); // Retornar la vista parcial que mostrará el total de ventas
        }



        public ActionResult ObtenerMargenVentasEmpleado()
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Calcular el margen de ventas y el total de ventas
            var datosVentas = _context.ReservasTabla
                .Join(_context.ServiciosTabla,
                    reserva => reserva.idServicio,
                    servicio => servicio.idServicio,
                    (reserva, servicio) => new
                    {
                        TotalVenta = servicio.precio,  // Precio del servicio vendido
                        Costo = servicio.costo,        // Costo del servicio
                        idEmpleado = reserva.idEmpleado
                    })
                .Where(x => x.idEmpleado == idEmpleado) // Filtrar por el empleado logueado
                .ToList(); // Convertir a lista para poder operar en memoria

            decimal totalVentas = datosVentas.Sum(x => x.TotalVenta);
            decimal margenVentas = datosVentas.Sum(x => x.TotalVenta - x.Costo);
            decimal margenPorcentual = totalVentas == 0 ? 0 : (margenVentas / totalVentas) * 100;

            ViewBag.MargenVentas = margenVentas;
            ViewBag.MargenPorcentual = margenPorcentual;
            ViewBag.TotalVentas = totalVentas;

            return PartialView("_MargenVentasEmpleado"); // Vista parcial
        }

        public ActionResult ObtenerResumenVentasEmpleado()
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Obtener los datos de ventas y margen de ventas
            var datosVentas = _context.ReservasTabla
                .Join(_context.ServiciosTabla,
                    reserva => reserva.idServicio,
                    servicio => servicio.idServicio,
                    (reserva, servicio) => new
                    {
                        TotalVenta = servicio.precio,  // Precio del servicio vendido
                        Costo = servicio.costo,        // Costo del servicio
                        idEmpleado = reserva.idEmpleado
                    })
                .Where(x => x.idEmpleado == idEmpleado) // Filtrar por el empleado logueado
                .ToList(); // Convertir a lista para poder operar en memoria

            decimal totalVentas = datosVentas.Sum(x => x.TotalVenta);
            decimal margenVentas = datosVentas.Sum(x => x.TotalVenta - x.Costo);
            decimal margenPorcentual = totalVentas == 0 ? 0 : (margenVentas / totalVentas) * 100;

            // Enviar datos a la vista
            ViewBag.TotalVentasEmpleado = totalVentas;
            ViewBag.MargenVentas = margenVentas;
            ViewBag.MargenPorcentual = margenPorcentual;

            return PartialView("_ResumenVentasEmpleado"); // Vista parcial
        }

        public ActionResult ObtenerPromedioCalificacionEmpleado()
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Obtener las calificaciones del empleado
            var calificaciones = _context.EvaluacionesTabla
                .Where(e => e.idEmpleado == idEmpleado)
                .Select(e => e.calificacion)
                .ToList();

            // Calcular el promedio con conversión explícita a decimal
            decimal promedioCalificacion = calificaciones.Any() ? (decimal)calificaciones.Average() : 0;

            // Enviar el resultado a la vista
            ViewBag.PromedioCalificacion = promedioCalificacion;

            return PartialView("_PromedioCalificacionEmpleado");
        }

        public ActionResult ObtenerResumenEmpleado()
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Obtener datos de ventas y margen de ventas
            var datosVentas = _context.ReservasTabla
                .Join(_context.ServiciosTabla,
                    reserva => reserva.idServicio,
                    servicio => servicio.idServicio,
                    (reserva, servicio) => new
                    {
                        TotalVenta = servicio.precio,  // Precio del servicio vendido
                        Costo = servicio.costo,        // Costo del servicio
                        idEmpleado = reserva.idEmpleado
                    })
                .Where(x => x.idEmpleado == idEmpleado) // Filtrar por el empleado logueado
                .ToList(); // Convertir a lista para poder operar en memoria

            decimal totalVentas = datosVentas.Sum(x => x.TotalVenta);
            decimal margenVentas = datosVentas.Sum(x => x.TotalVenta - x.Costo);
            decimal margenPorcentual = totalVentas == 0 ? 0 : (margenVentas / totalVentas) * 100;

            // Obtener las calificaciones del empleado
            var calificaciones = _context.EvaluacionesTabla
                .Where(e => e.idEmpleado == idEmpleado)
                .Select(e => e.calificacion)
                .ToList();

            // Calcular el promedio con conversión explícita a decimal
            decimal promedioCalificacion = calificaciones.Any() ? (decimal)calificaciones.Average() : 0;

            // Enviar los resultados a la vista
            ViewBag.TotalVentasEmpleado = totalVentas;
            ViewBag.MargenVentas = margenVentas;
            ViewBag.MargenPorcentual = margenPorcentual;
            ViewBag.PromedioCalificacion = promedioCalificacion;

            return PartialView("_ResumenEmpleado"); // Vista parcial unificada
        }





    }
}

