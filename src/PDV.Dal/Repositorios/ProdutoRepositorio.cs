using PDV.Dal.Contexto;
using PDV.Dal.Interfaces;
using PDV.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;


namespace PDV.Dal.Repositorios
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
