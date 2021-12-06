﻿using AutoMapper;
using PDV.Cliente.Telas.Caixa;
using PDV.Dal.Interfaces;
using PDV.Dominio.Entidades;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using PDV.Cliente.Telas.Caixa.Controles;

namespace PDV.Cliente.ViewModels
{
    public class OperacaoVendaViewModel : ObservableObject
    {

        #region private attributes


        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScopeFactory _serviceScopeFactory;
      
        private string _busca = String.Empty;
        private bool _cpfNota;
        private bool _enviarEmail;
        private decimal _valorPagamento;
        private ParcelaViewModel _parcelaPagamento = GerarParcelaPadrao();
        private int _quantidade = 1;
        private Visibility _mostrarParcela = Visibility.Collapsed;
        private VendaViewModel _venda;
        private FormaPagamentoViewModel _pagamento;
        private ObservableCollection<ProdutoViewModel> _produtos = new ObservableCollection<ProdutoViewModel>();
        private ObservableCollection<FormaPagamentoViewModel> _pagamentos = new ObservableCollection<FormaPagamentoViewModel>();
        private ObservableCollection<ParcelaViewModel> _parcelas = new ObservableCollection<ParcelaViewModel>();

        #endregion

        #region actions
 
        public Action FecharJanelaPagamentoAction { get; set; }
        public Action FecharJanelaProdutosAction { get; set; }

        public Action FecharJanelaConclusaoVenda { get; set; }

        #endregion

        #region constructors
        public OperacaoVendaViewModel(
            IServiceProvider serviceProvider,
            IServiceScopeFactory serviceScopeFactory
  

        )
        {


            _serviceProvider = serviceProvider;
            _serviceScopeFactory = serviceScopeFactory;
            _venda = _serviceProvider.GetRequiredService<VendaViewModel>();

            
         
            FecharVendaCommand = new RelayCommand<Venda>((venda) => FecharVenda(venda));
            BuscarProdutoCommand = new RelayCommand(BuscarProduto, () => true);
            IniciarVendaCommand = new RelayCommand(IniciarOperacao, () => true);
            RemoverProdutoVendaCommand = new RelayCommand<VendaProdutoViewModel>((vendaProduto) => RemoverProdutoVenda(vendaProduto));
            ConsultarProdutosCommand = new RelayCommand(ConsultarProdutos, () => true);
            SelecionarProdutoCommand = new RelayCommand<ProdutoViewModel>((product) => SelecionarProduto(product));
            TrocarFormaPagamentoCommand = new RelayCommand(TrocarFormaPagamento, () => true);
            AdicionarPagamentoCommand = new RelayCommand(AdicionarPagamento, () => true);
            RemovePagamentoCommand = new RelayCommand<VendaFormaPagamentoViewModel>((pagamento) => RemoverPagamento(pagamento));
            AbrirJanelaPagamentoCommand = new RelayCommand(AbrirJanelaPagamentos, () => true);
            FecharJanelaPagamentoCommand = new RelayCommand(FecharJanelaPagamentos, () => true);
            FinalizarOperacaoCommand  = new RelayCommand(FinalizarOperacao, () => true);

            CarregarVendedores();
           
            
        }

        #endregion

        #region public attributes
        public bool CpfNota
        {
            get => _cpfNota;
            set => SetProperty(ref _cpfNota, value);
        }

        public bool EnviarEmail
        {
            get => _enviarEmail;
            set => SetProperty(ref _enviarEmail, value);
        }

        public decimal? Desconto
        {
            get => _venda.ValorDesconto;
            //set => SetProperty(ref _desconto, value);
            set => SetProperty(_venda.ValorDesconto, value, _venda, (v, d) => v.AplicarDesconto(d.GetValueOrDefault()));
        }

        public decimal? Acrescimo
        {
            get => _venda.ValorAcrescimo;
            set => SetProperty(_venda.ValorAcrescimo, value, _venda, (v, a) => v.AplicarAcrescimo(a.GetValueOrDefault()));
            //set => SetProperty(ref _acrescimo, value);
        }

