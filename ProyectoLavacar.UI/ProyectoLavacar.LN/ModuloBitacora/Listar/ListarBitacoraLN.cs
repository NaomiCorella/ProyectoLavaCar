using Newtonsoft.Json;
using ProyectoLavacar.Abstracciones.AccesoADatos.Interfaces.ModuloBitacora.Listar;
using ProyectoLavacar.Abstracciones.LN.Interfaces.ModuloBitacora.Listar;
using ProyectoLavacar.Abstracciones.Modelos.ModuloBitacora;
using ProyectoLavacar.Abstracciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloBitacora.Listar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBancoNacional.LN.ModuloBitacora.Listar
{
    public class ListarBitacoraLN : IListarBitacoraLN
    {
        IListarBitacoraAD _ListarBitacoraAD;

        public ListarBitacoraLN()
        {
            _ListarBitacoraAD = new ListarBitacoraAD();
        }

        public List<BitacoraDto> ListarBitacora()
        {
            List<BitacoraDto> laListasDeBitacora = _ListarBitacoraAD.ListarBitacora();
            return laListasDeBitacora;
        }
        private List<BitacoraDto> ObtenerLaListaConvertida(List<BitacoraTabla> laListasDeBitacoras)
        {
            List<BitacoraDto> laListaDeBitacoras = new List<BitacoraDto>();
            foreach (BitacoraTabla laBitacora in laListasDeBitacoras)
            {
                laListaDeBitacoras.Add(ConvertirObjetoFinanzasDto(laBitacora));
            }
            return laListaDeBitacoras;
        }
        private BitacoraDto ConvertirObjetoFinanzasDto(BitacoraTabla laBitacora)
        {
         
            return new BitacoraDto
            {
                IdEvento = laBitacora.IdEvento,
                TablaDeEvento = laBitacora.TablaDeEvento,
                TipoDeEvento = laBitacora.TipoDeEvento,
                FechaDeEvento = laBitacora.FechaDeEvento.ToString("dd-MM-yyyy hh:mm tt"),
                DescripcionDeEvento = laBitacora.DescripcionDeEvento,
                StackTrace = laBitacora.StackTrace,
                DatosAnteriores = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<object>(laBitacora.DatosAnteriores)),
                DatosPosteriores = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<object>(laBitacora.DatosPosteriores))

            };
        }
    }
}