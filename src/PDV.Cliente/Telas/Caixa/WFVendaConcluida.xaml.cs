using PDV.Cliente.ViewModels;
using System;
using System.Windows;


namespace PDV.Cliente.Telas.Caixa
{
    /// <summary>
    /// Lógica interna para WFVendaConcluida.xaml
    /// </summary>
    public partial class WFVendaConcluida : Window
    {
        public WFVendaConcluida(OperacaoVendaViewModel viewModel)
        {
            InitializeComponent();
            viewModel.FecharJanelaConclusaoVenda = new Action(this.Close);
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
