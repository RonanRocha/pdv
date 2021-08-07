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
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        public List<Produto> BuscarProduto(string busca)
        {
            using(var ctx = new AppDataContext())
            {
                return ctx.Produtos.Where(
                                           x => x.CodigoDeBarras.ToLower().Contains(busca.ToLower()) ||
                                           x.Codigo.ToLower().Contains(busca.ToLower()) ||
                                           x.Descricao.ToLower().Contains(busca.ToLower()) &&
                                           x.SituacaoEntidade == Dominio.Enums.SituacaoEntidade.Ativo).ToList();
            }
        }
    }
}
