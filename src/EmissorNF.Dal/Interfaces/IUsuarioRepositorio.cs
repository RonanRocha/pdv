using EmissorNF.Dominio.Entidades;
using System.Collections.Generic;


namespace EmissorNF.Dal.Interfaces
{
    public interface IUsuarioRepositorio
    {
        List<Usuario> RecuperTodos();
        List<Cliente> RecuperarTodosClientes();
    }
}
