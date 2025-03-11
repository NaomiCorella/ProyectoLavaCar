using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.ObtenerPorId;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloCompra.ObtenerPorId
{
    public class ObtenerPorIdAD : IObtenerPorIdAD
    {
        Contexto _elContexto;

        public ObtenerPorIdAD()
        {
            _elContexto = new Contexto();
        }
        public CompraTabla Detalle(int idCompra)
        {
            CompraTabla laPalabraEnBaseDeDatos = _elContexto.CompraTabla.Where(laCompra => laCompra.idCompra == idCompra).FirstOrDefault();
            return laPalabraEnBaseDeDatos;
        }
    }
}


