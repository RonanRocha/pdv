using PDV.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.Dominio.Entidades
{
    [Table("vendaformapagamento")]
    public class VendaFormaPagamento
    {
        public int Id { get; set; }
        public int FormaPagamentoId  { get; set; }
        public int VendaId { get; set; }
        public decimal ValorPago { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
        public Venda Venda { get; set; }
        public int? DivididoEm { get; set; }
        public SituacaoEntidade SituacaoEntidade { get; set; }
        public DateTime DataCadastro { get; set; }


        public void AdicionarPagamento(FormaPagamento formaPagamento, decimal valor, int parcelas = 1)
        {
            FormaPagamento = formaPagamento;
            ValorPago = valor;
            DivididoEm = parcelas;
        }


    }
}
