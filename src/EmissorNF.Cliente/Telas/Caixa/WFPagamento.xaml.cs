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
        public WFPagamento()
        {
            InitializeComponent();
            Loaded += WFPagamento_OnLoaded;
        }


        public void WFPagamento_OnLoaded(object sender, RoutedEventArgs e)
        {

            CarregarGrid();
            CarregarFormasPagamento();
            CarregarParcelas();
           
        }


        private void CarregarGrid()
        {
            var pagamentos = new List<dynamic>();

            pagamentos.Add(new
            {
                FormaPagamento = "Dinheiro",
                Parcelas = 1,
                Valor = 20M
            });

            pagamentos.Add(new
            {
                FormaPagamento = "Debito",
                Parcelas = 1,
                Valor = 20M
            });

            pagamentos.Add(new
            {
                FormaPagamento = "Debito",
                Parcelas = 1,
                Valor = 20M
            });

            pagamentos.Add(new
            {
                FormaPagamento = "Credito",
                Parcelas = 3,
                Valor = 30M
            });

            GridPagamentos.ItemsSource = pagamentos;
        }
        private void CarregarFormasPagamento()
        {
            var list = new List<dynamic>();

            list.Add(new
            {
                Nome = "Débito",
                Id = 1
            });

            list.Add(new
            {
                Nome = "Crédito",
                Id = 2
            });

            list.Add(new
            {
                Nome = "Dinheiro",
                Id = 3
            });

            CmbFormasPagamento.ItemsSource = list;


        }
        private void CarregarParcelas()
        {
            var list = new List<dynamic>();

            list.Add(new
            {
                Nome = "1",
                Id = 1
            });

            list.Add(new
            {
                Nome = "2",
                Id = 2
            });

            list.Add(new
            {
                Nome = "3",
                Id = 3
            });

            CmbParcelas.ItemsSource = list;
        }


    }
}
