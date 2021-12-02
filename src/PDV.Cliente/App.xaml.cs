using PDV.Cliente.Telas.Caixa;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using SplashScreen = PDV.Cliente.Telas.Splash.SplashScreen;
using System.Threading.Tasks;
using Serilog;
using System;
using System.Threading;


namespace PDV.Cliente
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {



        private Mutex _instanceMutex;


        protected override void OnStartup(StartupEventArgs e)
        {


            bool createdNew;

            _instanceMutex = new Mutex(true, "6a85bee0-2d96-4b25-a20f-983fe20818b8", out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("Aplicação já está sendo executada");

                _instanceMutex = null;

                Application.Current.Shutdown();

                return;
            }


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

        protected override void OnExit(ExitEventArgs e)
        {
            if (_instanceMutex != null)
                _instanceMutex.ReleaseMutex();

            base.OnExit(e);
        }

    }
}
