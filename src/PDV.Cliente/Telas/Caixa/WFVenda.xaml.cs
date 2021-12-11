using PDV.Cliente.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace PDV.Cliente.Telas.Caixa
{
    /// <summary>
    /// Lógica interna para WFVenda.xaml
    /// </summary>
    public partial class WFVenda : Window
    {


        public WFVenda()
        {

            InitializeComponent();
            winActions.ButtonClose.Click += WindowClose;
            winActions.ButtonMaximize.Click += WindowMaximize;
            winActions.ButtonMinimize.Click += WindowMinimize;
       
        }



        private void WindowMinimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        public void WindowClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowMaximize(object sender, RoutedEventArgs e)
        {

            if(this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                return;
            }

            this.WindowState = WindowState.Maximized;
        }


   

    }
}
