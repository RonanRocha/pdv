using PDV.Dal.Contexto;
using PDV.Dal.Interfaces;
using PDV.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace PDV.Dal.Repositorios
{
    public class FormaPagamentoRepositorio : IFormaPagamentoRepositorio
    {
        private readonly AppDataContext _contexto;
        private bool _disposed = false;

        public FormaPagamentoRepositorio(AppDataContext contexto)
        {
            _contexto = contexto;
        }

        ~FormaPagamentoRepositorio() => Dispose();

        public void Dispose()
        {
            if (!_disposed)
            {
                _contexto.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        public List<FormaPagamento> RecuperarTodas()
        {

            return _contexto.FormaPagamentos.Where(x => x.SituacaoEntidade == Dominio.Enums.SituacaoEntidade.Ativo).ToList();
            
        }
    }
}
