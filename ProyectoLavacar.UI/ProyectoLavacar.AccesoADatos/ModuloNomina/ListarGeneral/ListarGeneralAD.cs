using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarGeneral;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;

namespace ProyectoLavacar.AccesoADatos.ModuloNomina.ListarGeneral
{
    public class ListarGeneralAD : IListarGeneralAD
    {
        Contexto _elContexto;

        public ListarGeneralAD()
        {
            _elContexto = new Contexto();
        }

        public List<GeneralDto> ListarGeneralTodo()
        {
            List<GeneralDto> lalistaGeneral = (from nomina in _elContexto.NominaTabla
                                               join usuario in _elContexto.UsuariosTabla
                                               on nomina.IdEmpleado equals usuario.Id
                                               select new GeneralDto
                                               {
                                                   IdNomina = nomina.IdNomina,
                                                   SalarioNeto = nomina.SalarioNeto,
                                                   FechaDePago = nomina.FechaDePago,
                                                   Estado = nomina.Estado,
                                                   IdEmpleado = usuario.Id,
                                                   nombre = usuario.nombre,

                                               }).ToList();

            return lalistaGeneral;
        }
    }
}

