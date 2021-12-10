using PDV.Dal.Contexto;
using PDV.Dal.Interfaces;
using PDV.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace PDV.Dal.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {

        private readonly AppDataContext _contexto;
        private bool _disposed = false;

        public ProdutoRepositorio(AppDataContext contexto)
        {
            _contexto = contexto;
        }

        public List<Produto> BuscarProduto(string busca)
        {

                return _contexto.Produtos.Where(
                                           x => x.CodigoDeBarras.ToLower().Contains(busca.ToLower()) ||
                                           x.Codigo.ToLower().Contains(busca.ToLower()) ||
                                           x.Descricao.ToLower().Contains(busca.ToLower()) &&
                                           x.SituacaoEntidade == Dominio.Enums.SituacaoEntidade.Ativo).ToList();
            
        }

        ~ProdutoRepositorio() => Dispose();

        public void Dispose()
        {
            if (!_disposed)
            {
                _contexto.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
