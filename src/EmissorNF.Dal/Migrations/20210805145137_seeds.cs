using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmissorNF.Dal.Migrations
{
    public partial class seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tipopagamento",
                schema: "public",
                table: "formapagamento",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                schema: "public",
                table: "formapagamento",
                columns: new[] { "id", "codigo", "datacadastro", "descricao", "parcelas", "situacaoentidade", "tipopagamento" },
                values: new object[,]
                {
                    { 1, "04", new DateTime(2021, 8, 5, 11, 51, 36, 70, DateTimeKind.Local).AddTicks(1568), "Maestro", 1, 1, 1 },
                    { 2, "04", new DateTime(2021, 8, 5, 11, 51, 36, 70, DateTimeKind.Local).AddTicks(2197), "Visa Débito", 1, 1, 1 },
                    { 3, "04", new DateTime(2021, 8, 5, 11, 51, 36, 70, DateTimeKind.Local).AddTicks(2204), "Elo Débito", 1, 1, 1 },
                    { 4, "01", new DateTime(2021, 8, 5, 11, 51, 36, 70, DateTimeKind.Local).AddTicks(2206), "Dinheiro", 1, 1, 2 },
                    { 5, "03", new DateTime(2021, 8, 5, 11, 51, 36, 70, DateTimeKind.Local).AddTicks(2256), "Master Crédito", 12, 1, 0 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "grupoproduto",
                columns: new[] { "id", "datacadastro", "descricao", "situacaoentidade" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 5, 11, 51, 36, 66, DateTimeKind.Local).AddTicks(1493), "Perfumes", 1 },
                    { 2, new DateTime(2021, 8, 5, 11, 51, 36, 67, DateTimeKind.Local).AddTicks(6690), "Sabonetes", 1 },
                    { 3, new DateTime(2021, 8, 5, 11, 51, 36, 67, DateTimeKind.Local).AddTicks(6723), "Essencias", 1 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "usuarios",
                columns: new[] { "id", "cpf", "datacadastro", "email", "nome", "senha", "situacaoentidade" },
                values: new object[,]
                {
                    { 1, "388477898", new DateTime(2021, 8, 5, 11, 51, 36, 69, DateTimeKind.Local).AddTicks(8884), "ronan.rochasouza@gmail.com", "Ronan Rocha", "1234", 1 },
                    { 2, "67371822080", new DateTime(2021, 8, 5, 11, 51, 36, 69, DateTimeKind.Local).AddTicks(9456), "mvp@gmail.com", "Marcos Poli", "1234", 1 },
                    { 3, "69947008010", new DateTime(2021, 8, 5, 11, 51, 36, 69, DateTimeKind.Local).AddTicks(9462), "michael@gmail.com", "Michael", "1234", 1 }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "produtos",
                columns: new[] { "id", "cest", "codigo", "codigodebarras", "datacadastro", "descricao", "grupoprodutoid", "ncm", "situacaoentidade", "valorcompra", "valorvenda" },
                values: new object[,]
                {
                    { 1, "2000800", "001", "SEM GTIN", new DateTime(2021, 8, 5, 11, 51, 36, 69, DateTimeKind.Local).AddTicks(6268), "VIP 01 - MASCULINO", 1, "33030020", 1, 30m, 69.9m },
                    { 2, "2000800", "002", "SEM GTIN", new DateTime(2021, 8, 5, 11, 51, 36, 69, DateTimeKind.Local).AddTicks(6888), "VIP 02 - FEMININO", 1, "33030020", 1, 30m, 69.9m },
                    { 3, "2000800", "003", "SEM GTIN", new DateTime(2021, 8, 5, 11, 51, 36, 69, DateTimeKind.Local).AddTicks(6897), "VIP 03 - MASCULINO", 1, "33030020", 1, 30m, 69.9m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "formapagamento",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "formapagamento",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "formapagamento",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "formapagamento",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "formapagamento",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "grupoproduto",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "grupoproduto",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "produtos",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "produtos",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "produtos",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "usuarios",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "usuarios",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "usuarios",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "grupoproduto",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "tipopagamento",
                schema: "public",
                table: "formapagamento");
        }
    }
}
