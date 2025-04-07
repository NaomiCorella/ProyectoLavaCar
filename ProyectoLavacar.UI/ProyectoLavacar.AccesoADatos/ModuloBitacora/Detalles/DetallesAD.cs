using ProyectoLavacar.Abstracciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloBitacora.Detalles;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloBitacora.Detalles
{
   public  class DetallesAD :IDetallesAD
    {
        Contexto _elContexto;

        public DetallesAD()
        {
            _elContexto = new Contexto();
        }
        public BitacoraTabla Detalle(int idEvento)
        {
            BitacoraTabla laPalabraEnBaseDeDatos = _elContexto.BitacoraTabla.Where(evento => evento.IdEvento == idEvento).FirstOrDefault();
            return laPalabraEnBaseDeDatos;
        }
    }
}
