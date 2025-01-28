﻿using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloReservas.EditarCliente
{
    public interface IEditarClienteLN
    {
        Task<int> EditarPersonas(ReservasDto laReserva);
    }
}
