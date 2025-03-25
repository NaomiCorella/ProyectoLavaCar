using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.EditarTramite;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearAjusteSalariales;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.DetallesAjustes;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.DetallesTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarTramites;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.ObtenerPorId;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.AccesoADatos.ModuloNomina.EditarTramite;
using ProyectoLavacar.LN.General.Conversiones.ModuloNomina;
using ProyectoLavacar.LN.ModuloAjustesSalariales.CrearAjustesSalariales;
using ProyectoLavacar.LN.ModuloNomina.CrearTramites;
using ProyectoLavacar.LN.ModuloNomina.DetalleAjustes;
using ProyectoLavacar.LN.ModuloNomina.DetallesTramites;
using ProyectoLavacar.LN.ModuloNomina.ObtenerPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.EditarTramites
{
    public class EditarTramitesLN :IEditarTramitesLN
    {
        IEditarTramiteAD _editarTramitesAD;
        IConvertirTramitesDtoATramitesTabla _convertirObjeto;
        IDetallesTramitesLN _detallesajustes;
        ICrearAjusteSalarialesLN _crearAjuste;
        IObtenerPorIdLN _obtenerNomina;
        public EditarTramitesLN()
        {
            _editarTramitesAD = new EditarTramiteAD();
            _convertirObjeto = new ConvertirTramitesDtoATramitesTabla();
            _detallesajustes = new DetallesTramitesLN();
            _crearAjuste = new CrearAjustesSalarialesLN();
            _obtenerNomina = new ObtenerPorIdLN();
        }

        public async Task<int> Editar(TramitesDto tramite)
        {

            if (tramite.tipo == "Incapacidad")
            {
                TramitesDto tramiteAnterior = _detallesajustes.Detalle(tramite.IdTramite);
                NominaDto nomina = _obtenerNomina.Detalle(tramite.IdNomina);

                decimal incapacidadAnterior = Math.Round((nomina.SalarioNeto / 30m) * tramiteAnterior.duracion, 2);
                decimal incapacidadNueva = Math.Round((nomina.SalarioNeto / 30m) * tramite.duracion, 2);

                decimal diferencia = Math.Abs(incapacidadAnterior - incapacidadNueva);

                AjustesSalarialesDto AjusteNuevo = new AjustesSalarialesDto
                {
                    IdAjusteSalarial = 0,
                    IdNomina = tramite.IdNomina,
                    Monto = diferencia,
                    Razon = "Edicion de Incapacidad",
                    tipo = "Deduccion"
                };

                await _crearAjuste.RegistarAjusteSalariales(AjusteNuevo);
                int cantidadDeDatosEditados = await _editarTramitesAD.Editar(_convertirObjeto.ConvertirTramites(tramite));
                return cantidadDeDatosEditados;
            }
            else
            {
                int cantidadDeDatosEditados = await _editarTramitesAD.Editar(_convertirObjeto.ConvertirTramites(tramite));
                return cantidadDeDatosEditados;
            }
            
        }
    }
}
