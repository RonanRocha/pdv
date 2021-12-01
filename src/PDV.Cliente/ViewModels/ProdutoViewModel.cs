using PDV.Dominio.Enums;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;


namespace PDV.Cliente.ViewModels
{
    public class ProdutoViewModel : ObservableObject
    {

        private int _id;
        private GrupoProdutoViewModel _grupoProduto;
        private string _codigo;
        private string _descricao;
        private string _codigoDeBarras;
        private decimal? _valorCompra;
        private decimal _valorVenda;
        private string _ncm;
        private string _cest;
        private DateTime _dataCadastro;


        public int Id
        {
            get => _id;
            set => SetProperty(ref _id , value);
        }

        public GrupoProdutoViewModel GrupoProduto
        {
            get => _grupoProduto;
            set => SetProperty(ref _grupoProduto, value);
        }


        public string Codigo
        {
            get => _codigo;
            set => SetProperty(ref _codigo, value);
        }


        public string Descricao
        {
            get => _descricao;
            set => SetProperty(ref _descricao, value);
        }

        public string CodigoDeBarras
        {
            get => _codigoDeBarras;
            set => SetProperty(ref _codigoDeBarras, value);
        }

        public decimal? ValorCompra
        {
            get => _valorCompra;
            set => SetProperty(ref _valorCompra, value);
        }

        public decimal ValorVenda
        {
            get => _valorVenda;
            set => SetProperty(ref _valorVenda, value);
        }


        public string Ncm
        {
            get => _ncm;
            set => SetProperty(ref _ncm, value);
        }

        public string Cest
        {
            get => _cest;
            set => SetProperty(ref _cest, value);
        }

        public DateTime DataCadastro
        {
            get => _dataCadastro;
            set => SetProperty(ref _dataCadastro, value);
        }

        public SituacaoEntidade SituacaoEntidade { get; set; }

    }
}