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
                                                           
                                                             IdEmpleado= elUnicoEmpleado.IdEmpleado,
                                                             cedula = empleados.cedula,
                                                             correo= empleados.Email,
                                                             DiasDispoVacaciones = elUnicoEmpleado.DiasDispoVacaciones,
                                                             DiasUtiliVacaciones = elUnicoEmpleado.DiasUtiliVacaciones,
                                                             estado = empleados.estado,
                                                             FechaDePago = elUnicoEmpleado.FechaDePago,
                                                             Estado = elUnicoEmpleado.Estado,
                                                             HorasDobles = elUnicoEmpleado.HorasDobles,
                                                             HorasExtras = elUnicoEmpleado.HorasExtras,
                                                             HorasOrdinarias  = elUnicoEmpleado.HorasOrdinarias,
                                                             IdNomina = elUnicoEmpleado.IdNomina,
                                                             Incapacidad = elUnicoEmpleado.Incapacidad,
                                                             nombre = empleados.nombre,
                                                             numeroCuenta = empleados.numeroCuenta,
                                                             PeriodoDePago = elUnicoEmpleado.PeriodoDePago,
                                                             primer_apellido = empleados.primer_apellido,
                                                             puesto = empleados.puesto,
                                                             SalarioBruto = elUnicoEmpleado.SalarioBruto,
                                                             SalarioNeto = elUnicoEmpleado.SalarioNeto,
                                                             segundo_apellido = empleados.segundo_apellido,
                                                             telefono = empleados.PhoneNumber,
                                                             TipoDeContrato = elUnicoEmpleado.TipoDeContrato,
                                                             turno = empleados.turno,
                                                             totalBono = elUnicoEmpleado.totalBono,
                                                             totalDedu = elUnicoEmpleado.totalDedu,
                                                              deduccionCCSS = elUnicoEmpleado.deduccionCCSS,
                                                             deduccionISR = elUnicoEmpleado.deduccionISR,
                                                             bonoHorasExtra = elUnicoEmpleado.bonoHorasExtra


                                                         }).ToList();
        return lalistaDeUnicoEmpleado;
    }
}
}
  
