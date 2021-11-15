using EmissorNF.Cliente.Telas.Caixa;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using SplashScreen = EmissorNF.Cliente.Telas.Splash.SplashScreen;
using EmissorNF.Cliente.Telas.Caixa.Controles;
using System.Threading.Tasks;
using EmissorNF.Cliente.Config;

namespace EmissorNF.Cliente
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

   

        protected override void OnStartup(StartupEventArgs e)
        {



            base.OnStartup(e);
            Linguagem.Configurar();
            var services = IoC.Configurar();

          
            ServiceProvider service = services.BuildServiceProvider();


           var splash = service.GetRequiredService<SplashScreen>();
       

            splash.Show();


            Task.Factory.StartNew(() =>
            {
                //simulate some work being done
                System.Threading.Thread.Sleep(3000);

                //since we're not on the UI thread
                //once we're done we need to use the Dispatcher
                //to create and show the main window
                this.Dispatcher.Invoke(() =>
                {
                    var main = service.GetRequiredService<WFVenda>();
                    var op = service.GetRequiredService<UCOperacao>();
                    main.CaixaConteudo.Children.Add(op);
                    main.Show();
                    splash.Close();
                });
            });


        }
    
    }
}
