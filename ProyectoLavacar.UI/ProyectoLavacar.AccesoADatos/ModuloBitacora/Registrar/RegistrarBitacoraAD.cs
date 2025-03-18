using ProyectoLavacar.Abstracciones.AccesoADatos.Interfaces.ModuloBitacora.Registrar;
using ProyectoLavacar.Abstracciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloBitacora.Registrar
{
    public class RegistrarBitacoraAD : IRegistrarBitacoraAD
    {
        Contexto _elContexto;

        public RegistrarBitacoraAD()
        {
            _elContexto = new Contexto();
        }
        public async Task<int> RegistrarBitacora(BitacoraTabla laBitacoraARegistrar)
        {
            try
            {
                _elContexto.BitacoraTabla.Add(laBitacoraARegistrar);
                EntityState estado = _elContexto.Entry(laBitacoraARegistrar).State = System.Data.Entity.EntityState.Added;
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
