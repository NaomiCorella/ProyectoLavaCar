
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.DetalleNominaCompleta;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
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
            var consulta = from nomina in _elContexto.NominaTabla
                           join ajuste in _elContexto.AjustesSalarialesTabla on nomina.IdEmpleado equals ajuste.IdEmpleado
                           join tramite in _elContexto.TramitesTabla on nomina.IdEmpleado equals tramite.IdEmpleado
                           join usuario in _elContexto.UsuariosTabla on nomina.IdEmpleado equals usuario.Id
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
                               Estado = nomina.Estado,
                               IdAjusteSalarial = ajuste.IdAjusteSalarial,
                               Monto = ajuste.Monto,
                               RazonAjuste = ajuste.Razon,
                               IdTramite = tramite.IdTramite,
                               FechaInicio = tramite.FechaInicio,
                               FechaFin = tramite.FechaFin,
                               RazonTramite = tramite.Razon,
                               IdEmpleado = usuario.Id,
                               nombre = usuario.nombre,
                               primer_apellido = usuario.primer_apellido,
                               segundo_apellido = usuario.segundo_apellido,
                               telefono = usuario.PhoneNumber,
                               correo = usuario.Email,
                               cedula = usuario.cedula,
                               puesto = usuario.puesto,
                               turno = usuario.turno,
                               estado = usuario.estado,
                               numeroCuenta = usuario.numeroCuenta
                           };

            return consulta/*FirstOrDefault()*/; 
        }
    }
}
