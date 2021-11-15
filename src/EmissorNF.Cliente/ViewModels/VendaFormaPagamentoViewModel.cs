using EmissorNF.Dominio.Enums;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;


namespace EmissorNF.Cliente.ViewModels
{
    public class VendaFormaPagamentoViewModel : ObservableObject
    {
        private int _id;
        private FormaPagamentoViewModel _formaPagamento;
        private VendaViewModel _venda;
        private decimal _valorPago;
        private int? _dividoEm;
        private DateTime _dataCadastro;


        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public FormaPagamentoViewModel FormaPagamento
        {
            get => _formaPagamento;
            set => SetProperty(ref _formaPagamento, value);
        }

        public VendaViewModel Venda
        {
            get => _venda;
            set => SetProperty(ref _venda, value);
        }

        public decimal ValorPago
        {
            get => _valorPago;
            set => SetProperty(ref _valorPago, value);
        }

        public int? DivididoEm
        {
            get => _dividoEm;
            set => SetProperty(ref _dividoEm, value);
        }

        public DateTime DataCadastro
        {
            get => _dataCadastro;
            set => SetProperty(ref _dataCadastro, value);
        }

        public SituacaoEntidade SituacaoEntidade { get; set; }

        public void AdicionarPagamento(FormaPagamentoViewModel formaPagamento, decimal valor, int parcelas = 1)
        {
            FormaPagamento = formaPagamento;
            ValorPago = valor;
            DivididoEm = parcelas;
        }

        public void IncrementarValor(decimal valor)
        {
            ValorPago += valor;
        }

    }
}
