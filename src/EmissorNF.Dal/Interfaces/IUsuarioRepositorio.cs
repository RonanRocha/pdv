﻿using EmissorNF.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorNF.Dal.Interfaces
{
    public interface IUsuarioRepositorio
    {
        List<Usuario> RecuperTodos();
        List<Cliente> RecuperarTodosClientes();
    }
}