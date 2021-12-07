using Microsoft.Extensions.DependencyInjection;
using PDV.Cliente.ViewModels;
using Serilog;
using System;
using System.Windows;
using System.Windows.Input;

namespace PDV.Cliente.Telas.Caixa
{
    /// <summary>
    /// Lógica interna para WFBuscaProdutos.xaml
    /// </summary>
    public partial class WFBuscaProdutos : Window
    {

      
        public WFBuscaProdutos(OperacaoVendaViewModel viewModel)
        {
            InitializeComponent();

            DefinirContexto(viewModel);
            
            winActions.ButtonMaximize.Visibility = Visibility.Collapsed;
            winActions.ButtonMaximize.Click += WindowMaximize;
            winActions.ButtonMinimize.Click += WindowMinimize;
            winActions.ButtonClose.Click += WindowClose;
        }


        public void DefinirContexto(OperacaoVendaViewModel context)
        {
            context.FecharJanelaProdutosAction = new Action(this.Close);
            DataContext = context;
        }

        private void WindowMinimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        public void WindowClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowMaximize(object sender, RoutedEventArgs e)
        {

            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                return;
            }

            this.WindowState = WindowState.Maximized;
        }


        private void DatagridRow_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            try
            {
                var viewModel = (OperacaoVendaViewModel)DataContext;

                var produtoVm = ((FrameworkElement)sender).DataContext as ProdutoViewModel;

                viewModel.SelecionarProdutoCommand.Execute(produtoVm);

            }
            catch(Exception ex)
            {
                Log.Error("Erro no double click row [produtos]");
                Log.Error(ex.Message);
            }
 
        }

        private void TxtPesquisar_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Pesquisar();
            }
        }


        private void Pesquisar_OnClick(object sender, RoutedEventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            try
            {
                var viewModel = (OperacaoVendaViewModel)DataContext;

                viewModel.ConsultarProdutosCommand.Execute(null);

            }
            catch (Exception ex)
            {
                Log.Error("Erro no botão de pesquisar");
                Log.Error(ex.Message);
            }
        }

        private void DatagridRow_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                var viewModel = (OperacaoVendaViewModel)DataContext;

                if (e.Key == Key.Return)
                {
                    var  produtoVm = ((FrameworkElement)sender).DataContext as ProdutoViewModel;

                    viewModel.SelecionarProdutoCommand.Execute(produtoVm);
                }

            }
            catch (Exception ex)
            {
                Log.Error("Erro no enter  row [produtos]");
                Log.Error(ex.Message);
            }
      
        }

    }

}
