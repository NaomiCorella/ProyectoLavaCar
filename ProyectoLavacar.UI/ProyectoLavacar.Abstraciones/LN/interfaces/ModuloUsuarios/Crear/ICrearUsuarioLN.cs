﻿using ProyectoLavacar.Abstraciones.Modelos.ModuloUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLavacar.Abstraciones.LN.interfaces.ModuloUsuarios.Crear
{
    public interface ICrearUsuarioLN
    {
        Task<int> RegistrarUsuarios(UsuariosDto modelo);

    }
}
