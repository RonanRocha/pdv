using EmissorNF.Cliente.Telas.Caixa;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using SplashScreen = EmissorNF.Cliente.Telas.Splash.SplashScreen;
using EmissorNF.Cliente.Telas.Caixa.Controles;
using System.Threading.Tasks;
using EmissorNF.Cliente.Config;
using Serilog;
using System;

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
