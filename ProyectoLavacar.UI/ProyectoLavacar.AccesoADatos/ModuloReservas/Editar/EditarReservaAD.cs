using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.Editar;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloReservas.Editar
{
    public class EditarReservaAD : IEditarReservaAD
    {
        Contexto _elcontexto;

        public EditarReservaAD()
        {
            _elcontexto = new Contexto();
        }

        public async Task<int> EditarReservas(ReservasTabla lareservaParaEditar)
        {
            ReservasTabla lareservaenBaseDeDatos = _elcontexto.ReservasTabla.Where(laReserva => laReserva.idReserva == lareservaParaEditar.idReserva).FirstOrDefault();
            lareservaenBaseDeDatos.idEmpleado = lareservaParaEditar.idEmpleado;
            lareservaenBaseDeDatos.idServicio = lareservaParaEditar.idServicio;

            EntityState estado = _elcontexto.Entry(lareservaenBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elcontexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}




