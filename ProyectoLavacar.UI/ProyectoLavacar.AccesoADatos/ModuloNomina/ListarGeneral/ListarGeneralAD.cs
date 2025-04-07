using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarGeneral;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.ListarGeneral
{
    public class ListarGeneralAD : IListarGeneralAD
    {
        Contexto _elContexto;

        public ListarGeneralAD()
        {
            _elContexto = new Contexto();
        }

        public List<GeneralDto> ListarGeneralTodo()
        {
            List<GeneralDto> lalistaGeneral = (from nomina in _elContexto.NominaTabla
                                               join usuario in _elContexto.UsuariosTabla
                                               on nomina.IdEmpleado equals usuario.Id
                                               select new GeneralDto
                                               {
                                                   IdEmpleado = nomina.IdEmpleado,
                                                   cedula = usuario.cedula,
                                                   correo = usuario.Email,
                                                   DiasDispoVacaciones = nomina.DiasDispoVacaciones,
                                                   DiasUtiliVacaciones = nomina.DiasUtiliVacaciones,
                                                   estado = usuario.estado,
                                                   FechaDePago = nomina.FechaDePago,
                                                   Estado = nomina.Estado,
                                                   HorasDobles = nomina.HorasDobles,
                                                   HorasExtras = nomina.HorasExtras,
                                                   HorasOrdinarias = nomina.HorasOrdinarias,
                                                   IdNomina = nomina.IdNomina,
                                                   Incapacidad = nomina.Incapacidad,
                                                   nombre = usuario.nombre,
                                                   numeroCuenta = usuario.numeroCuenta,
                                                   PeriodoDePago = nomina.PeriodoDePago,
                                                   primer_apellido = usuario.primer_apellido,
                                                   puesto = usuario.puesto,
                                                   SalarioBruto = nomina.SalarioBruto,
                                                   SalarioNeto = nomina.SalarioNeto,
                                                   segundo_apellido = usuario.segundo_apellido,
                                                   telefono = usuario.PhoneNumber,
                                                   TipoDeContrato = nomina.TipoDeContrato,
                                                   turno = usuario.turno,
                                                   totalBono = nomina.totalBono,
                                                   totalDedu = nomina.totalDedu
                                               }).Distinct().ToList();

            return lalistaGeneral;
        }
    }
}

