using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.CrearRespuesta
{
    public interface ICrearRespuestaAD
    {
        Task<int> CrearRespuestaResenia(RespuestaTabla larespuesta);
    }
}
