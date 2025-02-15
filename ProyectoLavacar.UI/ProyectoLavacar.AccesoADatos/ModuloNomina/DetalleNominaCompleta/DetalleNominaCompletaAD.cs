using ProyectoLavacar.AccesoADatos.ModuloNominaCompleta.Detalles;
using System;
using System.Linq;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.DetalleNominaCompleta
{
    public class DetalleNominaCompletaAD : IDetallesNominaCompletaAD
    {
        private Contexto _elContexto;

        public DetalleNominaCompletaAD()
        {
            _elContexto = new Contexto();
        }

        public NominaCompletaDto Detalle(int idNomina)
        {
            var consulta = from nomina in NominaCompleta
                           join ajuste in _elContexto.AjustesSalariales on nomina.IdEmpleado equals ajuste.IdEmpleado
                           join tramite in _elContexto.Tramites on nomina.IdEmpleado equals tramite.IdEmpleado
                           join usuario in _elContexto.Usuarios on nomina.IdEmpleado equals usuario.Id
                           where nomina.IdNomina == idNomina
                           select new NominaCompletaDto
                           {
                               IdNomina = nomina.IdNomina,
                               SalarioNeto = nomina.SalarioNeto,
                               SalarioBruto = nomina.SalarioBruto,
                               FechaDePago = nomina.FechaDePago,
                               PeriodoDePago = nomina.PeriodoDePago,
                               HorasOrdinarias = nomina.HorasOrdinarias,
                               HorasExtras = nomina.HorasExtras,
                               HorasDobles = nomina.HorasDobles,
                               DiasDispoVacaciones = nomina.DiasDispoVacaciones,
                               DiasUtiliVacaciones = nomina.DiasUtiliVacaciones,
                               Incapacidad = nomina.Incapacidad,
                               TipoDeContrato = nomina.TipoDeContrato,
                               EstadoNomina = nomina.Estado,
                               IdAjusteSalarial = ajuste.IdAjusteSalarial,
                               MontoAjuste = ajuste.Monto,
                               RazonAjuste = ajuste.Razon,
                               IdTramite = tramite.IdTramite,
                               FechaInicioTramite = tramite.FechaInicio,
                               FechaFinTramite = tramite.FechaFin,
                               RazonTramite = tramite.Razon,
                               IdEmpleado = usuario.Id,
                               NombreEmpleado = usuario.nombre,
                               PrimerApellidoEmpleado = usuario.primer_apellido,
                               SegundoApellidoEmpleado = usuario.segundo_apellido,
                               TelefonoEmpleado = usuario.PhoneNumber,
                               CorreoEmpleado = usuario.Email,
                               CedulaEmpleado = usuario.cedula,
                               PuestoEmpleado = usuario.puesto,
                               TurnoEmpleado = usuario.turno,
                               EstadoEmpleado = usuario.estado,
                               NumeroCuentaEmpleado = usuario.numeroCuenta
                           };

            return consulta/*FirstOrDefault()*/; 
        }
    }
}
