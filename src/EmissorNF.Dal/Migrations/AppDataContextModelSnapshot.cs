﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PDV.Dal.Contexto;

namespace PDV.Dal.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PDV.Dominio.Entidades.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("text")
                        .HasColumnName("bairro");

                    b.Property<string>("Cep")
                        .HasColumnType("text")
                        .HasColumnName("cep");

                    b.Property<string>("CodigoMunicipio")
                        .HasColumnType("text")
                        .HasColumnName("codigomunicipio");

                    b.Property<string>("CodigoPais")
                        .HasColumnType("text")
                        .HasColumnName("codigopais");

                    b.Property<string>("CodigoUF")
                        .HasColumnType("text")
                        .HasColumnName("codigouf");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("datacadastro");

                    b.Property<string>("Logradouro")
                        .HasColumnType("text")
                        .HasColumnName("logradouro");

                    b.Property<string>("Municipio")
                        .HasColumnType("text")
                        .HasColumnName("municipio");

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<string>("Numero")
                        .HasColumnType("text")
                        .HasColumnName("numero");

                    b.Property<string>("Pais")
                        .HasColumnType("text")
                        .HasColumnName("pais");

                    b.Property<string>("SiglaUF")
                        .HasColumnType("text")
                        .HasColumnName("siglauf");

                    b.Property<int>("SituacaoEntidade")
                        .HasColumnType("integer")
                        .HasColumnName("situacaoentidade");

                    b.HasKey("Id")
                        .HasName("pk_enderecos");

                    b.ToTable("enderecos");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.EnderecoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("datacadastro");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("integer")
                        .HasColumnName("enderecoid");

                    b.Property<int>("SituacaoEntidade")
                        .HasColumnType("integer")
                        .HasColumnName("situacaoentidade");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer")
                        .HasColumnName("usuarioid");

                    b.HasKey("Id")
                        .HasName("pk_enderecousuario");

                    b.HasIndex("EnderecoId")
                        .HasDatabaseName("ix_enderecousuario_enderecoid");

                    b.HasIndex("UsuarioId")
                        .HasDatabaseName("ix_enderecousuario_usuarioid");

                    b.ToTable("enderecousuario");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.FormaPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("text")
                        .HasColumnName("codigo");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("datacadastro");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<int?>("Parcelas")
                        .HasColumnType("integer")
                        .HasColumnName("parcelas");

                    b.Property<int>("SituacaoEntidade")
                        .HasColumnType("integer")
                        .HasColumnName("situacaoentidade");

                    b.Property<int>("TipoPagamento")
                        .HasColumnType("integer")
                        .HasColumnName("tipopagamento");

                    b.HasKey("Id")
                        .HasName("pk_formapagamento");

                    b.ToTable("formapagamento");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Codigo = "04",
                            DataCadastro = new DateTime(2021, 12, 1, 10, 32, 22, 984, DateTimeKind.Local).AddTicks(32),
                            Descricao = "Maestro",
                            Parcelas = 1,
                            SituacaoEntidade = 1,
                            TipoPagamento = 1
                        },
                        new
                        {
                            Id = 2,
                            Codigo = "04",
                            DataCadastro = new DateTime(2021, 12, 1, 10, 32, 22, 984, DateTimeKind.Local).AddTicks(320),
                            Descricao = "Visa Débito",
                            Parcelas = 1,
                            SituacaoEntidade = 1,
                            TipoPagamento = 1
                        },
                        new
                        {
                            Id = 3,
                            Codigo = "04",
                            DataCadastro = new DateTime(2021, 12, 1, 10, 32, 22, 984, DateTimeKind.Local).AddTicks(323),
                            Descricao = "Elo Débito",
                            Parcelas = 1,
                            SituacaoEntidade = 1,
                            TipoPagamento = 1
                        },
                        new
                        {
                            Id = 4,
                            Codigo = "01",
                            DataCadastro = new DateTime(2021, 12, 1, 10, 32, 22, 984, DateTimeKind.Local).AddTicks(324),
                            Descricao = "Dinheiro",
                            Parcelas = 1,
                            SituacaoEntidade = 1,
                            TipoPagamento = 2
                        },
                        new
                        {
                            Id = 5,
                            Codigo = "03",
                            DataCadastro = new DateTime(2021, 12, 1, 10, 32, 22, 984, DateTimeKind.Local).AddTicks(325),
                            Descricao = "Master Crédito",
                            Parcelas = 12,
                            SituacaoEntidade = 1,
                            TipoPagamento = 1
                        });
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.GrupoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("datacadastro");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<int>("SituacaoEntidade")
                        .HasColumnType("integer")
                        .HasColumnName("situacaoentidade");

                    b.HasKey("Id")
                        .HasName("pk_grupoproduto");

                    b.ToTable("grupoproduto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataCadastro = new DateTime(2021, 12, 1, 10, 32, 22, 982, DateTimeKind.Local).AddTicks(3433),
                            Descricao = "Perfumes",
                            SituacaoEntidade = 1
                        },
                        new
                        {
                            Id = 2,
                            DataCadastro = new DateTime(2021, 12, 1, 10, 32, 22, 982, DateTimeKind.Local).AddTicks(9692),
                            Descricao = "Sabonetes",
                            SituacaoEntidade = 1
                        },
                        new
                        {
                            Id = 3,
                            DataCadastro = new DateTime(2021, 12, 1, 10, 32, 22, 982, DateTimeKind.Local).AddTicks(9704),
                            Descricao = "Essencias",
                            SituacaoEntidade = 1
                        });
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cest")
                        .HasColumnType("text")
                        .HasColumnName("cest");

                    b.Property<string>("Codigo")
                        .HasColumnType("text")
                        .HasColumnName("codigo");

                    b.Property<string>("CodigoDeBarras")
                        .HasColumnType("text")
                        .HasColumnName("codigodebarras");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("datacadastro");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<int>("GrupoProdutoId")
                        .HasColumnType("integer")
                        .HasColumnName("grupoprodutoid");

                    b.Property<string>("Ncm")
                        .HasColumnType("text")
                        .HasColumnName("ncm");

                    b.Property<int>("SituacaoEntidade")
                        .HasColumnType("integer")
                        .HasColumnName("situacaoentidade");

                    b.Property<decimal?>("ValorCompra")
                        .HasColumnType("numeric")
                        .HasColumnName("valorcompra");

                    b.Property<decimal>("ValorVenda")
                        .HasColumnType("numeric")
                        .HasColumnName("valorvenda");

                    b.HasKey("Id")
                        .HasName("pk_produtos");

                    b.HasIndex("GrupoProdutoId")
                        .HasDatabaseName("ix_produtos_grupoprodutoid");

                    b.ToTable("produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cest = "2000800",
                            Codigo = "001",
                            CodigoDeBarras = "SEM GTIN",
                            DataCadastro = new DateTime(2021, 12, 1, 10, 32, 22, 983, DateTimeKind.Local).AddTicks(7522),
                            Descricao = "VIP 01 - MASCULINO",
                            GrupoProdutoId = 1,
                            Ncm = "33030020",
                            SituacaoEntidade = 1,
                            ValorCompra = 30m,
                            ValorVenda = 69.9m
                        },
                        new
                        {
                            Id = 2,
                            Cest = "2000800",
                            Codigo = "002",
                            CodigoDeBarras = "SEM GTIN",
                            DataCadastro = new DateTime(2021, 12, 1, 10, 32, 22, 983, DateTimeKind.Local).AddTicks(7801),
                            Descricao = "VIP 02 - FEMININO",
                            GrupoProdutoId = 1,
                            Ncm = "33030020",
                            SituacaoEntidade = 1,
                            ValorCompra = 30m,
                            ValorVenda = 69.9m
                        },
                        new
                        {
                            Id = 3,
                            Cest = "2000800",
                            Codigo = "003",
                            CodigoDeBarras = "SEM GTIN",
                            DataCadastro = new DateTime(2021, 12, 1, 10, 32, 22, 983, DateTimeKind.Local).AddTicks(7805),
                            Descricao = "VIP 03 - MASCULINO",
                            GrupoProdutoId = 1,
                            Ncm = "33030020",
                            SituacaoEntidade = 1,
                            ValorCompra = 30m,
                            ValorVenda = 69.9m
                        });
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("text")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("datacadastro");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .HasColumnType("text")
                        .HasColumnName("senha");

                    b.Property<int>("SituacaoEntidade")
                        .HasColumnType("integer")
                        .HasColumnName("situacaoentidade");

                    b.HasKey("Id");

                    b.ToTable("usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "388477898",
                            DataCadastro = new DateTime(2021, 12, 1, 10, 32, 22, 983, DateTimeKind.Local).AddTicks(8764),
                            Email = "ronan.rochasouza@gmail.com",
                            Nome = "Ronan Rocha",
                            Senha = "1234",
                            SituacaoEntidade = 1
                        },
                        new
                        {
                            Id = 2,
                            Cpf = "67371822080",
                            DataCadastro = new DateTime(2021, 12, 1, 10, 32, 22, 983, DateTimeKind.Local).AddTicks(9055),
                            Email = "mvp@gmail.com",
                            Nome = "Marcos Poli",
                            Senha = "1234",
                            SituacaoEntidade = 1
                        },
                        new
                        {
                            Id = 3,
                            Cpf = "69947008010",
                            DataCadastro = new DateTime(2021, 12, 1, 10, 32, 22, 983, DateTimeKind.Local).AddTicks(9058),
                            Email = "michael@gmail.com",
                            Nome = "Michael",
                            Senha = "1234",
                            SituacaoEntidade = 1
                        });
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("integer")
                        .HasColumnName("clienteid");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("datacadastro");

                    b.Property<DateTime?>("DataFechamento")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("datafechamento");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<int>("SituacaoEntidade")
                        .HasColumnType("integer")
                        .HasColumnName("situacaoentidade");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("numeric")
                        .HasColumnName("subtotal");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric")
                        .HasColumnName("total");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("integer")
                        .HasColumnName("usuarioid");

                    b.Property<decimal>("ValorAcrescimo")
                        .HasColumnType("numeric")
                        .HasColumnName("valoracrescimo");

                    b.Property<decimal>("ValorDesconto")
                        .HasColumnType("numeric")
                        .HasColumnName("valordesconto");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("numeric")
                        .HasColumnName("valorpago");

                    b.Property<decimal>("ValorTroco")
                        .HasColumnType("numeric")
                        .HasColumnName("valortroco");

                    b.HasKey("Id")
                        .HasName("pk_vendas");

                    b.HasIndex("ClienteId")
                        .HasDatabaseName("ix_vendas_clienteid");

                    b.HasIndex("UsuarioId")
                        .HasDatabaseName("ix_vendas_usuarioid");

                    b.ToTable("vendas");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.VendaFormaPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("datacadastro");

                    b.Property<int?>("DivididoEm")
                        .HasColumnType("integer")
                        .HasColumnName("divididoem");

                    b.Property<int>("FormaPagamentoId")
                        .HasColumnType("integer")
                        .HasColumnName("formapagamentoid");

                    b.Property<int>("SituacaoEntidade")
                        .HasColumnType("integer")
                        .HasColumnName("situacaoentidade");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("numeric")
                        .HasColumnName("valorpago");

                    b.Property<int>("VendaId")
                        .HasColumnType("integer")
                        .HasColumnName("vendaid");

                    b.HasKey("Id")
                        .HasName("pk_vendaformapagamento");

                    b.HasIndex("FormaPagamentoId")
                        .HasDatabaseName("ix_vendaformapagamento_formapagamentoid");

                    b.HasIndex("VendaId")
                        .HasDatabaseName("ix_vendaformapagamento_vendaid");

                    b.ToTable("vendaformapagamento");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.VendaProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("datacadastro");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer")
                        .HasColumnName("produtoid");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer")
                        .HasColumnName("quantidade");

                    b.Property<int>("SituacaoEntidade")
                        .HasColumnType("integer")
                        .HasColumnName("situacaoentidade");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("numeric")
                        .HasColumnName("subtotal");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric")
                        .HasColumnName("total");

                    b.Property<decimal>("ValorAcrescimo")
                        .HasColumnType("numeric")
                        .HasColumnName("valoracrescimo");

                    b.Property<decimal>("ValorDesconto")
                        .HasColumnType("numeric")
                        .HasColumnName("valordesconto");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("numeric")
                        .HasColumnName("valorunitario");

                    b.Property<int>("VendaId")
                        .HasColumnType("integer")
                        .HasColumnName("vendaid");

                    b.HasKey("Id")
                        .HasName("pk_vendaproduto");

                    b.HasIndex("ProdutoId")
                        .HasDatabaseName("ix_vendaproduto_produtoid");

                    b.HasIndex("VendaId")
                        .HasDatabaseName("ix_vendaproduto_vendaid");

                    b.ToTable("vendaproduto");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.Cliente", b =>
                {
                    b.HasBaseType("PDV.Dominio.Entidades.Usuario");

                    b.Property<string>("Cnpj")
                        .HasColumnType("text")
                        .HasColumnName("cnpj");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.EnderecoUsuario", b =>
                {
                    b.HasOne("PDV.Dominio.Entidades.Endereco", "Endereco")
                        .WithMany("Usuarios")
                        .HasForeignKey("EnderecoId")
                        .HasConstraintName("fk_enderecousuario_enderecos_enderecoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PDV.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany("Enderecos")
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("fk_enderecousuario_usuarios_usuarioid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.Produto", b =>
                {
                    b.HasOne("PDV.Dominio.Entidades.GrupoProduto", "GrupoProduto")
                        .WithMany("Produtos")
                        .HasForeignKey("GrupoProdutoId")
                        .HasConstraintName("fk_produtos_grupoproduto_grupoprodutoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoProduto");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.Venda", b =>
                {
                    b.HasOne("PDV.Dominio.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("fk_vendas_clientes_clienteid");

                    b.HasOne("PDV.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("fk_vendas_usuarios_usuarioid");

                    b.Navigation("Cliente");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.VendaFormaPagamento", b =>
                {
                    b.HasOne("PDV.Dominio.Entidades.FormaPagamento", "FormaPagamento")
                        .WithMany("Vendas")
                        .HasForeignKey("FormaPagamentoId")
                        .HasConstraintName("fk_vendaformapagamento_formapagamento_formapagamentoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PDV.Dominio.Entidades.Venda", "Venda")
                        .WithMany("Pagamentos")
                        .HasForeignKey("VendaId")
                        .HasConstraintName("fk_vendaformapagamento_vendas_vendaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormaPagamento");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.VendaProduto", b =>
                {
                    b.HasOne("PDV.Dominio.Entidades.Produto", "Produto")
                        .WithMany("Vendas")
                        .HasForeignKey("ProdutoId")
                        .HasConstraintName("fk_vendaproduto_produtos_produtoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PDV.Dominio.Entidades.Venda", "Venda")
                        .WithMany("Produtos")
                        .HasForeignKey("VendaId")
                        .HasConstraintName("fk_vendaproduto_vendas_vendaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.Cliente", b =>
                {
                    b.HasOne("PDV.Dominio.Entidades.Usuario", null)
                        .WithOne()
                        .HasForeignKey("PDV.Dominio.Entidades.Cliente", "Id")
                        .HasConstraintName("fk_clientes_usuarios_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.Endereco", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.FormaPagamento", b =>
                {
                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.GrupoProduto", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.Produto", b =>
                {
                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.Usuario", b =>
                {
                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("PDV.Dominio.Entidades.Venda", b =>
                {
                    b.Navigation("Pagamentos");

                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
