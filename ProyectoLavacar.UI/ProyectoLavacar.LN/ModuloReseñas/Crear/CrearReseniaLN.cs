using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReseñas.Crear;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.Crear;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloReseñas.Crear;
using ProyectoLavacar.AccesoADatos.ModuloReservas.Crear;
using ProyectoLavacar.LN.General.Fecha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloReseñas.Crear
{
    public class CrearReseniaLN : ICrearReseniaLN
    {
        ICrearReseniaAD _crearResenia;
        IFecha _fecha;

        public CrearReseniaLN()
        {
            _fecha = new Fecha();
            _crearResenia = new CrearReseniaAD();
        }

        public async Task<int> CrearResenia(ReseniaDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _crearResenia.CrearResenia(ConvertirObjetoArchivosTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }

        public ReseniasTabla ConvertirObjetoArchivosTabla(ReseniaDto resenia)
        {
            return new ReseniasTabla
            {
                idResenia = resenia.idResenia,
                idCliente = resenia.idCliente,
                idServicio = resenia.idServicio,    
                fecha = _fecha.ObtenerFecha(),
                calificacion = resenia.calificacion,
                comentarios = resenia.comentarios,
                estado = resenia.estado

            };
        }
    }
}
