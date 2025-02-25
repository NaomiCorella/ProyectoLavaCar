a
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
                           join ajuste in _elContexto.AjustesSalarialesTabla on nomina.IdNomina equals ajuste.IdNomina into ajustes
                           from ajuste in ajustes.DefaultIfEmpty()  
                           join tramite in _elContexto.TramitesTabla on nomina.IdNomina equals tramite.IdNomina into tramites
                           from tramite in tramites.DefaultIfEmpty() 
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
                               IdAjusteSalarial = ajuste != null ? ajuste.IdAjusteSalarial : (int?)null,  
                               Monto = ajuste != null ? ajuste.Monto : (decimal?)null, 
                               RazonAjuste = ajuste != null ? ajuste.Razon : null,  
                               IdTramite = tramite != null ? tramite.IdTramite : (int?)null,  
                               FechaInicio = tramite != null ? tramite.FechaInicio.ToString() : null,  
                               duracion = tramite != null ? tramite.duracion : (int?)null,  
                               RazonTramite = tramite != null ? tramite.Razon : null,  
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
                               numeroCuenta = usuario.numeroCuenta,
                               totalBono = nomina.totalBono,
                               totalDedu = nomina.totalDedu
                           };


            return consulta.FirstOrDefault(); 
        }
    }
}
