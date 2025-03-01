using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.DetallesAjustes
{
    public interface IDetallesAjustesAD
    {
        AjustesSalarialesTabla Detalle(int idAjuste);
    }
}
