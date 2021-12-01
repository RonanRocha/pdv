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
using Serilog;
using System;


namespace EmissorNF.Cliente.Config
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

           

                Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
                Services.AddScoped<IFormaPagamentoRepositorio, FormaPagamentoRepositorio>();
                Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
                Services.AddScoped<IVendaRepositorio, VendaRepositorio>();

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
