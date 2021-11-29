using EmissorNF.Cliente.ViewModels;
using System;
using System.Windows;


namespace EmissorNF.Cliente.Telas.Caixa
{
    /// <summary>
    /// Lógica interna para WFPagamento.xaml
    /// </summary>
    public partial class WFPagamento : Window
    {

        public WFPagamento(OperacaoVendaViewModel viewModel)
        {

            InitializeComponent();
            viewModel.FecharJanelaPagamentoAction = new Action(this.Close);
            DataContext = viewModel;
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


    }
}
