using Microsoft.EntityFrameworkCore;
using PDV.Dal.Contexto;
using PDV.Dal.Interfaces;
using PDV.Dominio.Entidades;

namespace PDV.Dal.Repositorios
{
    public class VendaProdutoRepositorio : IVendaProdutoRepositorio
    {

        private readonly AppDataContext _contexto;

        public VendaProdutoRepositorio(AppDataContext contexto)
        {
            _contexto = contexto;
        }

        public void Salvar(VendaProduto vendaProduto)
        {
            _contexto.Entry(vendaProduto).State = EntityState.Added;
        }
    }
}
