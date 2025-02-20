using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.DetallesReservaCompleta
{
     public interface IDetallesReservaCompletaAD
    {
        ReservaCompleta Detalle(int idReserva);
    }
}
