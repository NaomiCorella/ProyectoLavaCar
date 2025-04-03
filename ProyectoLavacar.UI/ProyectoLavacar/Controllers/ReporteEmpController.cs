
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



        public ActionResult ObtenerResumenVentasEmpleado()
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(idEmpleado))
            {
                return PartialView("_ResumenVentasEmpleado"); // Retornar la vista vacía si no se encuentra el empleado
            }

            // Obtener los datos de ventas y margen de ventas
            var datosVentas = _context.CompraTabla
                .Join(_context.CompraServiciosTabla,
                    compra => compra.idCompra,
                    compraServicio => compraServicio.idCompra,
                    (compra, compraServicio) => new { compra, compraServicio })
                .Join(_context.ServiciosTabla,
                    compraJoin => compraJoin.compraServicio.idServicio,
                    servicio => servicio.idServicio,
                    (compraJoin, servicio) => new
                    {
                        TotalVenta = compraJoin.compra.Total,
                        Costo = servicio.costo,
                        idEmpleado = compraJoin.compra.idEmpleado,
                        FechaCompra = compraJoin.compra.fecha
                    })
                .Where(x => x.idEmpleado == idEmpleado) // Filtrar por el empleado autenticado
                .ToList(); // Convertir a lista para operar en memoria

            var ventasPorMes = datosVentas
                .GroupBy(x => new { x.FechaCompra.Year, x.FechaCompra.Month })
                .Select(g => new
                {
                    Mes = g.Key.Month.ToString(),
                    Año = g.Key.Year.ToString(),
                    TotalVenta = g.Sum(x => x.TotalVenta),
                    Margen = g.Sum(x => x.TotalVenta - x.Costo)
                })
                .ToList();

            // Calcular valores totales
            decimal totalVentas = ventasPorMes.Sum(x => x.TotalVenta);
            decimal margenVentas = ventasPorMes.Sum(x => x.Margen);
            decimal margenPorcentual = totalVentas > 0 ? (margenVentas / totalVentas) * 100 : 0;

            // Enviar datos a la vista
            ViewBag.TotalVentasEmpleado = totalVentas;
            ViewBag.MargenVentas = margenVentas;
            ViewBag.MargenPorcentual = margenPorcentual;

            return PartialView("_ResumenVentasEmpleado");
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


        public ActionResult ObtenerGraficoVentasEmpleado()
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

           

            // Obtener los datos de ventas y margen de ventas
            var datosVentas = _context.CompraTabla
                .Join(_context.CompraServiciosTabla,
                    compra => compra.idCompra,
                    compraServicio => compraServicio.idCompra,
                    (compra, compraServicio) => new { compra, compraServicio })
                .Join(_context.ServiciosTabla,
                    compraServicio => compraServicio.compraServicio.idServicio,
                    servicio => servicio.idServicio,
                    (compraServicio, servicio) => new
                    {
                        TotalVenta = compraServicio.compra.Total,  // Total de la compra
                        Costo = servicio.costo,                    // Costo del servicio
                        idEmpleado = compraServicio.compra.idEmpleado,
                        Mes = compraServicio.compra.fecha.Month,
                        Año = compraServicio.compra.fecha.Year
                    })
                .Where(x => x.idEmpleado == idEmpleado) // Filtrar por el empleado logueado
                .GroupBy(x => new { x.Año, x.Mes }) // Agrupar por mes y año
                .Select(g => new
                {
                    Año = g.Key.Año,
                    Mes = g.Key.Mes,
                    TotalVentas = g.Sum(x => x.TotalVenta),
                    MargenVentas = g.Sum(x => x.TotalVenta - x.Costo)
                })
                .ToList(); // Convertir a lista

            // Preparar los datos para el gráfico
            var fechas = datosVentas.Select(x => $"{x.Mes}/{x.Año}").ToList();
            var totalVentas = datosVentas.Select(x => x.TotalVentas).ToList();
            var margenVentas = datosVentas.Select(x => x.MargenVentas).ToList();

            // Pasar los datos al ViewBag
            ViewBag.Fechas = fechas;
            ViewBag.TotalVentas = totalVentas;
            ViewBag.MargenVentas = margenVentas;

            return PartialView("_GraficoVentasEmpleado"); // Vista parcial
        }


    }
}

