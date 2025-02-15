using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ListarUnicoEmpleado;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloNomina.ListarUnicoEmpleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.ListarUnicoEmpleado
{
    public class ListarUnicoEmpleadoLN : IListarUnicoEmpleadoLN
    {
         IListarUnicoEmpleadoAD _listarUnicoEmpleadoAD;

        public ListarUnicoEmpleadoLN()
        {
            _listarUnicoEmpleadoAD = new ListarUnicoEmpleadoAD();
        }

        public List<UnicoEmpleadoDto> ListarNomina(int idEmpleado)
        {
            List<UnicoEmpleadoDto> listaUnicoEmpleado = _listarUnicoEmpleadoAD.ListarUnicoEmpleado(idEmpleado);
            return listaUnicoEmpleado;
        }

        private List<UnicoEmpleadoDto> ObtenerListaConvertida(List<NominaTabla> listaNomina, List<UsuariosTabla> listaUsuarios)
        {
            var joinLista = from nomina in listaNomina
                            join usuario in listaUsuarios on nomina.IdEmpleado equals usuario.Id
                            select new UnicoEmpleadoDto
                            {
                                IdNomina = nomina.IdNomina,
                                IdEmpleado = usuario.Id,
                                SalarioNeto = nomina.SalarioNeto,
                                SalarioBruto = nomina.SalarioBruto,
                                FechaDePago = nomina.FechaDePago,
                                nombre = usuario.nombre
                            };

            return joinLista.ToList();
        }

        private UnicoEmpleadoDto ConvertirObjetoNominaDto(NominaTabla nomina, UsuariosTabla usuario)
        {
            return new UnicoEmpleadoDto
            {
                IdNomina = nomina.IdNomina,
                IdEmpleado = usuario.Id,
                SalarioNeto = nomina.SalarioNeto,
                SalarioBruto = nomina.SalarioBruto,
                FechaDePago = nomina.FechaDePago,
                nombre = usuario.nombre
            };
        }



    }
}
