using EmissorNF.Dominio.Enums;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;


namespace EmissorNF.Cliente.ViewModels
{
    public class GrupoProdutoViewModel : ObservableObject
    {

        private int _id;
        private string _descricao;
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

        public DateTime DataCadastro
        {
            get => _dataCadastro;
            set => SetProperty(ref _dataCadastro, value);
        }

        public SituacaoEntidade SituacaoEntidade { get; set; }
    }
}
