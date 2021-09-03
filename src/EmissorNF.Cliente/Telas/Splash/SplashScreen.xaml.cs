using EmissorNF.Cliente.Telas.Caixa;
using EmissorNF.Cliente.Telas.Caixa.Controles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace EmissorNF.Cliente.Telas.Splash
{
    /// <summary>
    /// Lógica interna para SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {

     
        private readonly IServiceProvider _sp;

        public SplashScreen(IServiceProvider sp)
        {
            _sp = sp;
            InitializeComponent();
            Loaded += Load;
         
        }




        public void Load(object sender, EventArgs e)
        {

            try
            {
                Task.Delay(5000);
                CarregarSistema();

            }catch(Exception ex)
            {

            }
         
        }


        public void CarregarSistema()
        {
            var main = _sp.GetRequiredService<WFVenda>();
            var op = _sp.GetRequiredService<UCOperacao>();
            main.CaixaConteudo.Children.Add(op);
            main.Show();
            this.Close();
        }


    }
}
