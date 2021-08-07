using EmissorNF.Dal.Contexto;
using EmissorNF.Dal.Interfaces;
using EmissorNF.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorNF.Dal.Repositorios
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
