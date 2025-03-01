using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.DetallesAjustes;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.Editar;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloNomina.EditarAjuste;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloNomina;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.CrearAjusteSalariales;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.DetallesAjustes;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloNomina.EditarAjustes;
using ProyectoLavacar.Abstraciones.Modelos.ModuloNomina;
using ProyectoLavacar.AccesoADatos.ModuloNomina.DetalleAjustes;
using ProyectoLavacar.AccesoADatos.ModuloNomina.EditarAjustes;
using ProyectoLavacar.AccesoADatos.ModuloNomina.EditarNomina;
using ProyectoLavacar.LN.General.Conversiones.ModuloNomina;
using ProyectoLavacar.LN.ModuloAjustesSalariales.CrearAjustesSalariales;
using ProyectoLavacar.LN.ModuloNomina.DetalleAjustes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloNomina.EditarAjustes
{
    public class EditarAjustesLN : IEditarAjusteLN
    {
        IEditarAjusteAD _editarAjustesAD;
        IConvertirAjustesSalarialesDtoAAjustesSalarialesTabla _convertirObjeto;
        IDetallesAjustesLN _detallesajustes;
        ICrearAjusteSalarialesLN _crearAjuste;

        public EditarAjustesLN()
        {
            _editarAjustesAD = new EditarAjustesAD();
            _convertirObjeto = new ConvertirAjustesSalarialesDtoAAjustesSalarialesTabla();
            _detallesajustes = new DetallesAjustesLN();
            _crearAjuste = new CrearAjustesSalarialesLN();
        }

        public async Task<int> Editar(AjustesSalarialesDto ajustes)
        {
            AjustesSalarialesDto ajustePasado = _detallesajustes.Detalle(ajustes.IdAjusteSalarial);
            decimal diferencia = Math.Abs(ajustes.Monto - ajustePasado.Monto);


            if (ajustes.tipo=="Deduccion")
            {
                AjustesSalarialesDto ajusteDeduccion = new AjustesSalarialesDto
                {
                    IdAjusteSalarial = ajustes.IdAjusteSalarial,
                    IdNomina = ajustes.IdNomina,
                    Monto = diferencia,
                    Razon = "Edicion de Ajuste",
                    tipo = "Deduccion"
                };
              await  _crearAjuste.RegistarAjusteSalariales(ajusteDeduccion);
            }
            else
            {
                AjustesSalarialesDto ajusteBonificacion = new AjustesSalarialesDto
                {
                    IdAjusteSalarial = ajustes.IdAjusteSalarial,
                    IdNomina = ajustes.IdNomina,
                    Monto = diferencia,
                    Razon = "Edicion de Ajuste",
                    tipo = "Bonificacion"
                };
                await _crearAjuste.RegistarAjusteSalariales(ajusteBonificacion);
            }


                int cantidadDeDatosEditados = await _editarAjustesAD.Editar(_convertirObjeto.ConvertirAjustesSalariales(ajustes));
            return cantidadDeDatosEditados;
        }
    }
}
