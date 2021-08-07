using EmissorNF.Dominio.Enums;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorNF.Cliente.ViewModels
{
    public class FormaPagamentoViewModel : ObservableObject
    {

        private int _id;
        private string _descricao;
        private string _codigo;
        private int? _parcelas;
        private DateTime _dataCadastro;


        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Descricao
        {
            get => _descricao;
            set => SetProperty(ref _descricao, value);
        }

        public string Codigo
        {
            get => _codigo;
            set => SetProperty(ref _codigo, value);
        }

        public int? Parcelas
        {
            get => _parcelas;
            set => SetProperty(ref _parcelas, value);
        }

        public DateTime DataCadastro
        {
            get => _dataCadastro;
            set => SetProperty(ref _dataCadastro, value);
        }

        public TipoPagamento TipoPagamento { get; set; }

        public SituacaoEntidade SituacaoEntidade { get; set; }

    }
}
