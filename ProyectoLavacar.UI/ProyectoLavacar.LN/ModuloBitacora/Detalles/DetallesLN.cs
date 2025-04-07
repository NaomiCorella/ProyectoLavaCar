using Newtonsoft.Json;
using ProyectoLavacar.Abstracciones.Modelos.ModuloBitacora;
using ProyectoLavacar.Abstracciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloBitacora.Detalles;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloBitacora.Detalles;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloBitacora.Detalles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloBitacora.Detalles
{
   public  class DetallesLN :IDetallesLN
    {
        IDetallesAD _obtener;
        public DetallesLN()
        {
            _obtener = new DetallesAD();
        }
        public BitacoraDto Detalle(int idEvento)
        {
            BitacoraTabla CompraEnBaseDeDatos = _obtener.Detalle(idEvento);
            BitacoraDto laCompraAMostrar = ConvertirACompraAMostrar(CompraEnBaseDeDatos);
            return laCompraAMostrar;
        }
        private BitacoraDto ConvertirACompraAMostrar(BitacoraTabla laCompra)
        {
            // Verificar si los datos no son nulos o vacíos antes de deserializarlos
            var datosAnteriores = string.IsNullOrEmpty(laCompra.DatosAnteriores)
                ? null
                : JsonConvert.DeserializeObject<Dictionary<string, object>>(laCompra.DatosAnteriores);

            var datosPosteriores = string.IsNullOrEmpty(laCompra.DatosPosteriores)
                ? null
                : JsonConvert.DeserializeObject<Dictionary<string, object>>(laCompra.DatosPosteriores);

            // Crear una cadena de texto para mostrar de manera legible
            string datosAnterioresFormateados = FormatearDatos(datosAnteriores);
            string datosPosterioresFormateados = FormatearDatos(datosPosteriores);

            return new BitacoraDto
            {
                IdEvento = laCompra.IdEvento,
                DatosAnteriores = datosAnterioresFormateados,  // Mostrar los datos formateados
                DatosPosteriores = datosPosterioresFormateados,  // Mostrar los datos formateados
                DescripcionDeEvento = laCompra.DescripcionDeEvento,
                FechaDeEvento = laCompra.FechaDeEvento.ToString("dd-MM-yyyy hh:mm tt"),
                StackTrace = laCompra.StackTrace,
                TablaDeEvento = laCompra.TablaDeEvento,
                TipoDeEvento = laCompra.TipoDeEvento
            };
        }

        private string FormatearDatos(Dictionary<string, object> datos)
        {
            if (datos == null || datos.Count == 0)
                return "No hay datos.";

            var resultado = new StringBuilder();

            foreach (var item in datos)
            {
                resultado.AppendLine($"{item.Key}: {item.Value}");
            }

            return resultado.ToString();
        }

    }
}
