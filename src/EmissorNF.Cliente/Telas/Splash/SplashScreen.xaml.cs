using EmissorNF.Cliente.Config;
using EmissorNF.Cliente.Telas.Caixa;
using EmissorNF.Cliente.Telas.Caixa.Controles;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Threading.Tasks;
using System.Windows;


namespace EmissorNF.Cliente.Telas.Splash
{
    /// <summary>
    /// Lógica interna para SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {

        private  ServiceProvider _provider;
        private IoC _ioc;

        public SplashScreen()
        {
            InitializeComponent();
            _ioc = new IoC();
          
            Loaded += WindowLoaded;
                  
        }


        public void WindowLoaded(object sender, RoutedEventArgs e)
        {
            CarregarSistema();
        }

        public void CarregarSistema()
        {

            Task.Factory.StartNew(() =>
            {

                try
                {

                    AtualizarInformacoes("Configurando Serviços");

                    _ioc.Configurar();
                    _provider = _ioc.Services.BuildServiceProvider();

                    AtualizarInformacoes("Serviços Configurados");

                    AtualizarInformacoes("Configurando Linguagem");
                    Linguagem.Configurar();
                    System.Threading.Thread.Sleep(1000);

                    AtualizarInformacoes("Linguagem Configurada");

                    AtualizarInformacoes("Iniciando Sistema");

                    this.Dispatcher.Invoke(() =>
                    {

                        var main = _provider.GetRequiredService<WFVenda>();
                        var op = _provider.GetRequiredService<UCOperacao>();
                        main.CaixaConteudo.Children.Add(op);
                        main.Show();
                        this.Close();
                    });

                }
                catch(Exception ex)
                {
                    Log.Error("Erro ao carregar sistema splashscreen");
                    Log.Error(ex.Message);
                }
             
            });
        }


        public void AtualizarInformacoes(string text)
        {
            Dispatcher.BeginInvoke((Action)delegate
            {              
                Info.Content = text;
            });

            System.Threading.Thread.Sleep(1000);
        }
    }
}
