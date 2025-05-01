using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloServicios.ObtenerPorId;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloServicios.ObtenerPorId
{
    public class BuscarAsyncSerAD : IBuscarAsyncSerAD
    {
        Contexto _elContexto;

        public BuscarAsyncSerAD()
        {
            _elContexto = new Contexto();
        }

        // Método asincrónico para obtener un servicio por id
        public async Task<ServiciosTabla> DetalleAsync(int idServicio)
        {
            // Usamos 'FirstOrDefaultAsync' para hacerlo asincrónico
            return await _elContexto.ServiciosTabla
                .Where(elServicio => elServicio.idServicio == idServicio)
                .FirstOrDefaultAsync();
        }
    }
}