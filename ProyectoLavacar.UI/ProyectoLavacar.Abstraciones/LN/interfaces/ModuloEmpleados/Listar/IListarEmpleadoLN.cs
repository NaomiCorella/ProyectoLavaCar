
using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloEmpleados.Listar
{
    public interface IListarEmpleadoLN
    {
        List<EmpleadosDto> ListarEmpleados();
    }
}
