using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.RegistroHoraSalida;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.RegistrarHoraSalida
{
    public class RegistrarHoraSalidaAD  : IRegistroHoraSalidaAD
    {
        Contexto _elcontexto;

        public RegistrarHoraSalidaAD()
        {
            _elcontexto = new Contexto();
        }
        public async Task<int> RegistroHoraSalida(RegistroHorasTabla horaSalida)
        {
            RegistroHorasTabla horaEnBaseDeDatos = _elcontexto.RegistroHorasTabla.Where(elRegistro => elRegistro.idRegistro == horaSalida.idRegistro).FirstOrDefault();
            horaEnBaseDeDatos.HoraSalida = horaSalida.HoraSalida;
            horaEnBaseDeDatos.estado = horaSalida.estado;
            horaEnBaseDeDatos.totalHoras = horaSalida.totalHoras;
            EntityState estado = _elcontexto.Entry(horaEnBaseDeDatos).State = System.Data.Entity.EntityState.Modified;

            int cantidadDeDatosAlmacenados = await _elcontexto.SaveChangesAsync();
            return cantidadDeDatosAlmacenados;
        }
    }
}
