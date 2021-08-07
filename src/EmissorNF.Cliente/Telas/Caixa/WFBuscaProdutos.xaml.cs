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
    /// Lógica interna para WFBuscaProdutos.xaml
    /// </summary>
    public partial class WFBuscaProdutos : Window
    {
        public WFBuscaProdutos(OperacaoVendaViewModel viewModel)
        {
            InitializeComponent();
            viewModel.FecharJanelaProdutos += Fechar;
            DataContext = viewModel;
            
        }


        public void Fechar(object sender, EventArgs e)
        {
            this.Close();
        }
     

        //public void CarregarProdutos()
        //{
        //    var p = new List<dynamic>();

        //    p.Add(new
        //    {
        //        Id = 1,
        //        Codigo = "P0012435",
        //        Descricao = "PERFUME VIP 01 - 500 ML",
        //        Preco = 259.9M
        //    });

        //    p.Add(new
        //    {
        //        Id = 2,
        //        Codigo = "P0012436",
        //        Descricao = "PERFUME VIP 02 - 500 ML",
        //        Preco = 259.9M
        //    });

        //    p.Add(new
        //    {
        //        Id = 1,
        //        Codigo = "P0012437",
        //        Descricao = "PERFUME VIP 03 - 500 ML",
        //        Preco = 259.9M
        //    });


        //    GridProdutos.ItemsSource = p;
        //}

    }
}
