using EmissorNF.Cliente.ViewModels;
using EmissorNF.Dal.Interfaces;
using Microsoft.Extensions.DependencyInjection;
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
    /// Lógica interna para WFPagamento.xaml
    /// </summary>
    public partial class WFPagamento : Window
    {


        private readonly IServiceScopeFactory _sp;
        private readonly OperacaoVendaViewModel _viewModel;


        public WFPagamento(OperacaoVendaViewModel viewModel, IServiceScopeFactory sp)
        {
            _sp = sp;
            _viewModel = viewModel;
            InitializeComponent();
            viewModel.FecharJanelaPagamentos += FecharJanela;
            DataContext = _viewModel;
            
           
        }


 
        private void FecharJanela(object sender, EventArgs e)
        {
            this.Close();
        }


        private void WFPagamento_Closed(object sender, EventArgs e)
        {
            var scope = _sp.CreateScope();
            var op = scope.ServiceProvider.GetRequiredService<VendaFormaPagamentoViewModel>();
            _viewModel.Pagamento = null;
        }


        //private void CmbFormasPagamento_OnChanged(object sender, RoutedEventArgs e)
        //{
        //    if(CmbFormasPagamento.SelectedValue == null)
        //    {
        //        CmbParcelas.SelectedValue = null;
        //        EsconderParcelas();
        //        return;
        //    }

        //    if((int) CmbFormasPagamento.SelectedValue == 2)
        //    {

        //        MostrarParcelas();
        //        CarregarParcelas();
        //        return;
        //    }

        //    EsconderParcelas();
        //}


        //private void CarregarGrid()
        //{
        //    var pagamentos = new List<dynamic>();

        //    pagamentos.Add(new
        //    {
        //        FormaPagamento = "Dinheiro",
        //        Parcelas = 1,
        //        Valor = 20M
        //    });

        //    pagamentos.Add(new
        //    {
        //        FormaPagamento = "Debito",
        //        Parcelas = 1,
        //        Valor = 20M
        //    });

        //    pagamentos.Add(new
        //    {
        //        FormaPagamento = "Debito",
        //        Parcelas = 1,
        //        Valor = 20M
        //    });

        //    pagamentos.Add(new
        //    {
        //        FormaPagamento = "Credito",
        //        Parcelas = 3,
        //        Valor = 30M
        //    });

        //    GridPagamentos.ItemsSource = pagamentos;
        //}
        //private void CarregarFormasPagamento()
        //{
        //    var list = new List<dynamic>();

        //    list.Add(new
        //    {
        //        Nome = "Débito",
        //        Id = 1
        //    });

        //    list.Add(new
        //    {
        //        Nome = "Crédito",
        //        Id = 2
        //    });

        //    list.Add(new
        //    {
        //        Nome = "Dinheiro",
        //        Id = 3
        //    });

        //    CmbFormasPagamento.ItemsSource = list;


        //}
        //private void CarregarParcelas()
        //{
        //    var list = new List<dynamic>();

        //    list.Add(new
        //    {
        //        Nome = "1",
        //        Id = 1
        //    });

        //    list.Add(new
        //    {
        //        Nome = "2",
        //        Id = 2
        //    });

        //    list.Add(new
        //    {
        //        Nome = "3",
        //        Id = 3
        //    });

        //    CmbParcelas.ItemsSource = list;
        //}

        private void MostrarParcelas()
        {
            CmbParcelas.Visibility = Visibility.Visible;
        }

        private void EsconderParcelas()
        {
            CmbParcelas.Visibility = Visibility.Collapsed;
        }



    }
}
