using EmissorNF.Cliente.ViewModels;
using System;
using System.Collections.Generic;
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
