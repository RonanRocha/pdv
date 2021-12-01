using PDV.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PDV.Dal.Contexto
{
    public class AppDataContext : DbContext
    {

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var config = new ConfigurationBuilder().AddUserSecrets("0f929eaa-c58c-4c74-a293-2c25a792a4ef").Build();
            var connectionString = config["Pdv:ConnectionString"];

           optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.UseLowerCaseNamingConvention();
            base.OnConfiguring(optionsBuilder);


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.HasDefaultSchema("public");
            builder.Entity<Cliente>().ToTable("clientes"); // herança usar OfType

            builder.Entity<GrupoProduto>().HasData(
               new GrupoProduto
               {
                   Id = 1,
                   Descricao = "Perfumes",
                   DataCadastro = System.DateTime.Now,
                   SituacaoEntidade = Dominio.Enums.SituacaoEntidade.Ativo
               },
               new GrupoProduto
               {
                   Id = 2,
                   Descricao = "Sabonetes",
                   DataCadastro = System.DateTime.Now,
                   SituacaoEntidade = Dominio.Enums.SituacaoEntidade.Ativo
               },
               new GrupoProduto
                {
                    Id = 3,
                    Descricao = "Essencias",
                    DataCadastro = System.DateTime.Now,
                    SituacaoEntidade = Dominio.Enums.SituacaoEntidade.Ativo
                }
            );

            builder.Entity<Produto>().HasData(
               new Produto
               {
                   Id = 1,
                   Descricao = "VIP 01 - MASCULINO",
                   GrupoProdutoId = 1,
                   ValorCompra = 30M,
                   ValorVenda = 69.9M,
                   Codigo = "001",
                   CodigoDeBarras ="SEM GTIN",
                   Cest = "2000800",
                   Ncm = "33030020",
                   DataCadastro = System.DateTime.Now,
                   SituacaoEntidade = Dominio.Enums.SituacaoEntidade.Ativo
               },
               new Produto
               {
                   Id = 2,
                   Descricao = "VIP 02 - FEMININO",
                   GrupoProdutoId = 1,
                   ValorCompra = 30M,
                   ValorVenda = 69.9M,
                   Codigo = "002",
                   CodigoDeBarras = "SEM GTIN",
                   Cest = "2000800",
                   Ncm = "33030020",
                   DataCadastro = System.DateTime.Now,
                   SituacaoEntidade = Dominio.Enums.SituacaoEntidade.Ativo
               },
               new Produto
               {
                   Id = 3,
                   Descricao = "VIP 03 - MASCULINO",
                   GrupoProdutoId = 1,
                   ValorCompra = 30M,
                   ValorVenda = 69.9M,
                   Codigo = "003",
                   CodigoDeBarras = "SEM GTIN",
                   Cest = "2000800",
                   Ncm = "33030020",
                   DataCadastro = System.DateTime.Now,
                   SituacaoEntidade = Dominio.Enums.SituacaoEntidade.Ativo
                }
            );

            builder.Entity<Usuario>().HasData(
               new Usuario
            {
                Id = 1,
                Nome = "Ronan Rocha",
                Email = "ronan.rochasouza@gmail.com",
                Senha = "1234",
                Cpf = "388477898",
                DataCadastro = System.DateTime.Now,
                SituacaoEntidade = Dominio.Enums.SituacaoEntidade.Ativo
            },
               new Usuario
            {
                Id = 2,
                Nome = "Marcos Poli",
                Email = "mvp@gmail.com",
                Senha = "1234",
                Cpf = "67371822080",
                DataCadastro = System.DateTime.Now,
                SituacaoEntidade = Dominio.Enums.SituacaoEntidade.Ativo
            },
               new Usuario
            {
                Id = 3,
                Nome = "Michael",
                Email = "michael@gmail.com",
                Senha = "1234",
                Cpf = "69947008010",
                DataCadastro = System.DateTime.Now,
                SituacaoEntidade = Dominio.Enums.SituacaoEntidade.Ativo
            }
            );

            builder.Entity<FormaPagamento>().HasData(
              new FormaPagamento
              {
                  Id = 1,
                  Descricao = "Maestro",
                  Parcelas = 1,
                  Codigo = "04",
                  TipoPagamento = Dominio.Enums.TipoPagamento.Debito,
                  DataCadastro = System.DateTime.Now,
                  SituacaoEntidade = Dominio.Enums.SituacaoEntidade.Ativo
              },
              new FormaPagamento
              {
                  Id = 2,
                  Descricao = "Visa Débito",
                  Parcelas = 1,
                  Codigo = "04",
                  TipoPagamento = Dominio.Enums.TipoPagamento.Debito,
                  DataCadastro = System.DateTime.Now,
                  SituacaoEntidade = Dominio.Enums.SituacaoEntidade.Ativo
              },
              new FormaPagamento
              {
                  Id = 3,
                  Descricao = "Elo Débito",
                  Parcelas = 1,
                  Codigo = "04",
                  TipoPagamento = Dominio.Enums.TipoPagamento.Debito,
                  DataCadastro = System.DateTime.Now,
                  SituacaoEntidade = Dominio.Enums.SituacaoEntidade.Ativo
              },
              new FormaPagamento
               {
                   Id = 4,
                   Descricao = "Dinheiro",
                   Parcelas = 1,
                   Codigo = "01",
                   TipoPagamento = Dominio.Enums.TipoPagamento.Dinheiro,
                   DataCadastro = System.DateTime.Now,
                   SituacaoEntidade = Dominio.Enums.SituacaoEntidade.Ativo
               },
              new FormaPagamento
              {
                  Id = 5,
                  Descricao = "Master Crédito",
                  Parcelas = 12,
                  Codigo = "03",
                  TipoPagamento = Dominio.Enums.TipoPagamento.Debito,
                  DataCadastro = System.DateTime.Now,
                  SituacaoEntidade = Dominio.Enums.SituacaoEntidade.Ativo
              }
            );

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<EnderecoUsuario> EnderecoUsuarios { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }
        public DbSet<GrupoProduto> GrupoProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaFormaPagamento> VendaFormaPagamentos { get; set; }
        public DbSet<VendaProduto> VendaProdutos { get; set; }


    }
}
