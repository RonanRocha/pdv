using PDV.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.Dominio.Entidades
{
    [Table("vendaproduto")]
    public class VendaProduto
    {
        public int Id { get; set; }

        public int ProdutoId  { get; set; }

        public int VendaId { get; set; }

        public decimal ValorUnitario { get; set; }

        public int Quantidade { get; set; }

        public decimal  Total { get; set; }

        public decimal Subtotal { get; set; }

        public decimal ValorDesconto { get; set; }

        public decimal ValorAcrescimo { get; set; }

        public SituacaoEntidade SituacaoEntidade { get; set; }

        public DateTime DataCadastro { get; set; }

        public Produto Produto { get; set; }

        public Venda Venda { get; set; }

        public void Calcular()
        {
            Subtotal = ValorUnitario * Quantidade;
            Total = (ValorUnitario * Quantidade) - ValorDesconto + ValorAcrescimo;

        }

        public void AplicarDesconto(decimal valor)
        {

            int count = 0;

            while (count < Quantidade)
            {
                ValorDesconto = Math.Round(valor * Quantidade, 2);
                Calcular();
                count++;
            }

   
        }

        public void AplicarAcrescimo(decimal valor)
        {
            int count = 0;

            while (count < Quantidade)
            {
                ValorAcrescimo = Math.Round(valor * Quantidade, 2);
                Calcular();
                count++;
            }
        }

        public void AdicionarProduto(Produto produto, int quantidade)
        {
            if (produto == null) return;

            if (produto.SituacaoEntidade == SituacaoEntidade.Inativo) return;

            if (String.IsNullOrEmpty(produto.Descricao)) return;

            if (produto.ValorVenda <= 0) return;

            Produto = produto;
            ValorUnitario = produto.ValorVenda;
            Quantidade = quantidade;

            Calcular();
        }

        public void Incrementar(int quantidade)
        {
            Quantidade += quantidade;
            Calcular();
        }


    }
}
