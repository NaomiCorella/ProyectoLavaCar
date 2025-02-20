using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.General.Conversiones.ModuloNomina
{
    public class ConvertirAjustesSalarialesDtoAAjustesSalarialesTabla : IConvertirAjustesSalarialesDtoAAjustesSalarialesTabla

    {
        public AjustesSalarialesTabla ConvertirAjustesSalariales(AjustesSalarialesDto elAjustesSalariales)
        {
            return new AjustesSalarialesTabla
            {
                IdAjusteSalarial=elAjustesSalariales.IdAjusteSalarial,
                IdEmpleado=elAjustesSalariales.IdEmpleado,
                Monto=elAjustesSalariales.Monto,
                Razon = elAjustesSalariales.Razon
            };
        }
    }
}
