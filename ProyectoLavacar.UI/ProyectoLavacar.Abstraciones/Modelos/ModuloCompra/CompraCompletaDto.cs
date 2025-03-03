using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.Modelos.ModuloCompra
{
    public class CompraCompletaDto
    {
        public int idCompra { get; set; }
        public string idCliente { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Cedula { get; set; }
        public int idServicio { get; set; }
        public string nombre { get; set; }
        public decimal costo { get; set; }
        public decimal Total { get; set; }
        public string Fecha { get; set; }
        public string DescripcionServicio { get; set; }
        public bool Estado { get; set; }
    }

}