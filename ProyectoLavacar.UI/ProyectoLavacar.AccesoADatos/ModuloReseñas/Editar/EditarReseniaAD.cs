using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReseñas.Editar;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloReseñas.Editar
{
    public class EditarReseniaAD : IEditarReseniaAD
    {
        Contexto _elcontexto;

        public EditarReseniaAD()
        {
            _elcontexto = new Contexto();
        }

        public async Task<int> EditarResenia(ReseniasTabla lareseniaParaEditar )
        {
            ReseniasTabla lareseniaenBaseDeDatos = _elcontexto.ReseniasTabla.Where(laReserva => laReserva.idResenia == lareseniaParaEditar.idResenia).FirstOrDefault();
            lareseniaenBaseDeDatos.comentarios = lareseniaParaEditar.comentarios;
            EntityState estado = _elcontexto.Entry(lareseniaenBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elcontexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}
