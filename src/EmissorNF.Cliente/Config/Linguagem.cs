using Serilog;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace EmissorNF.Cliente.Config
{
    public class Linguagem
    {
        public static void Configurar()
        {
            try
            {

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

                FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));


            }
            catch(Exception ex)
            {
                Log.Error("Erro ao configurar linguagem");
                Log.Error(ex.Message);
            }
        }
    }
}
