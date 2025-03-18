
using ProyectoLavacar.Abstracciones.Modelos.ModuloBitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstracciones.AccesoADatos.Interfaces.ModuloBitacora.Listar
{
    public interface IListarBitacoraAD
    {
        List<BitacoraDto> ListarBitacora();
    }
}
