using EmissorNF.Cliente.ViewModels;
using EmissorNF.Dal.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
