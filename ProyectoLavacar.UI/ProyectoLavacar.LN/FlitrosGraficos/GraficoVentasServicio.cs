using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.FlitrosGraficos
{
    public class GraficoVentasServicio
    {
        public List<string> Fechas { get; set; }
        public List<decimal> TotalVentas { get; set; }
        public List<decimal> MargenVentas { get; set; }

        public GraficoVentasServicio()
        {
            Fechas = new List<string>();
            TotalVentas = new List<decimal>();
            MargenVentas = new List<decimal>();
        }

        public void FiltrarPorMes(List<CompraTabla> compras, List<ServiciosTabla> servicios, int? mes)
        {
            // Filtrar las compras por mes si se selecciona uno específico
            var comprasFiltradas = compras;

            if (mes.HasValue && mes.Value > 0)
            {
                comprasFiltradas = compras.Where(c => c.fecha.Month == mes.Value).ToList();
            }

            // Recorrer todas las compras filtradas para agruparlas por mes/año
            foreach (var compra in comprasFiltradas)
            {
                string mesAnyo = compra.fecha.ToString("yyyy-MM"); // Obtener el mes/año (Formato: YYYY-MM)

                // Buscar el servicio para calcular el margen
                var servicio = servicios.FirstOrDefault(s => s.idServicio == compra.idServicio);

                if (servicio != null)
                {
                    decimal margenVenta = servicio.precio - servicio.costo;

                    // Verificar si ya existe el mes/año en la lista de fechas
                    int index = Fechas.IndexOf(mesAnyo);
                    if (index != -1)
                    {
                        // Si existe, actualizar los totales de ventas y márgenes para ese mes
                        TotalVentas[index] += compra.Total;
                        MargenVentas[index] += margenVenta;
                    }
                    else
                    {
                        // Si no existe, agregar una nueva entrada para ese mes/año
                        Fechas.Add(mesAnyo);
                        TotalVentas.Add(compra.Total);
                        MargenVentas.Add(margenVenta);
                    }
                }
            }
        }
    }
}