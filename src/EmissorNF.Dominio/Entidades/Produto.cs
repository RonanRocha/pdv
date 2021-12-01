using PDV.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.Dominio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }

        public int GrupoProdutoId { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public string CodigoDeBarras { get; set; }

        public decimal? ValorCompra { get; set; }

        public decimal ValorVenda { get; set; }

        public string Ncm { get; set; }

        public string Cest { get; set; }

        public SituacaoEntidade SituacaoEntidade { get; set; }

        public DateTime DataCadastro { get; set; }

        public GrupoProduto GrupoProduto { get; set; }

        public List<VendaProduto> Vendas { get; set; }
    }
}
