﻿using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using ProyectoLavacar.Abstraciones.ModelosDeBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.General.ModuloReseñas
{
    public interface IConvertirResenia
    {
        ReseniasTabla ConvertirReservas(ReseniaDto laResenia);
    }
}
