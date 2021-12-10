using PDV.Dal.Contexto;
using PDV.Dal.Interfaces;
using PDV.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace PDV.Dal.Repositorios
{
    public class VendaFormaPagamentoRepositorio : IVendaFormaPagamentoRepositorio
    {
        private readonly AppDataContext _contexto;
        private bool _disposed = false;

        public VendaFormaPagamentoRepositorio(AppDataContext contexto)
        {
            _contexto = contexto;
        }

        ~VendaFormaPagamentoRepositorio() => Dispose();

        public void Dispose()
        {
            if(!_disposed)
            {
                _contexto.Dispose();
                GC.SuppressFinalize(this);
            }
           
        }

        public void Salvar(VendaFormaPagamento vendaFormaPagamento)
        {
            _contexto.Entry(vendaFormaPagamento).State = EntityState.Added;
        }

    }
}
