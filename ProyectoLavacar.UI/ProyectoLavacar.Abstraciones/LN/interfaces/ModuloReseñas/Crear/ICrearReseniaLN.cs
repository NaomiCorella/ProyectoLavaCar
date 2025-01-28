﻿using ProyectoLavacar.Abstraciones.Modelos.ModuloReseñas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReseñas.Crear
{
    public interface ICrearReseniaLN
    {
        Task<int> CrearResenia(ReseniaDto modelo);
    }
}
