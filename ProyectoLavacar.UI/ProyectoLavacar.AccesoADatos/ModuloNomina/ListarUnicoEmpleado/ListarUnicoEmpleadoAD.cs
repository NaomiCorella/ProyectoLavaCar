using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.ListarUnicoEmpleado
{
    public class ListarUnicoEmpleadoAD : IListarUnicoEmpleadoAD
    {
        Contexto _elContexto;

    public ListarUnicoEmpleadoAD()
    {
        _elContexto = new Contexto();
    }

    public List<UnicoEmpleadoDto> ListarUnicoEmpleado(string idEmpleado)
    {
        List<UnicoEmpleadoDto> lalistaDeUnicoEmpleado = (from elUnicoEmpleado in _elContexto.NominaTabla
                                                         join empleados in _elContexto.UsuariosTabla on elUnicoEmpleado.IdEmpleado equals empleados.Id
                                                         where elUnicoEmpleado.IdEmpleado == idEmpleado


                                                         select new UnicoEmpleadoDto
                                                         {
                                                             IdNomina = elUnicoEmpleado.IdNomina,
                                                             SalarioNeto = elUnicoEmpleado.SalarioNeto,
                                                             SalarioBruto = elUnicoEmpleado.SalarioBruto,
                                                             FechaDePago = elUnicoEmpleado.FechaDePago,

                                                             IdEmpleado = empleados.Id,
                                                             nombre = empleados.nombre,

                                                         }).ToList();
        return lalistaDeUnicoEmpleado;
    }
}
}
  
