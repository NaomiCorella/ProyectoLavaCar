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
                return PartialView("_ResumenVentasEmpleado");
            }

            // Obtener compras del empleado
            var comprasEmpleado = _context.CompraTabla
                .Where(c => c.idEmpleado == idEmpleado)
                .Select(c => new
                {
                    c.idCompra,
                    c.fecha,
                    c.Total
                })
                .ToList();

            // Obtener los costos de cada compra (sumando costos de sus servicios)
            var costosPorCompra = _context.CompraServiciosTabla
                .Join(_context.ServiciosTabla,
                      cs => cs.idServicio,
                      s => s.idServicio,
                      (cs, s) => new { cs.idCompra, Costo = s.costo })
                .GroupBy(x => x.idCompra)
                .Select(g => new
                {
                    idCompra = g.Key,
                    CostoTotal = g.Sum(x => x.Costo)
                })
                .ToList();

            // Unir compras con sus costos
            var datosVentas = comprasEmpleado
                .GroupJoin(costosPorCompra,
                           compra => compra.idCompra,
                           costo => costo.idCompra,
                           (compra, costoGroup) => new
                           {
                               FechaCompra = compra.fecha,
                               TotalVenta = compra.Total,
                               Costo = costoGroup.FirstOrDefault()?.CostoTotal ?? 0m
                           })
                .ToList();

            // Agrupar por mes y año
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

            // Calcular totales
            decimal totalVentas = ventasPorMes.Sum(x => x.TotalVenta);
            decimal margenVentas = ventasPorMes.Sum(x => x.Margen);
            decimal margenPorcentual = totalVentas > 0 ? (margenVentas / totalVentas) * 100 : 0;

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

            if (string.IsNullOrEmpty(idEmpleado))
            {
                return PartialView("_GraficoVentasEmpleado");
            }

            // Obtener compras del empleado
            var comprasEmpleado = _context.CompraTabla
                .Where(c => c.idEmpleado == idEmpleado)
                .Select(c => new
                {
                    c.idCompra,
                    c.Total,
                    c.fecha
                })
                .ToList();

            // Obtener los costos por compra (sumando los servicios asociados)
            var costosPorCompra = _context.CompraServiciosTabla
                .Join(_context.ServiciosTabla,
                      cs => cs.idServicio,
                      s => s.idServicio,
                      (cs, s) => new { cs.idCompra, Costo = s.costo })
                .GroupBy(x => x.idCompra)
                .Select(g => new
                {
                    idCompra = g.Key,
                    CostoTotal = g.Sum(x => x.Costo)
                })
                .ToList();

            // Unir las compras con sus costos
            var datosVentas = comprasEmpleado
                .GroupJoin(costosPorCompra,
                           compra => compra.idCompra,
                           costo => costo.idCompra,
                           (compra, costoGroup) => new
                           {
                               Mes = compra.fecha.Month,
                               Año = compra.fecha.Year,
                               TotalVenta = compra.Total,
                               Costo = costoGroup.FirstOrDefault()?.CostoTotal ?? 0m
                           })
                .ToList();

            // Agrupar por mes y año
            var ventasPorMes = datosVentas
                .GroupBy(x => new { x.Año, x.Mes })
                .Select(g => new
                {
                    Año = g.Key.Año,
                    Mes = g.Key.Mes,
                    TotalVentas = g.Sum(x => x.TotalVenta),
                    MargenVentas = g.Sum(x => x.TotalVenta - x.Costo)
                })
                .OrderBy(x => x.Año).ThenBy(x => x.Mes)
                .ToList();

            // Preparar los datos para el gráfico
            var fechas = ventasPorMes.Select(x => $"{x.Mes}/{x.Año}").ToList();
            var totalVentas = ventasPorMes.Select(x => x.TotalVentas).ToList();
            var margenVentas = ventasPorMes.Select(x => x.MargenVentas).ToList();

            // Pasar al ViewBag
            ViewBag.Fechas = fechas;
            ViewBag.TotalVentas = totalVentas;
            ViewBag.MargenVentas = margenVentas;

            return PartialView("_GraficoVentasEmpleado");
        }

        public ActionResult ObtenerDatosPorMesEmpleado(int? mes)
        {
            // Obtener el ID del empleado autenticado
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idEmpleado = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(idEmpleado))
            {
                return Json(new { error = "Empleado no autenticado" }, JsonRequestBehavior.AllowGet);
            }

            // Paso 1: Obtener compras del empleado
            var compras = _context.CompraTabla
                .Where(c => c.idEmpleado == idEmpleado)
                .Select(c => new
                {
                    c.idCompra,
                    c.Total,
                    c.fecha
                })
                .ToList();

            // Paso 2: Obtener costo total por compra (sumar los costos de los servicios)
            var costosPorCompra = _context.CompraServiciosTabla
                .Join(_context.ServiciosTabla,
                      cs => cs.idServicio,
                      s => s.idServicio,
                      (cs, s) => new { cs.idCompra, Costo = s.costo })
                .GroupBy(x => x.idCompra)
                .Select(g => new
                {
                    idCompra = g.Key,
                    CostoTotal = g.Sum(x => x.Costo)
                })
                .ToList();

            // Paso 3: Unir compras con sus costos
            var datosVentas = compras
                .GroupJoin(costosPorCompra,
                           compra => compra.idCompra,
                           costo => costo.idCompra,
                           (compra, costoGroup) => new
                           {
                               Fecha = compra.fecha,
                               TotalVenta = compra.Total,
                               CostoTotal = costoGroup.FirstOrDefault()?.CostoTotal ?? 0m
                           });

            // Paso 4: Filtrar por mes si se especifica
            if (mes.HasValue)
            {
                datosVentas = datosVentas.Where(c => c.Fecha.Month == mes.Value);
            }

            // Paso 5: Agrupar por año y mes
            var resultado = datosVentas
                .GroupBy(c => new { c.Fecha.Year, c.Fecha.Month })
                .Select(g => new
                {
                    Año = g.Key.Year,
                    Mes = g.Key.Month,
                    TotalVentas = g.Sum(x => x.TotalVenta),
                    MargenVentas = g.Sum(x => x.TotalVenta - x.CostoTotal)
                })
                .OrderBy(x => x.Año).ThenBy(x => x.Mes)
                .ToList();

            // Paso 6: Preparar los datos para la vista
            var fechas = resultado.Select(x => $"{x.Mes:D2}/{x.Año}").ToList();
            var totalVentas = resultado.Select(x => x.TotalVentas).ToList();
            var margenVentas = resultado.Select(x => x.MargenVentas).ToList();

            var datos = new
            {
                fechas = fechas,
                totalVentas = totalVentas,
                margenVentas = margenVentas
            };

            return Json(datos, JsonRequestBehavior.AllowGet);
        }




    }
}