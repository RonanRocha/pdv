using PDV.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace PDV.Dal.Interfaces
{
    public  interface IProdutoRepositorio : IDisposable
    {
        public List<Produto> BuscarProduto(string busca);
    }
}
