using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.Crear;
using ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloServicios.Crear;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.Crear;
using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using ProyectoLavacar.AccesoADatos.ModuloReservas.Crear;
using ProyectoLavacar.AccesoADatos.ModuloServicios.Crear;
using ProyectoLavacar.LN.General.Fecha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.LN.ModuloServicios
{
    public class CrearServiciosLN : ICrearServiciosLN
    {
        ICrearServiciosAD _crearServicios;
        IFecha _fecha;

        public CrearServiciosLN()
        {
            _fecha = new Fecha();
            _crearServicios = new CrearServiciosAD();
        }

        public async Task<int> Crear(ServiciosDto modelo)
        {
            int cantidadDeDatosAlmacenados = await _crearServicios.Crear(ConvertirObjetoArchivosTabla(modelo));
            return cantidadDeDatosAlmacenados;
        }

        public ServiciosTabla ConvertirObjetoArchivosTabla(ServiciosDto elServicio)
        {
            return new ServiciosTabla
            {
                idServicio = elServicio.idServicio,
                costo = elServicio.costo,
                nombre = elServicio.nombre,
                descripcion = elServicio.descripcion,
                tiempoDuracion = elServicio.tiempoDuracion,
                estado = true,
                modalidad = elServicio.modalidad,
                precio = elServicio.precio
            };
        }
    }
}
