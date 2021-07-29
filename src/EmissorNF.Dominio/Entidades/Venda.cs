using EmissorNF.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorNF.Dominio.Entidades
{
    public class Venda
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Total { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorAcrescimo { get; set; }
        public decimal ValorTroco { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime? DataFechamento { get; set; }
        public SituacaoEntidade SituacaoEntidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public  List<VendaProduto> Produtos { get; set; }
        public List<VendaFormaPagamento> Pagamentos { get; set; }


        public Venda()
        {
            Produtos = new List<VendaProduto>();
            Pagamentos = new List<VendaFormaPagamento>();
        }

        public void AplicarDesconto(decimal valor)
        {
            if ((valor <= 0 && valor >= Subtotal) && Produtos.Where(x => x.SituacaoEntidade == SituacaoEntidade.Ativo).ToList().Count == 0 ) return ;

            var porcentagem = (valor * 100) / Subtotal;
           
            foreach(var produto in Produtos.Where(x => x.SituacaoEntidade == SituacaoEntidade.Ativo))
            {
                produto.AplicarDesconto(porcentagem);
            }

            CalcularTotais();
        }

        public void AplicarAcrescimo(decimal valor)
        {
            if ((valor <= 0 && valor >= Subtotal) && Produtos.Where(x => x.SituacaoEntidade == SituacaoEntidade.Ativo).ToList().Count == 0) return;

            var porcentagem = (valor * 100) / Subtotal;

            foreach (var produto in Produtos.Where(x => x.SituacaoEntidade == SituacaoEntidade.Ativo))
            {
                produto.AplicarAcrescimo(porcentagem);
            }

            CalcularTotais();
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            if (usuario == null) return;

            if (usuario.SituacaoEntidade == SituacaoEntidade.Inativo) return;

            Usuario = usuario;
        }

        public void AdicionarCliente(Cliente cliente)
        {
            if (cliente == null) return;

            if (cliente.SituacaoEntidade == SituacaoEntidade.Inativo) return;

            Cliente = cliente;
           
        }

        public void CalcularTotais()
        {
            Total = Produtos.Where(x => x.SituacaoEntidade == SituacaoEntidade.Ativo).Sum(x => x.Total);
            Subtotal = Produtos.Where(x => x.SituacaoEntidade == SituacaoEntidade.Ativo).Sum(x => x.Subtotal);
            ValorDesconto = Produtos.Where(x => x.SituacaoEntidade == SituacaoEntidade.Ativo).Sum(x => x.ValorDesconto);
            ValorAcrescimo = Produtos.Where(x => x.SituacaoEntidade == SituacaoEntidade.Ativo).Sum(x => x.ValorAcrescimo);
            ValorPago = Pagamentos.Where(x => x.SituacaoEntidade == SituacaoEntidade.Ativo).Sum(x => x.ValorPago);
            ValorTroco = ValorPago <= Total ? 0 : ValorPago - Total;
        }

        public void AdicionarProduto(Produto produto, int quantidade)
        {
            if (produto == null) return;

            if (produto.SituacaoEntidade == SituacaoEntidade.Inativo) return;

            if (quantidade <= 0) return;

            var vendaProduto = new VendaProduto { 
       
                SituacaoEntidade = SituacaoEntidade.Ativo,
                DataCadastro = DateTime.Now,
                Venda = this
            };

            vendaProduto.AdicionarProduto(produto,quantidade);

            Produtos.Add(vendaProduto);

            CalcularTotais();
           
        }

        public void AdicionarFormaPagamento(FormaPagamento formaPagamento, decimal valor, int parcelas = 1)
        {
            if (formaPagamento == null) return;

            if (formaPagamento.SituacaoEntidade == SituacaoEntidade.Inativo) return;

            if (valor <= 0) return;

            var vendaFormaPagamento = new VendaFormaPagamento { 
           
                DataCadastro = DateTime.Now,
                SituacaoEntidade = SituacaoEntidade.Ativo,
                Venda = this                   
            };

            vendaFormaPagamento.AdicionarPagamento(formaPagamento, valor, parcelas);

            Pagamentos.Add(vendaFormaPagamento);

            CalcularTotais();
            
        }



    }
}
