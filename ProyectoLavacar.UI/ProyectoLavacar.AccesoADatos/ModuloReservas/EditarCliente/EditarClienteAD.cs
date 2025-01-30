using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.EditarCliente;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloReservas.EditarCliente
{
    public class EditarClienteAD : IEditarClienteAD
    {
        Contexto _elcontexto;

        public EditarClienteAD()
        {
            _elcontexto = new Contexto();
        }

        public async Task<int> EditarReservasCliente(ReservasTabla lareservaParaEditar)
        {
            ReservasTabla lareservaenBaseDeDatos = _elcontexto.ReservasTabla.Where(laReserva => laReserva.idReserva == lareservaParaEditar.idReserva).FirstOrDefault();
           
            lareservaenBaseDeDatos.idServicio = lareservaParaEditar.idServicio;
            lareservaenBaseDeDatos.fecha = lareservaParaEditar.fecha;
            lareservaenBaseDeDatos.hora = lareservaParaEditar.hora;
            EntityState estado = _elcontexto.Entry(lareservaenBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elcontexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}
