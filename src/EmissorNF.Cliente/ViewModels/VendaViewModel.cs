using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorNF.Cliente.ViewModels
{
    public class VendaViewModel : ObservableObject
    {
        private int _id;
        private UsuarioViewModel _usuario;
        private ClienteViewModel _cliente;
        private decimal _total;
        private decimal _subtotal;
        private decimal _valorDesconto;
        private decimal _valorAcrescimo;
        private decimal _valorTroco;
        private decimal _valorPago;
        private DateTime _dataFechamento;
        private DateTime _dataCadastro;


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
            if ((valor <= 0 && valor >= Subtotal) && Produtos.ToList().Count == 0) return;

            var porcentagem = (valor * 100) / Subtotal;

            foreach (var produto in Produtos)
            {
                produto.AplicarDesconto(porcentagem);
            }

            CalcularTotais();
        }

        public void AplicarAcrescimo(decimal valor)
        {
            if ((valor <= 0 && valor >= Subtotal) && Produtos.ToList().Count == 0) return;

            var porcentagem = (valor * 100) / Subtotal;

            foreach (var produto in Produtos)
            {
                produto.AplicarAcrescimo(porcentagem);
            }

            CalcularTotais();
        }



        public void CalcularTotais()
        {
            Total = Produtos.Sum(x => x.Total);
            Subtotal = Produtos.Sum(x => x.Subtotal);
            ValorDesconto = Produtos.Sum(x => x.ValorDesconto);
            ValorAcrescimo = Produtos.Sum(x => x.ValorAcrescimo);
            ValorPago = Pagamentos.Sum(x => x.ValorPago);
            ValorTroco = ValorPago <= Total ? 0 : ValorPago - Total;

           
        }


        public void RemoverProduto(VendaProdutoViewModel vendaProdutoVm)
        {
            var produto = Produtos.Where(x => x.Id == vendaProdutoVm.Id).FirstOrDefault();
            if (produto == null) return;
            Produtos.Remove(produto);
            CalcularTotais();
        }

        public void AdicionarProduto(ProdutoViewModel produto, int quantidade)
        {
            if (produto == null) return;

            if (quantidade <= 0) return;

     

            var produtoAdicionado = Produtos.Where(x => x.Produto.Id == produto.Id).FirstOrDefault();
           
            if(produtoAdicionado != null)
            {
                produtoAdicionado.Incrementar(quantidade);

            }
            else
            {

                var vendaProduto = new VendaProdutoViewModel
                {

                    DataCadastro = DateTime.Now,
                    Venda = this
                };

                vendaProduto.AdicionarProduto(produto, quantidade);

                Produtos.Add(vendaProduto);
            }

          

            CalcularTotais();

        }

        public void AdicionarFormaPagamento(FormaPagamentoViewModel formaPagamento, decimal valor, int parcelas = 1)
        {
            if (formaPagamento == null) return;


            if (valor <= 0) return;

            var vendaFormaPagamento = new VendaFormaPagamentoViewModel
            {

                DataCadastro = DateTime.Now,
                Venda = this
            };

            vendaFormaPagamento.AdicionarPagamento(formaPagamento, valor, parcelas);

            Pagamentos.Add(vendaFormaPagamento);

            CalcularTotais();

        }



    }
}
