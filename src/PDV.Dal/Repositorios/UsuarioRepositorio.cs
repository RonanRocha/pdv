using PDV.Dal.Contexto;
using PDV.Dal.Interfaces;
using PDV.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;


namespace PDV.Dal.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public List<Cliente> RecuperarTodosClientes()
        {
           using(var ctx = new AppDataContext())
           {
               return  ctx.Usuarios.OfType<Cliente>().Where(x => x.SituacaoEntidade == Dominio.Enums.SituacaoEntidade.Ativo).ToList();
           }
        }

        public List<Usuario> RecuperTodos()
        {
            using (var ctx = new AppDataContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
