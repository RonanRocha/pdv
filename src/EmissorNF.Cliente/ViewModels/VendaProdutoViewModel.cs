using EmissorNF.Dominio.Enums;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;


namespace EmissorNF.Cliente.ViewModels
{
    public class VendaProdutoViewModel : ObservableObject
    {

        private int _id;
        private ProdutoViewModel _produto;
        private VendaViewModel _venda;
        private decimal _valorUnitario;
        private int _quantidade;
        private decimal _total;
        private decimal _subtotal;
        private decimal _valorDesconto;
        private decimal _valorAcrescimo;
        private DateTime _dataCadastro;


        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public ProdutoViewModel Produto
        {
            get => _produto;
            set => SetProperty(ref _produto, value);
        }

        public VendaViewModel Venda
        {
            get => _venda;
            set => SetProperty(ref _venda, value);
        }

        public decimal ValorUnitario
        {
            get => _valorUnitario;
            set => SetProperty(ref _valorUnitario, value);
        }

        public int Quantidade
        {
            get => _quantidade;
            set => SetProperty(ref _quantidade, value);
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

        public DateTime DataCadastro
        {
            get => _dataCadastro;
            set => SetProperty(ref _dataCadastro, value);
        }

        public SituacaoEntidade SituacaoEntidade { get; set; }

        public void Calcular()
        {
            Subtotal = Math.Round(ValorUnitario * Quantidade, 2);
            Total = Math.Round((ValorUnitario * Quantidade) - ValorDesconto + ValorAcrescimo, 2);

        }

        public void AplicarDesconto(decimal valor)
        {

            int count = 0;

            while(count < Quantidade)
            {
                ValorDesconto = Math.Round(valor * Quantidade  , 2);
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

        public void AdicionarProduto(ProdutoViewModel produto, int quantidade)
        {
            if (produto == null) return;

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

        public void Limpar()
        {
            ValorUnitario = 0;
            ValorDesconto = 0;
            Total = 0;
            Subtotal = 0;
            Produto = null;
            Quantidade = 0;

            Calcular();

        }



    }
}
