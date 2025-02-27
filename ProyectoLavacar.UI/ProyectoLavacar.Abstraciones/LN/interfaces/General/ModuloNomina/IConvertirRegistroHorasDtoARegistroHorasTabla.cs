using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloNomina
{
    public interface IConvertirRegistroHorasDtoARegistroHorasTabla
    {
        RegistroHorasTabla Convertir(RegistroHorasDto hora);
    }
}
