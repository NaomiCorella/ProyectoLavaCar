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
        //------------------------

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
            // Obtener todas las compras (con fecha y total)
            var compras = _context.CompraTabla
                .Select(c => new
                {
                    c.idCompra,
                    c.Total,
                    c.fecha
                })
                .ToList();

            // Obtener el costo total por cada compra (sumando costos de servicios)
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

            // Unir los totales y costos por compra
            var datosVentas = compras
                .GroupJoin(costosPorCompra,
                           compra => compra.idCompra,
                           costo => costo.idCompra,
                           (compra, costoGroup) => new
                           {
                               Fecha = compra.fecha,
                               TotalVenta = compra.Total,
                               CostoTotal = costoGroup.FirstOrDefault()?.CostoTotal ?? 0m
                           })
                .ToList();

            // Agrupar por mes y año (yyyy-MM)
            var ventasPorMes = datosVentas
                .GroupBy(x => x.Fecha.ToString("yyyy-MM"))
                .Select(g => new
                {
                    Fecha = g.Key,
                    TotalVentas = g.Sum(x => x.TotalVenta),
                    MargenVentas = g.Sum(x => x.TotalVenta - x.CostoTotal)
                })
                .OrderBy(x => x.Fecha)
                .ToList();

            // Preparar listas para el gráfico
            var fechas = ventasPorMes.Select(x => x.Fecha).ToList();
            var totalVentas = ventasPorMes.Select(x => x.TotalVentas).ToList();
            var margenVentas = ventasPorMes.Select(x => x.MargenVentas).ToList();

            // Enviar a la vista
            ViewBag.Fechas = fechas;
            ViewBag.TotalVentas = totalVentas;
            ViewBag.MargenVentas = margenVentas;

            return PartialView("_GraficoVentas");
        }



        #endregion


        #region filtro por ventas mes
        public ActionResult ObtenerDatosPorMes(int? mes)
        {
            // Paso 1: Obtener compras (id, total, fecha)
            var compras = _context.CompraTabla
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


        #endregion



    }
}