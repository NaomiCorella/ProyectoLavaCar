﻿using ProyectoLavacar.Abstraciones.Modelos.ModuloEmpleados;
using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloEmpleados
{
    public interface IConvertirEmpleadosDtoAEmpleadosTabla
    {
        UsuariosTabla ConvertirEmpleados(UsuariosDto elEmpleado);
    }
}
