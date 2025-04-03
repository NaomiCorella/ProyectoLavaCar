using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoLavacar.Controllers
{
    public class ReporteController : Controller
    {
        
        Contexto _context;
        public ReporteController()
        {
            _context = new Contexto();
        }



        // GET: Reporte
        public ActionResult Index()
        {

            return View();
        }


        #region Servicios por mes
        public ActionResult ObtenerServiciosPorMes()
        {
            var datos = _context.ReservasTabla
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
            { "Mes", g.Mes.ToString("D2") + "/" + g.Año }, // Formato MM/YYYY
            { "TotalServicios", g.TotalServicios }
                })
                .ToList();

            ViewBag.ServiciosPorMes = datos; // Pasamos los datos a la vista usando ViewBag

            return PartialView("_ServiciosPorMes");
        }
        #endregion


        #region Margenes Ventas
        public ActionResult ObtenerMargenVentas()
        {
            var margenVentasLista = _context.CompraServiciosTabla
    .Join(_context.CompraTabla,
        compraServicio => compraServicio.idCompra,
        compra => compra.idCompra,
        (compraServicio, compra) => new { compraServicio, compra })
    .Join(_context.ServiciosTabla,
        compraServicio => compraServicio.compraServicio.idServicio,
        servicio => servicio.idServicio,
        (compraServicio, servicio) => new
        {
            Precio = (servicio.precio == null ? 0m : servicio.precio),
            Costo = (servicio.costo == null ? 0m : servicio.costo)
        })
    .ToList(); // Materializa los datos en memoria

            decimal margenVentas = margenVentasLista.Sum(x => x.Precio - x.Costo);



            decimal totalVentas = _context.CompraTabla
     .Where(c => c.Estado)  // Consideramos solo compras activas
     .Select(c => new { Total = (decimal?)c.Total })  // Convierte Total a nullable
     .ToList()  // Materializa los datos en memoria
     .Sum(c => c.Total ?? 0m);  // Si es NULL, usa 0m

            ;


            // Calcular el Margen Porcentual de Ventas (si el total de ventas es 0, asignamos 0)
            decimal margenPorcentualVentas = totalVentas == 0 ? 0 : (margenVentas / totalVentas) * 100;

            // Pasar los datos al ViewBag para ser usados en la vista
            ViewBag.MargenVentas = margenVentas;
            ViewBag.MargenPorcentualVentas = margenPorcentualVentas;
            ViewBag.TotalVentas = totalVentas; // Agregar el Total de Ventas

            return PartialView("_MargenVentas"); // Renderizar una vista parcial
        }
        #endregion

        #region Usuarios por mes
        public ActionResult ObtenerUsuariosPorMes()
        {
            var usuariosPorMes = _context.UsuariosTabla
                .Where(u => u.ingreso != null) // Filtrar solo los registros con fecha de ingreso no nula
                .GroupBy(u => new { Año = u.ingreso.Value.Year, Mes = u.ingreso.Value.Month }) // .Value porque 'ingreso' es un nullable DateTime
                .Select(g => new
                {
                    Año = g.Key.Año,
                    Mes = g.Key.Mes,
                    TotalUsuarios = g.Count()
                })
                .OrderBy(g => g.Año)
                .ThenBy(g => g.Mes)
                .ToList()
                .Select(g => new Dictionary<string, object>
                {
            { "Mes", g.Mes.ToString("D2") + "/" + g.Año }, // Formato MM/YYYY
            { "TotalUsuarios", g.TotalUsuarios }
                })
                .ToList();

            ViewBag.UsuariosPorMes = usuariosPorMes; // Pasamos los datos a la vista usando ViewBag

            return PartialView("_UsuariosPorMes"); // Renderizamos una vista parcial si es necesario
        }
        #endregion

        #region
        public ActionResult ObtenerGraficoVentasPorMes()
        {
            // Obtener todas las compras relacionadas con servicios
            var compras = _context.CompraServiciosTabla
                .Join(_context.CompraTabla,
                    compraServicio => compraServicio.idCompra,
                    compra => compra.idCompra,
                    (compraServicio, compra) => new { compraServicio, compra })
                .Join(_context.ServiciosTabla,
                    compraServicio => compraServicio.compraServicio.idServicio,
                    servicio => servicio.idServicio,
                    (compraServicio, servicio) => new
                    {
                        Fecha = compraServicio.compra.fecha,
                        TotalVenta = compraServicio.compra.Total,
                        MargenVenta = servicio.precio - servicio.costo // Calculamos el margen de cada venta
                    })
                .ToList();

            // Crear listas para almacenar las fechas, totales de ventas y márgenes de ventas por mes
            List<string> fechas = new List<string>();
            List<decimal> totalVentas = new List<decimal>();
            List<decimal> margenVentas = new List<decimal>();

            // Recorrer todas las compras para agruparlas por mes/año
            foreach (var compra in compras)
            {
                string mesAnyo = compra.Fecha.ToString("yyyy-MM"); // Obtener el mes/año (Formato: YYYY-MM)

                // Verificar si ya existe el mes/año en la lista de fechas
                int index = fechas.IndexOf(mesAnyo);
                if (index != -1)
                {
                    // Si existe, actualizar los totales de ventas y márgenes para ese mes
                    totalVentas[index] += compra.TotalVenta;
                    margenVentas[index] += compra.MargenVenta;
                }
                else
                {
                    // Si no existe, agregar una nueva entrada para ese mes/año
                    fechas.Add(mesAnyo);
                    totalVentas.Add(compra.TotalVenta);
                    margenVentas.Add(compra.MargenVenta);
                }
            }

            // Pasar las listas de fechas, ventas y márgenes a la vista utilizando ViewBag
            ViewBag.Fechas = fechas;
            ViewBag.TotalVentas = totalVentas;
            ViewBag.MargenVentas = margenVentas;

            // Devolver la vista parcial
            return PartialView("_GraficoVentas");
        }


        #endregion


        #region filtro por ventas mes
        public ActionResult ObtenerDatosPorMes(int? mes)
        {
            // Consulta base para obtener las compras y servicios
            var compras = _context.CompraServiciosTabla
                .Join(_context.CompraTabla,
                    compraServicio => compraServicio.idCompra,
                    compra => compra.idCompra,
                    (compraServicio, compra) => new { compraServicio, compra })
                .Join(_context.ServiciosTabla,
                    compraServicio => compraServicio.compraServicio.idServicio,
                    servicio => servicio.idServicio,
                    (compraServicio, servicio) => new
                    {
                        Fecha = compraServicio.compra.fecha,
                        TotalVenta = compraServicio.compra.Total,
                        MargenVenta = servicio.precio - servicio.costo
                    });

            // Filtrar por mes si el mes es proporcionado
            if (mes.HasValue)
            {
                compras = compras.Where(c => c.Fecha.Month == mes.Value);
            }

            // Agrupar por Año y Mes
            var resultado = compras
                .GroupBy(c => new { Año = c.Fecha.Year, Mes = c.Fecha.Month })
                .Select(g => new
                {
                    Año = g.Key.Año,
                    Mes = g.Key.Mes,
                    TotalVentas = g.Sum(x => x.TotalVenta),
                    MargenVentas = g.Sum(x => x.MargenVenta)
                })
                .ToList();

            // Preparar los datos para la vista
            var fechas = resultado.Select(x => $"{x.Mes:D2}/{x.Año}").ToList();
            var totalVentas = resultado.Select(x => x.TotalVentas).ToList();
            var margenVentas = resultado.Select(x => x.MargenVentas).ToList();

            var datos = new
            {
                fechas = fechas,
                totalVentas = totalVentas,
                margenVentas = margenVentas
            };

            // Retornar los datos en formato JSON
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        #endregion



    }
}
