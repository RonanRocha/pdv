using EmissorNF.Dominio.Entidades;
using System.Collections.Generic;

namespace EmissorNF.Dal.Interfaces
{
    public  interface IProdutoRepositorio
    {
        public List<Produto> BuscarProduto(string busca);
    }
}
