using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.CrearRespuesta
{
    public interface ICrearRespuestaLN
    {
        Task<int> CrearRespuesta(RespuestaDto modelo);
    }
}