        public decimal ValorPagamento
        {
            get => _valorPagamento;
            set => SetProperty(ref _valorPagamento, value);
        }

        public ParcelaViewModel ParcelaPagamento
        {
            get => _parcelaPagamento;
            set => SetProperty(ref _parcelaPagamento, value);
        }

        public int Quantidade
        {
            get => _quantidade;
            set => SetProperty(ref _quantidade, value);
        }

        public VendaViewModel Venda
        {
            get => _venda;
            set => SetProperty(ref _venda, value);
        }

        public UsuarioViewModel Vendedor
        {
            get => _venda.Usuario;
            set => SetProperty(_venda.Usuario, value, _venda, (v, u) => v.AdicionarUsuario(u));
        }

        public FormaPagamentoViewModel Pagamento
        {
            get => _pagamento;
            set => SetProperty(ref _pagamento, value);
        }

        public ClienteViewModel Cliente
        {
            get => _venda.Cliente;
            set => SetProperty(_venda.Cliente, value, _venda, (v, c) => v.AdicionarCliente(c));
        }

        public string Busca
        {
            get => _busca;
            set => SetProperty(ref _busca, value);
        }

        public Visibility MostrarParcela
        {
            get => _mostrarParcela;
            set => SetProperty(ref _mostrarParcela, value);
        }

        public ObservableCollection<UsuarioViewModel> Vendedores { get; set; } = new ObservableCollection<UsuarioViewModel>();

        public ObservableCollection<FormaPagamentoViewModel> Pagamentos
        {
            get => _pagamentos;
            set => SetProperty(ref _pagamentos, value);
        }

        public ObservableCollection<ProdutoViewModel> Produtos
        {
            get => _produtos;
            set => SetProperty(ref _produtos, value);
        }

        public ObservableCollection<ParcelaViewModel> Parcelas
        {
            get => _parcelas;
            set => SetProperty(ref _parcelas, value);
        }

        #endregion

        #region commands

        public ICommand FecharVendaCommand { get; set; }

        public ICommand BuscarProdutoCommand { get; set; }

        public ICommand IniciarVendaCommand { get; set; }

        public ICommand RemoverProdutoVendaCommand { get; set; }

        public ICommand ConsultarProdutosCommand { get; set; }

        public ICommand SelecionarProdutoCommand { get; set; }

        public ICommand TrocarFormaPagamentoCommand { get; set; }

        public ICommand AdicionarPagamentoCommand { get; set; }

        public ICommand RemovePagamentoCommand { get; set; }

        public ICommand AbrirJanelaPagamentoCommand { get; set; }

        public ICommand FecharJanelaPagamentoCommand { get; set; }

        public ICommand FinalizarOperacaoCommand { get; set; }


        #endregion

        #region methods

        public void AbrirJanelaPagamentos()
        {
            CarregarPagamentos();
            CalcularValorRestante();
        }

        public void FecharJanelaPagamentos()
        {
            LimparPagamentos();
        }

        public void RemoverProdutoVenda(VendaProdutoViewModel vendaProduto)
        {
            _venda.RemoverProduto(vendaProduto);
        }

        private void CarregarVendedores()
        {
            var mapper = _serviceProvider.GetRequiredService<IMapper>();

            var usuarioRepositorio = _serviceProvider.GetRequiredService<IUsuarioRepositorio>();

            var  usuarios = mapper.Map<List<Usuario>, List<UsuarioViewModel>>(usuarioRepositorio.RecuperTodos());

            Vendedores = new ObservableCollection<UsuarioViewModel>(usuarios);


        }

        private void CarregarPagamentos()
        {

            var mapper = _serviceProvider.GetRequiredService<IMapper>();

            var formaPagamentoRepositorio = _serviceProvider.GetRequiredService<IFormaPagamentoRepositorio>();

            var pagamentos = mapper.Map<List<FormaPagamento>, List<FormaPagamentoViewModel>>(formaPagamentoRepositorio.RecuperarTodas());

            Pagamentos = new ObservableCollection<FormaPagamentoViewModel>(pagamentos);
        
        }

