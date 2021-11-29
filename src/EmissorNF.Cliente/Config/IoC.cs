using AutoMapper;
using EmissorNF.Cliente.Telas.Caixa;
using EmissorNF.Cliente.Telas.Caixa.Controles;
using EmissorNF.Cliente.ViewModels;
using EmissorNF.Dal.Interfaces;
using EmissorNF.Dal.Repositorios;
using EmissorNF.Dominio.Entidades;
using EmissorNF.Dominio.Validacoes;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace EmissorNF.Cliente.Config
{
    public class IoC
    {

        public static ServiceCollection Configurar()
        {
            try
            {

                ServiceCollection services = new ServiceCollection();

                services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
                services.AddScoped<IFormaPagamentoRepositorio, FormaPagamentoRepositorio>();
                services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
                services.AddScoped<IVendaRepositorio, VendaRepositorio>();

                services.AddScoped<OperacaoVendaViewModel>();
                services.AddScoped<VendaViewModel>();
                services.AddScoped<ProdutoViewModel>();
                services.AddScoped<UsuarioViewModel>();
                services.AddScoped<ClienteViewModel>();
                services.AddScoped<FormaPagamentoViewModel>();
                services.AddScoped<VendaProdutoViewModel>();
                services.AddScoped<VendaFormaPagamentoViewModel>();


                services.AddSingleton<WFVenda>();
                services.AddSingleton<UCOperacao>();


                services.AddTransient<Telas.Splash.SplashScreen>();
                services.AddTransient<WFPagamento>();
                services.AddTransient<WFBuscaProdutos>();
                services.AddTransient<WFVendaConcluida>();


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

                    cfg.CreateMap<VendaViewModel, Venda>();
                    cfg.CreateMap<Venda, VendaViewModel>();


                });

                IMapper mapper = config.CreateMapper();

                services.AddSingleton(mapper);


                services.AddScoped<IValidator<Venda>, ValidacaoVenda>();



                return services;

            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
