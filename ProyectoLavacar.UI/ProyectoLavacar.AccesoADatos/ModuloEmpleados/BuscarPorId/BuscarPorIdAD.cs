using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloEmpleados.BuscarPorId;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.AccesoADatos.ModuloEmpleados.BuscarPorId
{
    public class BuscarPorIdAD : IBuscarPorIdAD
    {
        Contexto _elContexto;

        public BuscarPorIdAD()
        {
            _elContexto = new Contexto();
        }
        public EmpleadosTabla Detalle(int idEmpleado)
        {
            EmpleadosTabla elEmpleadoEnBaseDeDatos = _elContexto.EmpleadosTabla.Where(elUsuario => elUsuario.idEmpleado == idEmpleado).FirstOrDefault();
            return elEmpleadoEnBaseDeDatos;
        }
    }
}