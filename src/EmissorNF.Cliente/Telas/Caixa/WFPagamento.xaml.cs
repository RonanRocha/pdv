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
                       
        }

    }
}
