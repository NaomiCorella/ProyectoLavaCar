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
                                                         join empleados in _elContexto.UsuariosTabla on elUnicoEmpleado.idEmpleado equals empleados.Id
                                                         where elUnicoEmpleado.idEmpleado == idEmpleado


                                                         select new UnicoEmpleadoDto
                                                         {
                                                             IdNomina = nomina.IdNomina,
                                                             SalarioNeto = nomina.SalarioNeto,
                                                             SalarioBruto = nomina.SalarioBruto,
                                                             FechaDePago = nomina.FechaDePago,

                                                             IdEmpleado = usuario.Id,
                                                             nombre = usuario.nombre,

                                                         }).ToList();
        return lalistaDeUnicoEmpleado;
    }
}
}
  
