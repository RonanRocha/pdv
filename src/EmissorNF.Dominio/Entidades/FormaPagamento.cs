using PDV.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.Dominio.Entidades
{
    [Table("formapagamento")]
    public class FormaPagamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public int? Parcelas { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public List<VendaFormaPagamento> Vendas { get; set; }
        public SituacaoEntidade SituacaoEntidade { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
