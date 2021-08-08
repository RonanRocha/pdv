using EmissorNF.Cliente.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace EmissorNF.Cliente.Telas.Caixa
{
    /// <summary>
    /// Lógica interna para WFVenda.xaml
    /// </summary>
    public partial class WFVenda : Window
    {


        public WFVenda(OperacaoVendaViewModel viewModel)
        {

            InitializeComponent();
            DataContext = viewModel;
         
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
