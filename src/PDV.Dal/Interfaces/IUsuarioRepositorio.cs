using PDV.Dominio.Entidades;
using System;
using System.Collections.Generic;


namespace PDV.Dal.Interfaces
{
    public interface IUsuarioRepositorio : IDisposable
    {
        List<Usuario> RecuperTodos();
        List<Cliente> RecuperarTodosClientes();
    }
}
