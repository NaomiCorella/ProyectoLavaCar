using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.Editar;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.EditarNomina
{
    public class EditarNominaAD : IEditarNominaAD
    {
        Contexto _elcontexto;

        public EditarNominaAD()
        {
            _elcontexto = new Contexto();
        }
        public async Task<int> EditarNomina(NominaTabla elNominaParaEditar)
        {
            NominaTabla elNominaEnBaseDeDatos = _elcontexto.NominaTabla.Where(elNomina => elNomina.IdNomina == elNominaParaEditar.IdNomina).FirstOrDefault();
            elNominaEnBaseDeDatos.IdNomina = elNominaParaEditar.IdNomina;
            elNominaEnBaseDeDatos.IdEmpleado = elNominaParaEditar.IdEmpleado;
            elNominaEnBaseDeDatos.SalarioNeto = elNominaParaEditar.SalarioNeto;
            elNominaEnBaseDeDatos.SalarioBruto = elNominaParaEditar.SalarioBruto;
            elNominaEnBaseDeDatos.FechaDePago = elNominaParaEditar.FechaDePago;
            elNominaEnBaseDeDatos.PeriodoDePago = elNominaParaEditar.PeriodoDePago;
            elNominaEnBaseDeDatos.HorasOrdinarias = elNominaParaEditar.HorasOrdinarias;
            elNominaEnBaseDeDatos.HorasExtras = elNominaParaEditar.HorasExtras;
            elNominaEnBaseDeDatos.HorasDobles = elNominaParaEditar.HorasDobles;
            elNominaEnBaseDeDatos.DiasDispoVacaciones = elNominaParaEditar.DiasDispoVacaciones;
            elNominaEnBaseDeDatos.DiasUtiliVacaciones = elNominaParaEditar.DiasUtiliVacaciones;
            elNominaEnBaseDeDatos.Incapacidad = elNominaParaEditar.Incapacidad;
            elNominaEnBaseDeDatos.TipoDeContrato = elNominaParaEditar.TipoDeContrato;
            elNominaEnBaseDeDatos.Estado = elNominaParaEditar.Estado;
            elNominaEnBaseDeDatos.totalBono = elNominaParaEditar.totalBono;
            elNominaEnBaseDeDatos.totalDedu = elNominaParaEditar.totalDedu;
            EntityState estado = _elcontexto.Entry(elNominaEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;
            int cantidadDeDatosAlmacenados = await _elcontexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}

