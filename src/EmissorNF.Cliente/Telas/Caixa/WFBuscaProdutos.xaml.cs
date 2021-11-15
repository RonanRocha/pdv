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
        }

    }
}
