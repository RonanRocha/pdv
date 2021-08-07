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


      
        private readonly IServiceScopeFactory _sp;

        public WFVenda(OperacaoVendaViewModel viewModel, IServiceScopeFactory sp)
        {
            _sp = sp;
            InitializeComponent();
            viewModel.IniciarVenda += Invoke_IniciarVenda;
            DataContext = viewModel;
            
        }


        public void IniciarVenda()
        {

            var scope = _sp.CreateScope();
            var op = scope.ServiceProvider.GetRequiredService<OperacaoVendaViewModel>();
            op.IniciarVenda += Invoke_IniciarVenda;
            DataContext = op;
              
            
        }


        public void Invoke_IniciarVenda(object sender, EventArgs e)
        {
            IniciarVenda();
        }


        





        public void IniciarVenda_OnClicked(object sender, RoutedEventArgs e)
        {
            IniciarVenda();
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


    }
}
