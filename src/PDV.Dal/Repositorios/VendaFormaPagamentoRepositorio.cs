using PDV.Dal.Contexto;
using PDV.Dal.Interfaces;
using PDV.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PDV.Dal.Repositorios
{
    public class VendaFormaPagamentoRepositorio : IVendaFormaPagamentoRepositorio
    {
        private readonly AppDataContext _contexto;

        public VendaFormaPagamentoRepositorio(AppDataContext contexto)
        {
            _contexto = contexto;
        }

        public void Salvar(VendaFormaPagamento vendaFormaPagamento)
        {

            _contexto.Entry(vendaFormaPagamento).State = EntityState.Added;

        }

        public void SalvarLista(List<VendaFormaPagamento> listaFormaPagamento)
        {
            _contexto.Entry<List<VendaFormaPagamento>>(listaFormaPagamento).State = EntityState.Added;
        }
    }
}
