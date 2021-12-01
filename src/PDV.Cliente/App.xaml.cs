using PDV.Cliente.Telas.Caixa;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using SplashScreen = PDV.Cliente.Telas.Splash.SplashScreen;
using PDV.Cliente.Telas.Caixa.Controles;
using System.Threading.Tasks;
using PDV.Cliente.Config;
using Serilog;
using System;

namespace PDV.Cliente
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

   

        protected override void OnStartup(StartupEventArgs e)
        {



            base.OnStartup(e);

            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();


            try
            {
                Task.Factory.StartNew(() =>
                {


                    this.Dispatcher.Invoke(() =>
                    {
                        var splash = new SplashScreen();
                        splash.Show();

                    });
                });
            }
            catch(Exception ex)
            {
                Log.Error("Erro ao iniciar sistema");
                Log.Error(ex.Message);
            }

          


        }
    
    }
}
