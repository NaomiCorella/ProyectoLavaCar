﻿
using ProyectoLavacar.Abstraciones.Modelos.ModuloCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.AccesoADatos.Interfaces.ModuloCompra.Listar
{
    public interface IListarCompraAD
    {
        List<CompraDto> ListarCompra();
    }
}
