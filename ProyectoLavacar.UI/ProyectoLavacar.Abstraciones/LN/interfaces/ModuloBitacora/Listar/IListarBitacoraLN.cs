﻿using ProyectoLavacar.Abstracciones.Modelos.ModuloBitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstracciones.LN.Interfaces.ModuloBitacora.Listar
{
    public interface IListarBitacoraLN
    {
        List<BitacoraDto> ListarBitacora();
    }
}
