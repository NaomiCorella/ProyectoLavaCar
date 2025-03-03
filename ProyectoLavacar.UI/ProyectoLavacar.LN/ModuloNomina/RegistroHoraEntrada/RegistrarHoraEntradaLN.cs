using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.IngresarHoras;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReseñas.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.RegistroHoraEntrada;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloNomina.RegistrarHoraEntrada;
using ProyectoLavacar.AccesoADatos.ModuloReseñas.Crear;
using ProyectoLavacar.LN.General.Fecha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.RegistroHoraEntrada
{
    public class RegistrarHoraEntradaLN : IRegistroHoraEntradaLN
    {
        IRegistroHoraEntradaAD _registrar;
        IFecha _fecha;

        public RegistrarHoraEntradaLN()
        {
            _fecha = new Fecha();
            _registrar = new RegistrarHoraEntradaAD();
        }

        public async Task<int> RegistrarHoraEntrada(RegistroHorasDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _registrar.RegistrarHoraEntrada(ConvertirObjetoArchivosTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }

        public RegistroHorasTabla ConvertirObjetoArchivosTabla(RegistroHorasDto modelo)
        {
            return new RegistroHorasTabla
            {
              
                idRegistro = modelo.idRegistro,
                HoraSalida = _fecha.ObtenerFecha().AddDays(2),
                HoraEntrada = _fecha.ObtenerFecha(),
                idEmpleado=modelo.idEmpleado,
                estado = modelo.estado,
                totalHoras = modelo.totalHoras

            };
        }
    }
}
