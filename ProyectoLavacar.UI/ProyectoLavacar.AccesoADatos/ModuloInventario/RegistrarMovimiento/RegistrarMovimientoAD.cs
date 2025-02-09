using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.Crear;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloInventario.RegistrarMovimiento;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloInventario.RegistrarMovimiento
{
    public class RegistrarMovimientoAD : IRegistrarMovimientoAD
    {
       
            Contexto _elContexto;

            public RegistrarMovimientoAD()
            {
                _elContexto = new Contexto();
            }
            public async Task<int> Registrar(MovimientoTabla movimientoaRegistrar)
            {
                try
                {
                    _elContexto.MovimientoTabla.Add(movimientoaRegistrar);
                    EntityState estado = _elContexto.Entry(movimientoaRegistrar).State = System.Data.Entity.EntityState.Added;
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

