using PDV.Dominio.Entidades;
using System.Collections.Generic;

namespace PDV.Dal.Interfaces
{
    public  interface IProdutoRepositorio
    {
        public List<Produto> BuscarProduto(string busca);
    }
}
