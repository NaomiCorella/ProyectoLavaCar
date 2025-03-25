using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.DetallesAjustes;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.DetallesTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.DetallesAjustes;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloNomina.DetalleAjustes;
using ProyectoLavacar.AccesoADatos.ModuloNomina.DetalleTramite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.DetalleAjustes
{
    public class DetallesAjustesLN : IDetallesAjustesLN
    {
        IDetallesAjustesAD _obtenerPorIdNominaAD;
        public DetallesAjustesLN()
        {
            _obtenerPorIdNominaAD = new DetalleAjustesAD();
        }
        public AjustesSalarialesDto Detalle(int idTramite)
        {
            AjustesSalarialesTabla nominaEnBaseDeDatos = _obtenerPorIdNominaAD.Detalle(idTramite);
            AjustesSalarialesDto nominaAMostrar = ConvertirANominaAMostrar(nominaEnBaseDeDatos);
            return nominaAMostrar;
        }
        private AjustesSalarialesDto ConvertirANominaAMostrar(AjustesSalarialesTabla ajustes)
        {

            return new AjustesSalarialesDto
            {

                IdAjusteSalarial = ajustes.IdAjusteSalarial,
                IdNomina = ajustes.IdNomina,
                Monto = ajustes.Monto,
                Razon = ajustes.Razon,
                tipo = ajustes.tipo
            };
        }
    }
}
