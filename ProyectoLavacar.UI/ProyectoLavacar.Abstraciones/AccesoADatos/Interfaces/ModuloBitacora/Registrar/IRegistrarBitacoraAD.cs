using ProyectoLavacar.Abstracciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstracciones.AccesoADatos.Interfaces.ModuloBitacora.Registrar
{
    public interface IRegistrarBitacoraAD
    {
        Task<int> RegistrarBitacora(BitacoraTabla laBitacoraARegistrar);
    }
}
