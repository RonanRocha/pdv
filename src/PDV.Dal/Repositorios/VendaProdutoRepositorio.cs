using Microsoft.EntityFrameworkCore;
using PDV.Dal.Contexto;
using PDV.Dal.Interfaces;
using PDV.Dominio.Entidades;
using System;

namespace PDV.Dal.Repositorios
{
    public class VendaProdutoRepositorio : IVendaProdutoRepositorio
    {

        private readonly AppDataContext _contexto;
        private bool _disposed = false;

        public VendaProdutoRepositorio(AppDataContext contexto)
        {
            _contexto = contexto;
        }

        public void Salvar(VendaProduto vendaProduto)
        {
            _contexto.Entry(vendaProduto).State = EntityState.Added;
        }

        ~VendaProdutoRepositorio() => Dispose();

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
