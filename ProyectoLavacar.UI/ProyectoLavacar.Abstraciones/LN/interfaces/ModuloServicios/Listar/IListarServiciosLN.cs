﻿using ProyectoLavacar.Abstraciones.Modelos.ModeloServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloServicios.Listar
{
    public interface IListarServiciosLN
    {
        List<ServiciosDto> ListarServicios();
    }
}
