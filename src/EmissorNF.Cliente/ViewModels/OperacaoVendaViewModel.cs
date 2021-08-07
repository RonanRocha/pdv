using AutoMapper;
using EmissorNF.Cliente.Telas.Caixa;
using EmissorNF.Dal.Interfaces;
using EmissorNF.Dominio.Entidades;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmissorNF.Cliente.ViewModels
{
    public class OperacaoVendaViewModel : ObservableObject
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IFormaPagamentoRepositorio _formaPagamentoRepositorio;
        private readonly IServiceProvider _sp;  
        private readonly IMapper _mapper;

        private  VendaViewModel _venda;
        private string _busca = String.Empty;
        private bool _cpfNota;
        private bool _enviarEmail;
        private decimal? _desconto;
        private decimal? _acrescimo;
        private int _quantidade = 1;
        private FormaPagamentoViewModel _pagamento;
        private ObservableCollection<ProdutoViewModel> _produtos = new ObservableCollection<ProdutoViewModel>();
        private ObservableCollection<FormaPagamentoViewModel> _pagamentos = new ObservableCollection<FormaPagamentoViewModel>();


        public event EventHandler IniciarVenda;
        public event EventHandler FecharJanelaPagamentos;
        public event EventHandler FecharJanelaProdutos;


        public OperacaoVendaViewModel(IProdutoRepositorio produtoRepositorio,IServiceProvider sp, IFormaPagamentoRepositorio formaPagamentoRepositorio, IUsuarioRepositorio usuarioRepositorio, IMapper mapper, VendaViewModel viewModel)
        {

            _venda = viewModel;
            this._sp = sp;
            this._mapper = mapper;
            this._produtoRepositorio = produtoRepositorio;
            this._usuarioRepositorio = usuarioRepositorio;
            this._formaPagamentoRepositorio = formaPagamentoRepositorio;

           
            FecharVendaCommand = new RelayCommand(FecharVenda, () => true);
            BuscarProdutoCommand = new RelayCommand(BuscarProduto, () => true);
            IniciarVendaCommand = new RelayCommand(IniciarOperacao, () => true);
            IniciarPagamentosCommand = new RelayCommand(IniciarPagamentos, () => true);
            RemoverProdutoVendaCommand = new RelayCommand<VendaProdutoViewModel>((vendaProduto) => RemoverProdutoVenda(vendaProduto));
            ConsultarProdutosCommand = new RelayCommand(ConsultarProdutos, () => true);
            SelecionarProdutoCommand = new RelayCommand<ProdutoViewModel>((product) => SelecionarProduto(product));

            CarregarVendedores();
            CarregarPagamentos();
        }

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
            get => _desconto;
            set => SetProperty(ref _desconto, value);
        }

        public decimal? Acrescimo
        {
            get => _acrescimo;
            set => SetProperty(ref _acrescimo, value);
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
       

        public ICommand FecharVendaCommand { get; set; }

        public ICommand BuscarProdutoCommand { get; set; }

        public ICommand IniciarVendaCommand { get; set; }

        public ICommand IniciarPagamentosCommand { get; set; }

        public ICommand RemoverProdutoVendaCommand { get; set; }

        public ICommand ConsultarProdutosCommand { get; set; }

        public ICommand SelecionarProdutoCommand { get; set; }

        public void RemoverProdutoVenda(VendaProdutoViewModel vendaProduto)
        {
            _venda.RemoverProduto(vendaProduto);
        }

        private void CarregarVendedores()
        {

            var  usuarios = _mapper.Map<List<Usuario>, List<UsuarioViewModel>>(_usuarioRepositorio.RecuperTodos());

            foreach(var usuario in usuarios)
            {
                Vendedores.Add(usuario);
            }

        }

        private void CarregarPagamentos()
        {

            var pagamentos = _mapper.Map<List<FormaPagamento>, List<FormaPagamentoViewModel>>(_formaPagamentoRepositorio.RecuperarTodas());

            foreach (var pagamento in pagamentos)
            {
                Pagamentos.Add(pagamento);
            }

        }

        private void BuscarProduto()
        {

            ConsultarProdutosCommand.Execute(null);

            if(Produtos.Count  == 1)
            {
                AdicionarProduto(Produtos.FirstOrDefault());
               
            }else
            {
                
                var wfBuscaProdutos = _sp.GetRequiredService<WFBuscaProdutos>();
                wfBuscaProdutos.ShowDialog();
               
               
            }
   
        }

        private void SelecionarProduto(ProdutoViewModel produto)
        {
            AdicionarProduto(produto);
            FecharJanelaProdutos.Invoke(this, EventArgs.Empty);
        }

        private void  AdicionarProduto(ProdutoViewModel produto)
        {
            _venda.AdicionarProduto(produto, Quantidade);
        }

        private void ConsultarProdutos()
        {

            if (String.IsNullOrEmpty(Busca)) Busca = String.Empty;

            var produtos = _mapper.Map<List<Produto>, List<ProdutoViewModel>>(_produtoRepositorio.BuscarProduto(Busca));

            Produtos = new ObservableCollection<ProdutoViewModel>(produtos);
            
        }

        private void FecharVenda()
        {
            IniciarVenda.Invoke(this, EventArgs.Empty);
            FecharJanelaPagamentos.Invoke(this, EventArgs.Empty);
        }


        private void IniciarPagamentos()
        {
            var wfPagamento = _sp.GetRequiredService<WFPagamento>();
            wfPagamento.ShowDialog();
        }

        private void IniciarOperacao()
        {
            IniciarVenda.Invoke(this, EventArgs.Empty);
            
        }
      
    }
}
