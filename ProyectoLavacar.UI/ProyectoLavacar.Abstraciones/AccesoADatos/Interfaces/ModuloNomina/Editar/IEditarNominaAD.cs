using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.Editar
{
    public interface IEditarNominaAD
    {
        Task<int> EditarNomina(NominaTabla laNominaParaEditar);
    }
}
