using EmissorNF.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmissorNF.Dal.Contexto
{
    public class AppDataContext : DbContext
    {

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var config = new ConfigurationBuilder().AddUserSecrets("0f929eaa-c58c-4c74-a293-2c25a792a4ef").Build();
            var connectionString = config["Tenant:ConnectionString"];

           optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.UseLowerCaseNamingConvention();
            base.OnConfiguring(optionsBuilder);


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.HasDefaultSchema("public");
            builder.Entity<Cliente>().ToTable("clientes"); // herança usar OfType

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
