using PDV.Dominio.Enums;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;


namespace PDV.Cliente.ViewModels
{
    public class VendaViewModel : ObservableObject
    {
        private int _id;
        private UsuarioViewModel _usuario;
        private ClienteViewModel _cliente;
        private string _descricao;
        private decimal _total;
        private decimal _subtotal;
        private decimal _valorDesconto;
        private decimal _valorAcrescimo;
        private decimal _valorTroco;
        private decimal _valorPago;
        private DateTime _dataFechamento;
        private DateTime _dataCadastro;


        public VendaViewModel()
        {
            SituacaoEntidade = SituacaoEntidade.Ativo;
            DataCadastro = DateTime.Now;
        }
        
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public UsuarioViewModel Usuario
        {
            get => _usuario;
            set => SetProperty(ref _usuario, value);
        }

        public ClienteViewModel Cliente
        {
            get => _cliente;
            set => SetProperty(ref _cliente, value);
        }

        public string Descricao
        {
            get => _descricao;
            set => SetProperty(ref _descricao, value);
        }

        public decimal Total
        {
            get => _total;
            set => SetProperty(ref _total, value);
        }

        public decimal Subtotal
        {
            get => _subtotal;
            set => SetProperty(ref _subtotal, value);
        }

        public decimal ValorDesconto
        {
            get => _valorDesconto;
            set => SetProperty(ref _valorDesconto, value);
        }

        public decimal ValorAcrescimo
        {
            get => _valorAcrescimo;
            set => SetProperty(ref _valorAcrescimo, value);
        }

        public decimal ValorTroco
        {
            get => _valorTroco;
            set => SetProperty(ref _valorTroco, value);
        }

        public decimal ValorPago
        {
            get => _valorPago;
            set => SetProperty(ref _valorPago, value);
        }

        public DateTime DataCadastro
        {
            get => _dataCadastro;
            set => SetProperty(ref _dataCadastro, value);
        }

        public DateTime DataFechamento
        {
            get => _dataFechamento;
            set => SetProperty(ref _dataFechamento, value);
        }

        public SituacaoEntidade  SituacaoEntidade { get; set; }


        public ObservableCollection<VendaProdutoViewModel> Produtos { get; set; } = new ObservableCollection<VendaProdutoViewModel>();
        public ObservableCollection<VendaFormaPagamentoViewModel> Pagamentos { get; set; } = new ObservableCollection<VendaFormaPagamentoViewModel>();


        public void AdicionarUsuario(UsuarioViewModel usuario)
        {
            Usuario = usuario;
        }

        public void AdicionarCliente(ClienteViewModel cliente)
        {
            Cliente = cliente;
        }

        public void AplicarDesconto(decimal valor)
        {

            var valorRateio = CalcularRateio(valor);

            foreach (var produto in Produtos)
            {              
                produto.AplicarDesconto(valorRateio);
            }

            CalcularTotais();
        }

        public void AplicarAcrescimo(decimal valor)
        {

            var valorRateio = CalcularRateio(valor);

            foreach (var produto in Produtos)
            {
                produto.AplicarAcrescimo(valorRateio);
            }

            CalcularTotais();
        }

        private decimal CalcularRateio(decimal valor)
        {
            var quantidadeProdutos = Produtos.Sum(x => x.Quantidade);

            if ((valor <= 0 && valor >= Subtotal)) return 0;

            if (quantidadeProdutos == 0) return 0;

            return valor / quantidadeProdutos;

        }

        public void CalcularTotais()
        {
            
            Total = Math.Round(Produtos.Sum(x => x.Total), 2);
            Subtotal = Math.Round(Produtos.Sum(x => x.Subtotal), 2);
            ValorDesconto = Math.Round(Produtos.Sum(x => x.ValorDesconto), 2);
            ValorAcrescimo = Math.Round(Produtos.Sum(x => x.ValorAcrescimo),2);
            ValorPago = Math.Round(Pagamentos.Sum(x => x.ValorPago), 2);
            ValorTroco = ValorPago <= Total ? 0 : Math.Round(ValorPago - Total, 2);

           
        }

        public void RemoverProduto(VendaProdutoViewModel vendaProdutoVm)
        {
            var produto = Produtos.Where(x => x.Produto.Id == vendaProdutoVm.Produto.Id).FirstOrDefault();
            if (produto == null) return;
            Produtos.Remove(produto);
            AplicarDesconto(ValorDesconto);
            AplicarAcrescimo(ValorAcrescimo);
        }

        public void AdicionarProduto(ProdutoViewModel produto, int quantidade)
        {
            if (produto == null) return;

            if (quantidade <= 0) return;

            var produtoAdicionado = Produtos.Where(x => x.Produto.Id == produto.Id).FirstOrDefault();
           
            if (produtoAdicionado != null)
            {
                produtoAdicionado.Incrementar(quantidade);
            }
            else
            {

                var vendaProduto = new VendaProdutoViewModel
                {

                    DataCadastro = DateTime.Now,
                    SituacaoEntidade = SituacaoEntidade.Ativo,
                    Venda = this
                };

                vendaProduto.AdicionarProduto(produto, quantidade);
                

                Produtos.Add(vendaProduto);
            }


            AplicarAcrescimo(ValorAcrescimo);
            AplicarDesconto(ValorDesconto);

        }

        public void AdicionarFormaPagamento(FormaPagamentoViewModel formaPagamento, decimal valor, int parcelas = 1)
        {
            if (formaPagamento == null) return;

            if (valor <= 0) return;

            var pagamentoAdicionado = Pagamentos.Where(x => x.FormaPagamento.Id == formaPagamento.Id && x.DivididoEm == parcelas).FirstOrDefault();

            if(pagamentoAdicionado != null)
            {
                pagamentoAdicionado.IncrementarValor(valor);
            }
            else
            {
                var vendaFormaPagamento = new VendaFormaPagamentoViewModel
                {

                    DataCadastro = DateTime.Now,
                    SituacaoEntidade = SituacaoEntidade.Ativo,
                    Venda = this
                };

                vendaFormaPagamento.AdicionarPagamento(formaPagamento, valor, parcelas);

                Pagamentos.Add(vendaFormaPagamento);
            }


            CalcularTotais();

        }

        public void RemoverPagamento(VendaFormaPagamentoViewModel pagamentoViewModel)
        {
            var produto = Pagamentos.Where(x => x.Id == pagamentoViewModel.Id).FirstOrDefault();
            if (produto == null) return;
            Pagamentos.Remove(produto);
            CalcularTotais();
        }

    }
}