        private void BuscarProduto()
        {

            ConsultarProdutosCommand.Execute(null);
   
        }

        private void SelecionarProduto(ProdutoViewModel produto)
        {
            AdicionarProduto(produto);
            FecharJanelaProdutosAction.Invoke();
        }

        private void  AdicionarProduto(ProdutoViewModel produto)
        {
            _venda.AdicionarProduto(produto, Quantidade);
        }

        private void AdicionarPagamento()
        {
            _venda.AdicionarFormaPagamento(Pagamento, ValorPagamento, ParcelaPagamento.Valor);
            CalcularValorRestante();
        }

        private void RemoverPagamento(VendaFormaPagamentoViewModel pagamento)
        {
            _venda.RemoverPagamento(pagamento);
            CalcularValorRestante();
        }

        private void ConsultarProdutos()
        {

            if (String.IsNullOrEmpty(Busca)) Busca = String.Empty;

            var mapper = _serviceProvider.GetRequiredService<IMapper>();

            var produtoRepositorio = _serviceProvider.GetRequiredService<IProdutoRepositorio>();

            var produtos = mapper.Map<List<Produto>, List<ProdutoViewModel>>(produtoRepositorio.BuscarProduto(Busca));

            Produtos = new ObservableCollection<ProdutoViewModel>(produtos);
            
        }

        private void FecharVenda(Venda venda)
        {

            var vendaRepositorio = _serviceProvider.GetRequiredService<IVendaRepositorio>();

            venda.DataFechamento = DateTime.Now;

            vendaRepositorio.Salvar(venda);


        }

        private void FinalizarOperacao()
        {
            
            FecharJanelaPagamentoAction.Invoke();
            IniciarOperacao();

        }



        private void IniciarOperacao()
        {
            IniciarVenda();                 
        }

        private void TrocarFormaPagamento()
        {
            if (Pagamento == null)
            {
                ParcelaPagamento = GerarParcelaPadrao();
                MostrarParcela = Visibility.Collapsed;
               
            }
            else
            {
                if (Pagamento.TipoPagamento == Dominio.Enums.TipoPagamento.Credito)
                {
                    Parcelas = new ObservableCollection<ParcelaViewModel>(ParcelaViewModel.GerarParcelas(Pagamento.Parcelas.GetValueOrDefault()));
                    ParcelaPagamento = Parcelas.FirstOrDefault();
                    MostrarParcela = Visibility.Visible;
                   
                }
                else
                {
                    ParcelaPagamento = GerarParcelaPadrao();
                    MostrarParcela = Visibility.Collapsed;
                    
                }
            }
        }

        private void CalcularValorRestante()
        {
           
            var pagamentos = Venda.Pagamentos.Sum(x => x.ValorPago);

            if(pagamentos >= Venda.Total)
            {
                ValorPagamento = 0M;

            }else
            {
                ValorPagamento = Venda.Total - pagamentos;
            }
        }

        private void LimparPagamentos()
        {
             Venda.Descricao = String.Empty;
             Pagamento = null;
             ValorPagamento = 0M;
             ParcelaPagamento.Valor = 1;
             Venda.Pagamentos = new ObservableCollection<VendaFormaPagamentoViewModel>();
        }

        private static ParcelaViewModel GerarParcelaPadrao()
        {
            var parcela = new ParcelaViewModel();
            parcela.Valor = 1;
            return parcela;
        }

        private void IniciarVenda()
        {

            var scopo = _serviceProvider.CreateScope();
            var novaOperacao = scopo.ServiceProvider.GetRequiredService<OperacaoVendaViewModel>();

           var ucOperacao = _serviceProvider.GetRequiredService<UCOperacao>();
           var wfProdutos = _serviceProvider.GetRequiredService<WFBuscaProdutos>();
           var wfPagamentos = _serviceProvider.GetRequiredService<WFPagamento>();


            ucOperacao.DataContext = novaOperacao;
            wfPagamentos.DataContext = novaOperacao;
            wfProdutos.DataContext = wfProdutos;
            
                
        }

        #endregion

    }
}
