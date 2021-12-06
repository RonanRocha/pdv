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

        private IServiceProvider _sp;

        public UCOperacao(OperacaoVendaViewModel viewModel, IServiceProvider sp)
        {
            InitializeComponent();
            _sp = sp;
            DataContext = _sp.GetRequiredService<OperacaoVendaViewModel>();
        }


        private void IniciarVenda_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var viewModel = (OperacaoVendaViewModel)DataContext;
                viewModel.IniciarVendaCommand.Execute(null);
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
                var viewModel = (OperacaoVendaViewModel)DataContext;
                var wfPagamento = _sp.GetRequiredService<WFPagamento>();
                wfPagamento.BindContext(viewModel);
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
                var viewModel = (OperacaoVendaViewModel)DataContext;

                if (e.Key == Key.Return)
                {
                    viewModel.BuscarProdutoCommand.Execute(null);

                    if (viewModel.Produtos.Count == 1)
                    {
                        viewModel.Venda.AdicionarProduto(viewModel.Produtos.FirstOrDefault(), viewModel.Quantidade);
                        return;
                    }

                    var wfBuscaProdutos = _sp.GetRequiredService<WFBuscaProdutos>();
                    wfBuscaProdutos.BindContext(viewModel);
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
                var viewModel = (OperacaoVendaViewModel)DataContext;

                VendaProdutoViewModel vendaProdutoVm = ((FrameworkElement)sender).DataContext as VendaProdutoViewModel;

                viewModel.RemoverProdutoVendaCommand.Execute(vendaProdutoVm);
            }
            catch (Exception ex)
            {
                Log.Error("Erro ao remover produto da venda [datagrid]");
                Log.Error(ex.Message);
            }
        }


    }
}
