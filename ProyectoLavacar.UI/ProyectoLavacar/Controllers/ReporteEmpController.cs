using ProyectoLavacar.AccesoADatos;
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
        // GET: ReporteEmp

        public ReporteEmpController()
        {
            _context = new Contexto();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ObtenerServiciosPorMes()
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idCliente = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var datos = _context.ReservasTabla
                .Where(r => r.idCliente == idCliente) 
                .GroupBy(r => new { Año = r.fecha.Year, Mes = r.fecha.Month })
                .Select(g => new
                {
                    Año = g.Key.Año,
                    Mes = g.Key.Mes,
                    TotalServicios = g.Count()
                })
                .OrderBy(g => g.Año)
                .ThenBy(g => g.Mes)
                .ToList()
                .Select(g => new Dictionary<string, object>
                {
            { "Mes", g.Mes.ToString("D2") + "/" + g.Año }, // Format MM/YYYY
            { "TotalServicios", g.TotalServicios }
                })
                .ToList();

            ViewBag.ServiciosPorMes = datos;

            return PartialView("_ServiciosPorMesEmp");
        }

        public ActionResult ObtenerMargenVentas()
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idCliente = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var margenVentas = _context.CompraTabla
                .Join(_context.ServiciosTabla,
                    compra => compra.idServicio,
                    servicio => servicio.idServicio,
                    (compra, servicio) => new
                    {
                        TotalVenta = compra.Total,
                        Precio = servicio.precio,
                        Costo = servicio.costo,
                        idCliente = compra.idCliente // Include idCliente in the join
                    })
                .Where(x => x.idCliente == idCliente) // Filter by idCliente
                .Sum(x => x.Precio - x.Costo); // Calculate the margin

            decimal totalVentas = _context.CompraTabla
                .Where(c => c.Estado && c.idCliente == idCliente) // Filter by idCliente
                .Sum(c => c.Total);

            decimal margenPorcentualVentas = totalVentas == 0 ? 0 : (margenVentas / totalVentas) * 100;

            ViewBag.MargenVentas = margenVentas;
            ViewBag.MargenPorcentualVentas = margenPorcentualVentas;
            ViewBag.TotalVentas = totalVentas;

            return PartialView("_MargenVentasEmp");
   
        }
        public ActionResult ObtenerGraficoVentasPorMes()
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            string idCliente = claimsIdentity?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var compras = _context.CompraTabla
                .Join(_context.ServiciosTabla,
                    compra => compra.idServicio,
                    servicio => servicio.idServicio,
                    (compra, servicio) => new
                    {
                        Fecha = compra.fecha,
                        TotalVenta = compra.Total,
                        MargenVenta = servicio.precio - servicio.costo,
                        idCliente = compra.idCliente // Include idCliente in the join
                    })
                .Where(c => c.idCliente == idCliente) // Filter by idCliente
                .ToList();

            List<string> fechas = new List<string>();
            List<decimal> totalVentas = new List<decimal>();
            List<decimal> margenVentas = new List<decimal>();

            foreach (var compra in compras)
            {
                string mesAnyo = compra.Fecha.ToString("yyyy-MM");

                int index = fechas.IndexOf(mesAnyo);
                if (index != -1)
                {
                    totalVentas[index] += compra.TotalVenta;
                    margenVentas[index] += compra.MargenVenta;
                }
                else
                {
                    fechas.Add(mesAnyo);
                    totalVentas.Add(compra.TotalVenta);
                    margenVentas.Add(compra.MargenVenta);
                }
            }

            ViewBag.Fechas = fechas;
            ViewBag.TotalVentas = totalVentas;
            ViewBag.MargenVentas = margenVentas;

            return PartialView("_GraficoVentas");
        }

    }
}
