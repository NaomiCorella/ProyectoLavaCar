
using ProyectoLavacar.Abstracciones.AccesoADatos.Interfaces.ModuloBitacora.Listar;
using ProyectoLavacar.Abstracciones.Modelos.ModuloBitacora;
using ProyectoLavacar.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloBitacora.Listar
{
    public class ListarBitacoraAD : IListarBitacoraAD
    {
    
        Contexto _elContexto;

        public ListarBitacoraAD()
        {
            _elContexto = new Contexto();
        }
        public List<BitacoraDto> ListarBitacora()
        {
             List<BitacoraDto> laListaDeBitacora = (from laBitacora in _elContexto.BitacoraTabla
                                               select new BitacoraDto
                                               {
                                                   FechaDeEvento = laBitacora.FechaDeEvento.ToString(),
                                                   IdEvento = laBitacora.IdEvento,
                                                   TablaDeEvento = laBitacora.TablaDeEvento,
                                                   TipoDeEvento = laBitacora.TipoDeEvento,
                                                   DescripcionDeEvento = laBitacora.DescripcionDeEvento,
                                                   StackTrace = laBitacora.StackTrace,
                                                   DatosAnteriores = laBitacora.DatosAnteriores,
                                                   DatosPosteriores = laBitacora.DatosPosteriores
                                               }).ToList();
            return laListaDeBitacora;
        }
    }
}
