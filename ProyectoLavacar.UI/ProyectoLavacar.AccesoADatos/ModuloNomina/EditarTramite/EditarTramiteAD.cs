using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.EditarTramite;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.EditarTramite
{
    public class EditarTramiteAD :IEditarTramiteAD
    {
        Contexto _elcontexto;

        public EditarTramiteAD()
        {
            _elcontexto = new Contexto();
        }
        public async Task<int> Editar(TramitesTabla tramite)
        {
            TramitesTabla tramiteenBaseDeDatos = _elcontexto.TramitesTabla.Where(elTramite => elTramite.IdTramite == tramite.IdTramite).FirstOrDefault();
            tramiteenBaseDeDatos.duracion = tramite.duracion;
            tramiteenBaseDeDatos.estado = tramite.estado;
             EntityState estado = _elcontexto.Entry(tramiteenBaseDeDatos).State = System.Data.Entity.EntityState.Modified;

            int cantidadDeDatosAlmacenados = await _elcontexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}
