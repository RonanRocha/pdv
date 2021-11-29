using EmissorNF.Cliente.ViewModels;
using System;
using System.Windows;


namespace EmissorNF.Cliente.Telas.Caixa
{
    /// <summary>
    /// Lógica interna para WFBuscaProdutos.xaml
    /// </summary>
    public partial class WFBuscaProdutos : Window
    {
        public WFBuscaProdutos(OperacaoVendaViewModel viewModel)
        {
            InitializeComponent();
            viewModel.FecharJanelaProdutosAction = new Action(this.Close);
            DataContext = viewModel;
            winActions.ButtonMaximize.Visibility = Visibility.Collapsed;
            winActions.ButtonMaximize.Click += WindowMaximize;
            winActions.ButtonMinimize.Click += WindowMinimize;
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
