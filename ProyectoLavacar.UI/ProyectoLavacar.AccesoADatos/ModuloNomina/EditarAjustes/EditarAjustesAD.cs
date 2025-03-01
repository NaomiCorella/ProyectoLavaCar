using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.EditarAjuste;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.EditarAjustes
{
    public class EditarAjustesAD : IEditarAjusteAD
    {
        Contexto _elcontexto;

        public EditarAjustesAD()
        {
            _elcontexto = new Contexto();
        }
        public async Task<int> Editar(AjustesSalarialesTabla ajustes)
        {
            AjustesSalarialesTabla ajusteenBaseDeDatos = _elcontexto.AjustesSalarialesTabla.Where(elAjuste => elAjuste.IdAjusteSalarial == ajustes.IdAjusteSalarial).FirstOrDefault();
            ajusteenBaseDeDatos.Monto = ajustes.Monto;
            EntityState estado = _elcontexto.Entry(ajusteenBaseDeDatos).State = System.Data.Entity.EntityState.Modified;

            int cantidadDeDatosAlmacenados = await _elcontexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}
