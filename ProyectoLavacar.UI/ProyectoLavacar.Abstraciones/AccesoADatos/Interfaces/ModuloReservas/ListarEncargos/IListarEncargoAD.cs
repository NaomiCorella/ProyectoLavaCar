﻿using ProyectoLavacar.Abstraciones.Modelos.ModuloReservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloReservas.ListarEncargos
{
    public interface IListarEncargoAD
    {
        List<ReservasDto> ListarReservasEmpleado(string idEmpleado);
    }
}
