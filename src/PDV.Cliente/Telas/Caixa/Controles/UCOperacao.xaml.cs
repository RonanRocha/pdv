using Microsoft.Extensions.DependencyInjection;
using PDV.Cliente.ViewModels;
using Serilog;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PDV.Cliente.Telas.Caixa.Controles
{
    /// <summary>
    /// Interação lógica para UCOperacao.xam
    /// </summary>
    public partial class UCOperacao : UserControl
    {

        private OperacaoVendaViewModel _viewModel;
        private IServiceProvider _sp;

        public UCOperacao(OperacaoVendaViewModel viewModel, IServiceProvider sp)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _sp = sp;
            DataContext = viewModel;
        }


        private void IniciarVenda_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.IniciarVendaCommand.Execute(null);
            }
            catch (Exception ex)
            {
                Log.Error("Erro ao iniciar a venda");
                Log.Error(ex.Message);
            }

        }

        private void IniciaPagamento_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {

                var wfPagamento = _sp.GetRequiredService<WFPagamento>();
                wfPagamento.ShowDialog();


            }
            catch (Exception ex)
            {
                Log.Error("Erro ao inicia pagamentos");
                Log.Error(ex.Message);
            }
        }

        private void TxtBusca_OnKeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.Key == Key.Return)
                {
                    _viewModel.BuscarProdutoCommand.Execute(null);

                    if (_viewModel.Produtos.Count == 1)
                    {
                        _viewModel.Venda.AdicionarProduto(_viewModel.Produtos.FirstOrDefault(), _viewModel.Quantidade);
                        return;
                    }

                    var wfBuscaProdutos = _sp.GetRequiredService<WFBuscaProdutos>();
                    wfBuscaProdutos.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                Log.Error("Erro ao buscar produtos");
                Log.Error(ex.Message);
            }


        }


        private void DataRowGrid_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                VendaProdutoViewModel vendaProdutoVm = ((FrameworkElement)sender).DataContext as VendaProdutoViewModel;
                _viewModel.RemoverProdutoVendaCommand.Execute(vendaProdutoVm);
            }
            catch (Exception ex)
            {
                Log.Error("Erro ao remover produto da venda [datagrid]");
                Log.Error(ex.Message);
            }
        }


    }
}
