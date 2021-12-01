using PDV.Dominio.Entidades;
using System.Collections.Generic;


namespace PDV.Dal.Interfaces
{
    public interface IUsuarioRepositorio
    {
        List<Usuario> RecuperTodos();
        List<Cliente> RecuperarTodosClientes();
    }
}
