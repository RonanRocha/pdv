using PDV.Cliente.ViewModels;
using Serilog;
using System;
using System.Windows;


namespace PDV.Cliente.Telas.Caixa
{
    /// <summary>
    /// Lógica interna para WFPagamento.xaml
    /// </summary>
    public partial class WFPagamento : Window
    {

        private OperacaoVendaViewModel _viewModel;

        public WFPagamento(OperacaoVendaViewModel viewModel)
        {

            InitializeComponent();
            viewModel.FecharJanelaPagamentoAction = new Action(this.Close);
            DataContext = viewModel;
            _viewModel = viewModel;
            Loaded += Window_Onload;
            Closed += Window_Onclose;
            winActions.ButtonMaximize.Visibility = Visibility.Collapsed;
            winActions.ButtonMinimize.Click += WindowMinimize;
            winActions.ButtonMaximize.Click += WindowMaximize;
            winActions.ButtonClose.Click += WindowClose;
                       
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

        private void  Window_Onload(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.AbrirJanelaPagamentoCommand.Execute(null);

            }
            catch(Exception ex)
            {
                Log.Error("Erro ao carregar tela de pagamentos");
                Log.Error(ex.Message);
            }
           
        }

        private void Window_Onclose(object sender, EventArgs e)
        {

            try
            {
                _viewModel.FecharJanelaPagamentoCommand.Execute(null);

            }
            catch (Exception ex)
            {
                Log.Error("Erro ao fechar tela de pagamentos");
                Log.Error(ex.Message);
            }
        }

    }
}
