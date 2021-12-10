using AutoMapper;
using PDV.Cliente.Telas.Caixa;
using PDV.Cliente.Telas.Caixa.Controles;
using PDV.Cliente.ViewModels;
using PDV.Dal.Interfaces;
using PDV.Dal.Repositorios;
using PDV.Dominio.Entidades;
using PDV.Dominio.Validacoes;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using PDV.Dal.Contexto;

namespace PDV.Cliente.Config
{
    public class IoC
    {
        public ServiceCollection Services { get; set; }

        public IoC()
        {
            Services = new ServiceCollection();
        }


        public void Configurar()
        {
            try
            {

                Services.AddDbContext<AppDataContext>();

                Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
                Services.AddScoped<IFormaPagamentoRepositorio, FormaPagamentoRepositorio>();
                Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
                Services.AddScoped<IVendaRepositorio, VendaRepositorio>();
                Services.AddScoped<IVendaProdutoRepositorio, VendaProdutoRepositorio>();
                Services.AddScoped<IVendaFormaPagamentoRepositorio, VendaFormaPagamentoRepositorio>();
                Services.AddScoped<IUnitOfWork, UnitOfWork>();

                Services.AddScoped<OperacaoVendaViewModel>();
                Services.AddScoped<VendaViewModel>();
                Services.AddScoped<ProdutoViewModel>();
                Services.AddScoped<UsuarioViewModel>();
                Services.AddScoped<ClienteViewModel>();
                Services.AddScoped<FormaPagamentoViewModel>();
                Services.AddScoped<VendaProdutoViewModel>();
                Services.AddScoped<VendaFormaPagamentoViewModel>();


                Services.AddSingleton<WFVenda>();
                Services.AddSingleton<UCOperacao>();


                Services.AddTransient<Telas.Splash.SplashScreen>();
                Services.AddTransient<WFPagamento>();
                Services.AddTransient<WFBuscaProdutos>();
                Services.AddTransient<WFVendaConcluida>();


                var config = new AutoMapper.MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UsuarioViewModel, Usuario>();
                    cfg.CreateMap<Usuario, UsuarioViewModel>();

                    cfg.CreateMap<ClienteViewModel, PDV.Dominio.Entidades.Cliente>();
                    cfg.CreateMap<PDV.Dominio.Entidades.Cliente, ClienteViewModel>();

                    cfg.CreateMap<FormaPagamentoViewModel, FormaPagamento>();
                    cfg.CreateMap<FormaPagamento, FormaPagamentoViewModel>();

                    cfg.CreateMap<ProdutoViewModel, Produto>();
                    cfg.CreateMap<Produto, ProdutoViewModel>();

                    cfg.CreateMap<VendaFormaPagamentoViewModel, VendaFormaPagamento>();
                    cfg.CreateMap<VendaFormaPagamento, VendaFormaPagamentoViewModel>();

                    cfg.CreateMap<VendaProdutoViewModel, VendaProduto>();
                    cfg.CreateMap<VendaProduto, VendaProdutoViewModel>();

                    cfg.CreateMap<VendaViewModel, Venda>();
                    cfg.CreateMap<Venda, VendaViewModel>();


                });

                IMapper mapper = config.CreateMapper();

                Services.AddSingleton(mapper);


                Services.AddScoped<IValidator<Venda>, ValidacaoVenda>();



            }
            catch (Exception ex)
            {
                Log.Error("Erro ao configurar serviços");
                Log.Error(ex.Message);
            }
        }

       
    }
}
