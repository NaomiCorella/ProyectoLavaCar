

using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    public class CompraTabla
    {
        [Key]
        public int idCompra { get; set; }
        public string idCliente { get; set; }
        public int idServicio { get; set; }
        public decimal Total { get; set; }
        public DateTime fecha { get; set; }
        public string DescripcionServicio { get; set; }
        public bool Estado { get; set; }
    }
}
