

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos
{
    [Table("Compra")]
    public class CompraTabla
    {
        [Key]
        public Guid idCompra { get; set; }
        public string idCliente { get; set; }
     
        public decimal Total { get; set; }
        public DateTime fecha { get; set; }
        public string DescripcionServicio { get; set; }
        public bool Estado { get; set; }
    }
}
