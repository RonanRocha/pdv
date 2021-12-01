using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PDV.Dal.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "enderecos",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    cep = table.Column<string>(type: "text", nullable: true),
                    logradouro = table.Column<string>(type: "text", nullable: true),
                    numero = table.Column<string>(type: "text", nullable: true),
                    bairro = table.Column<string>(type: "text", nullable: true),
                    codigouf = table.Column<string>(type: "text", nullable: true),
                    siglauf = table.Column<string>(type: "text", nullable: true),
                    codigomunicipio = table.Column<string>(type: "text", nullable: true),
                    municipio = table.Column<string>(type: "text", nullable: true),
                    pais = table.Column<string>(type: "text", nullable: true),
                    codigopais = table.Column<string>(type: "text", nullable: true),
                    situacaoentidade = table.Column<int>(type: "integer", nullable: false),
                    datacadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enderecos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "formapagamento",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    codigo = table.Column<string>(type: "text", nullable: true),
                    parcelas = table.Column<int>(type: "integer", nullable: true),
                    tipopagamento = table.Column<int>(type: "integer", nullable: false),
                    situacaoentidade = table.Column<int>(type: "integer", nullable: false),
                    datacadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_formapagamento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "grupoproduto",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    situacaoentidade = table.Column<int>(type: "integer", nullable: false),
                    datacadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grupoproduto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: true),
                    nome = table.Column<string>(type: "text", nullable: true),
                    cpf = table.Column<string>(type: "text", nullable: true),
                    senha = table.Column<string>(type: "text", nullable: true),
                    situacaoentidade = table.Column<int>(type: "integer", nullable: false),
                    datacadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    grupoprodutoid = table.Column<int>(type: "integer", nullable: false),
                    codigo = table.Column<string>(type: "text", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    codigodebarras = table.Column<string>(type: "text", nullable: true),
                    valorcompra = table.Column<decimal>(type: "numeric", nullable: true),
                    valorvenda = table.Column<decimal>(type: "numeric", nullable: false),
                    ncm = table.Column<string>(type: "text", nullable: true),
                    cest = table.Column<string>(type: "text", nullable: true),
                    situacaoentidade = table.Column<int>(type: "integer", nullable: false),
                    datacadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_produtos", x => x.id);
                    table.ForeignKey(
                        name: "fk_produtos_grupoproduto_grupoprodutoid",
                        column: x => x.grupoprodutoid,
                        principalSchema: "public",
                        principalTable: "grupoproduto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cnpj = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id);
                    table.ForeignKey(
                        name: "fk_clientes_usuarios_id",
                        column: x => x.id,
                        principalSchema: "public",
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enderecousuario",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enderecoid = table.Column<int>(type: "integer", nullable: false),
                    usuarioid = table.Column<int>(type: "integer", nullable: false),
                    situacaoentidade = table.Column<int>(type: "integer", nullable: false),
                    datacadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enderecousuario", x => x.id);
                    table.ForeignKey(
                        name: "fk_enderecousuario_enderecos_enderecoid",
                        column: x => x.enderecoid,
                        principalSchema: "public",
                        principalTable: "enderecos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_enderecousuario_usuarios_usuarioid",
                        column: x => x.usuarioid,
                        principalSchema: "public",
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendas",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usuarioid = table.Column<int>(type: "integer", nullable: true),
                    clienteid = table.Column<int>(type: "integer", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    total = table.Column<decimal>(type: "numeric", nullable: false),
                    subtotal = table.Column<decimal>(type: "numeric", nullable: false),
                    valordesconto = table.Column<decimal>(type: "numeric", nullable: false),
                    valoracrescimo = table.Column<decimal>(type: "numeric", nullable: false),
                    valortroco = table.Column<decimal>(type: "numeric", nullable: false),
                    valorpago = table.Column<decimal>(type: "numeric", nullable: false),
                    datafechamento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    situacaoentidade = table.Column<int>(type: "integer", nullable: false),
                    datacadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vendas", x => x.id);
                    table.ForeignKey(
                        name: "fk_vendas_clientes_clienteid",
                        column: x => x.clienteid,
                        principalSchema: "public",
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_vendas_usuarios_usuarioid",
                        column: x => x.usuarioid,
                        principalSchema: "public",
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vendaformapagamento",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    formapagamentoid = table.Column<int>(type: "integer", nullable: false),
                    vendaid = table.Column<int>(type: "integer", nullable: false),
                    valorpago = table.Column<decimal>(type: "numeric", nullable: false),
                    divididoem = table.Column<int>(type: "integer", nullable: true),
                    situacaoentidade = table.Column<int>(type: "integer", nullable: false),
                    datacadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vendaformapagamento", x => x.id);
                    table.ForeignKey(
                        name: "fk_vendaformapagamento_formapagamento_formapagamentoid",
                        column: x => x.formapagamentoid,
                        principalSchema: "public",
                        principalTable: "formapagamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vendaformapagamento_vendas_vendaid",
                        column: x => x.vendaid,
                        principalSchema: "public",
                        principalTable: "vendas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendaproduto",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    produtoid = table.Column<int>(type: "integer", nullable: false),
                    vendaid = table.Column<int>(type: "integer", nullable: false),
                    valorunitario = table.Column<decimal>(type: "numeric", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    total = table.Column<decimal>(type: "numeric", nullable: false),
                    subtotal = table.Column<decimal>(type: "numeric", nullable: false),
                    valordesconto = table.Column<decimal>(type: "numeric", nullable: false),
                    valoracrescimo = table.Column<decimal>(type: "numeric", nullable: false),
                    situacaoentidade = table.Column<int>(type: "integer", nullable: false),
                    datacadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vendaproduto", x => x.id);
                    table.ForeignKey(
                        name: "fk_vendaproduto_produtos_produtoid",
                        column: x => x.produtoid,
                        principalSchema: "public",
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vendaproduto_vendas_vendaid",
                        column: x => x.vendaid,
                        principalSchema: "public",
                        principalTable: "vendas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "formapagamento",
                columns: new[] { "id", "codigo", "datacadastro", "descricao", "parcelas", "situacaoentidade", "tipopagamento" },
                values: new object[,]
                {
                    { 1, "04", new DateTime(2021, 12, 1, 10, 32, 22, 984, DateTimeKind.Local).AddTicks(32), "Maestro", 1, 1, 1 },
                    { 2, "04", new DateTime(2021, 12, 1, 10, 32, 22, 984, DateTimeKind.Local).AddTicks(320), "Visa Débito", 1, 1, 1 },
                    { 3, "04", new DateTime(2021, 12, 1, 10, 32, 22, 984, DateTimeKind.Local).AddTicks(323), "Elo Débito", 1, 1, 1 },
                    { 4, "01", new DateTime(2021, 12, 1, 10, 32, 22, 984, DateTimeKind.Local).AddTicks(324), "Dinheiro", 1, 1, 2 },
                    { 5, "03", new DateTime(2021, 12, 1, 10, 32, 22, 984, DateTimeKind.Local).AddTicks(325), "Master Crédito", 12, 1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "grupoproduto",
                columns: new[] { "id", "datacadastro", "descricao", "situacaoentidade" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 1, 10, 32, 22, 982, DateTimeKind.Local).AddTicks(3433), "Perfumes", 1 },
                    { 2, new DateTime(2021, 12, 1, 10, 32, 22, 982, DateTimeKind.Local).AddTicks(9692), "Sabonetes", 1 },
                    { 3, new DateTime(2021, 12, 1, 10, 32, 22, 982, DateTimeKind.Local).AddTicks(9704), "Essencias", 1 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "usuarios",
                columns: new[] { "id", "cpf", "datacadastro", "email", "nome", "senha", "situacaoentidade" },
                values: new object[,]
                {
                    { 1, "388477898", new DateTime(2021, 12, 1, 10, 32, 22, 983, DateTimeKind.Local).AddTicks(8764), "ronan.rochasouza@gmail.com", "Ronan Rocha", "1234", 1 },
                    { 2, "67371822080", new DateTime(2021, 12, 1, 10, 32, 22, 983, DateTimeKind.Local).AddTicks(9055), "mvp@gmail.com", "Marcos Poli", "1234", 1 },
                    { 3, "69947008010", new DateTime(2021, 12, 1, 10, 32, 22, 983, DateTimeKind.Local).AddTicks(9058), "michael@gmail.com", "Michael", "1234", 1 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "produtos",
                columns: new[] { "id", "cest", "codigo", "codigodebarras", "datacadastro", "descricao", "grupoprodutoid", "ncm", "situacaoentidade", "valorcompra", "valorvenda" },
                values: new object[,]
                {
                    { 1, "2000800", "001", "SEM GTIN", new DateTime(2021, 12, 1, 10, 32, 22, 983, DateTimeKind.Local).AddTicks(7522), "VIP 01 - MASCULINO", 1, "33030020", 1, 30m, 69.9m },
                    { 2, "2000800", "002", "SEM GTIN", new DateTime(2021, 12, 1, 10, 32, 22, 983, DateTimeKind.Local).AddTicks(7801), "VIP 02 - FEMININO", 1, "33030020", 1, 30m, 69.9m },
                    { 3, "2000800", "003", "SEM GTIN", new DateTime(2021, 12, 1, 10, 32, 22, 983, DateTimeKind.Local).AddTicks(7805), "VIP 03 - MASCULINO", 1, "33030020", 1, 30m, 69.9m }
                });

            migrationBuilder.CreateIndex(
                name: "ix_enderecousuario_enderecoid",
                schema: "public",
                table: "enderecousuario",
                column: "enderecoid");

            migrationBuilder.CreateIndex(
                name: "ix_enderecousuario_usuarioid",
                schema: "public",
                table: "enderecousuario",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "ix_produtos_grupoprodutoid",
                schema: "public",
                table: "produtos",
                column: "grupoprodutoid");

            migrationBuilder.CreateIndex(
                name: "ix_vendaformapagamento_formapagamentoid",
                schema: "public",
                table: "vendaformapagamento",
                column: "formapagamentoid");

            migrationBuilder.CreateIndex(
                name: "ix_vendaformapagamento_vendaid",
                schema: "public",
                table: "vendaformapagamento",
                column: "vendaid");

            migrationBuilder.CreateIndex(
                name: "ix_vendaproduto_produtoid",
                schema: "public",
                table: "vendaproduto",
                column: "produtoid");

            migrationBuilder.CreateIndex(
                name: "ix_vendaproduto_vendaid",
                schema: "public",
                table: "vendaproduto",
                column: "vendaid");

            migrationBuilder.CreateIndex(
                name: "ix_vendas_clienteid",
                schema: "public",
                table: "vendas",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "ix_vendas_usuarioid",
                schema: "public",
                table: "vendas",
                column: "usuarioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enderecousuario",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vendaformapagamento",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vendaproduto",
                schema: "public");

            migrationBuilder.DropTable(
                name: "enderecos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "formapagamento",
                schema: "public");

            migrationBuilder.DropTable(
                name: "produtos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vendas",
                schema: "public");

            migrationBuilder.DropTable(
                name: "grupoproduto",
                schema: "public");

            migrationBuilder.DropTable(
                name: "clientes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "usuarios",
                schema: "public");
        }
    }
}
