using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.Editar;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloInventario.Editar
{
    public class EditarInventarioAD : IEditarInventarioAD
    {
        Contexto _elcontexto;

        public EditarInventarioAD()
        {
            _elcontexto = new Contexto();
        }
        public async Task<int> EditarInventario(InventarioTabla elInventarioParaEditar)
        {
            InventarioTabla laPersonaEnBaseDeDatos = _elcontexto.InventarioTabla.Where(elInventario => elInventario.idInventario == elInventarioParaEditar.idInventario).FirstOrDefault();
            laPersonaEnBaseDeDatos.nombre = elInventarioParaEditar.nombre;
            laPersonaEnBaseDeDatos.precioUnitario = elInventarioParaEditar.precioUnitario;
            laPersonaEnBaseDeDatos.cantidadDisponible = elInventarioParaEditar.cantidadDisponible;
            laPersonaEnBaseDeDatos.categoria = elInventarioParaEditar.categoria;

            EntityState estado = _elcontexto.Entry(laPersonaEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elcontexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;

        }
    }
}
