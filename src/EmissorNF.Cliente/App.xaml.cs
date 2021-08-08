using AutoMapper;
using EmissorNF.Cliente.Telas.Caixa;
using EmissorNF.Cliente.ViewModels;
using EmissorNF.Dal.Interfaces;
using EmissorNF.Dal.Repositorios;
using EmissorNF.Dominio.Entidades;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

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

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));


            ServiceCollection services = new ServiceCollection();
 
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IFormaPagamentoRepositorio, FormaPagamentoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddScoped<OperacaoVendaViewModel>();
            services.AddScoped<VendaViewModel>();
            services.AddScoped<ProdutoViewModel>();
            services.AddScoped<UsuarioViewModel>();
            services.AddScoped<ClienteViewModel>();
            services.AddScoped<FormaPagamentoViewModel>();
            services.AddScoped<VendaProdutoViewModel>();
            services.AddScoped<VendaFormaPagamentoViewModel>();


            services.AddScoped<WFVenda>();

            services.AddTransient<WFPagamento>();
            services.AddTransient<WFBuscaProdutos>();

            




            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioViewModel, Usuario>();
                cfg.CreateMap<Usuario, UsuarioViewModel>();

                cfg.CreateMap<ClienteViewModel, EmissorNF.Dominio.Entidades.Cliente>();
                cfg.CreateMap<EmissorNF.Dominio.Entidades.Cliente, ClienteViewModel>();

                cfg.CreateMap<FormaPagamentoViewModel, FormaPagamento>();
                cfg.CreateMap<FormaPagamento, FormaPagamentoViewModel>();

                cfg.CreateMap<ProdutoViewModel, Produto>();
                cfg.CreateMap<Produto, ProdutoViewModel>();

                cfg.CreateMap<VendaFormaPagamentoViewModel, VendaFormaPagamento>();
                cfg.CreateMap<VendaFormaPagamento, VendaFormaPagamentoViewModel>();

                cfg.CreateMap<VendaProdutoViewModel, VendaProduto>();
                cfg.CreateMap<VendaProduto, VendaProdutoViewModel>();

            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);


            ServiceProvider service = services.BuildServiceProvider();


            WFVenda  wf = service.GetRequiredService<WFVenda>();
            wf.Show();



        }
    
    }
}
