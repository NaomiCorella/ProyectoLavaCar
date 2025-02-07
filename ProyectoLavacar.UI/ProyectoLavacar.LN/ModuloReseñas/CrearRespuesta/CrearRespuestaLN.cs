using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReseñas.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.CrearRespuesta;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloReseñas.Crear;
using ProyectoLavacar.AccesoADatos.ModuloReseñas.CrearRespuesta;
using ProyectoLavacar.LN.General.Fecha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloReseñas.CrearRespuesta
{
    public class CrearRespuestaLN : ICrearRespuestaLN
    {
        ICrearRespuestaAD _crearRespuesta;
        IFecha _fecha;

        public CrearRespuestaLN()
        {
            _fecha = new Fecha();
            _crearRespuesta = new CrearRespuestaAD();
        }

        public async Task<int> CrearRespuesta(RespuestaDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _crearRespuesta.CrearRespuestaResenia(ConvertirObjetoArchivosTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }

        public RespuestaTabla ConvertirObjetoArchivosTabla(RespuestaDto respuesta)
        {
            return new RespuestaTabla
            {
                idRespuesta = respuesta.idRespuesta,
                idEmpleado = respuesta.idEmpleado,
                fecha = _fecha.ObtenerFecha(),
                comentarios = respuesta.comentarios,
                estado = respuesta.estado,
                idResenia = respuesta.idResenia,

            };
        }
    }
}

