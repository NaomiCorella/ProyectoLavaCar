using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.IngresarHoras;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.RegistrarHoraEntrada
{
    public class RegistrarHoraEntradaAD : IRegistroHoraEntradaAD
    {

        Contexto _elContexto;

        public RegistrarHoraEntradaAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> RegistrarHoraEntrada(RegistroHorasTabla horaEntrada)
        {
            try
            {
                _elContexto.RegistroHorasTabla.Add(horaEntrada);
                EntityState estado = _elContexto.Entry(horaEntrada).State = System.Data.Entity.EntityState.Added;
                int cantidadDeDatosAlmacenados = await _elContexto.SaveChangesAsync();
                return cantidadDeDatosAlmacenados;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
