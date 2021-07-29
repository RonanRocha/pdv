using EmissorNF.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorNF.Testes.Dominio
{
    [TestClass]
    public class TesteVenda
    {

        [TestMethod]
        public void Calcular_Totais_Venda()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;

            var venda = new Venda();
            venda.AdicionarProduto(produto, 2);

            Assert.AreEqual(79.98M, venda.Total);
            Assert.AreEqual(79.98M, venda.Subtotal);
            Assert.AreEqual(0M, venda.ValorDesconto);
            Assert.AreEqual(0M, venda.ValorAcrescimo);
       

        }

        [TestMethod]
        public void Calcular_Totais_Venda_Produto_Nulo()
        {

 
            var venda = new Venda();
            venda.AdicionarProduto(null, 2);

            Assert.AreEqual(0M, venda.Total);
            Assert.AreEqual(0M, venda.Subtotal);
            Assert.AreEqual(0M, venda.ValorDesconto);
            Assert.AreEqual(0M, venda.ValorAcrescimo);


        }

        [TestMethod]
        public void Calcular_Totais_Venda_Quantidade_Produto_Zerada()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;

            var venda = new Venda();
            venda.AdicionarProduto(produto, 0);



            Assert.AreEqual(0M, venda.Total);
            Assert.AreEqual(0M, venda.Subtotal);
            Assert.AreEqual(0M, venda.ValorDesconto);
            Assert.AreEqual(0M, venda.ValorAcrescimo);


        }

        [TestMethod]
        public void Calcular_Totais_Venda_Quantidade_Produto_Negativo()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;

            var venda = new Venda();
            venda.AdicionarProduto(produto, -5);



            Assert.AreEqual(0M, venda.Total);
            Assert.AreEqual(0M, venda.Subtotal);
            Assert.AreEqual(0M, venda.ValorDesconto);
            Assert.AreEqual(0M, venda.ValorAcrescimo);


        }

        [TestMethod]
        public void Calcular_Totais_Venda_Metodo()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;

            var venda = new Venda();
            venda.AdicionarProduto(produto, 1);
            venda.CalcularTotais();

            Assert.AreEqual(39.99M, venda.Total);
            Assert.AreEqual(39.99M, venda.Subtotal);
            Assert.AreEqual(0M, venda.ValorDesconto);
            Assert.AreEqual(0M, venda.ValorAcrescimo);


        }

        [TestMethod]
        public void Calcular_Totais_Venda_Acrescimo()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;

            var venda = new Venda();
            venda.AdicionarProduto(produto, 1);
            venda.AplicarAcrescimo(10M);

            Assert.AreEqual(49.99M, venda.Total);
            Assert.AreEqual(39.99M, venda.Subtotal);
            Assert.AreEqual(0M, venda.ValorDesconto);
            Assert.AreEqual(10M, venda.ValorAcrescimo);


        }

        [TestMethod]
        public void Calcular_Totais_Venda_Acrescimo_2_Produtos()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;

            var venda = new Venda();
            venda.AdicionarProduto(produto, 2);
            venda.AplicarAcrescimo(10M);

            Assert.AreEqual(89.98M, venda.Total);
            Assert.AreEqual(79.98M, venda.Subtotal);
            Assert.AreEqual(0M, venda.ValorDesconto);
            Assert.AreEqual(10M, venda.ValorAcrescimo);


        }

        [TestMethod]
        public void Calcular_Totais_Venda_Acrescimo_2_Produtos_Valores_Diferentes()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;


            var segundoProduto = new Produto();

            segundoProduto.Codigo = "P123123WEDJ";
            segundoProduto.CodigoDeBarras = "SEM GTIN";
            segundoProduto.Cest = "56780734";
            segundoProduto.Ncm = "12354577";
            segundoProduto.Descricao = "Camiseta Nike";
            segundoProduto.ValorVenda = 19.99M;
            segundoProduto.ValorCompra = 19.99M;
            segundoProduto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            segundoProduto.Id = 2;

            var venda = new Venda();
            venda.AdicionarProduto(produto, 2);
            venda.AdicionarProduto(segundoProduto, 1);
            venda.AplicarAcrescimo(10M);

            Assert.AreEqual(109.97M, venda.Total);
            Assert.AreEqual(99.97M, venda.Subtotal);
            Assert.AreEqual(0M, venda.ValorDesconto);
            Assert.AreEqual(10M, venda.ValorAcrescimo);


        }

        [TestMethod]
        public void Calcular_Totais_Venda_2_Produtos_1_Inativo()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;


            var segundoProduto = new Produto();

            segundoProduto.Codigo = "P123123WEDJ";
            segundoProduto.CodigoDeBarras = "SEM GTIN";
            segundoProduto.Cest = "56780734";
            segundoProduto.Ncm = "12354577";
            segundoProduto.Descricao = "Camiseta Nike";
            segundoProduto.ValorVenda = 19.99M;
            segundoProduto.ValorCompra = 19.99M;
            segundoProduto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Inativo;
            segundoProduto.Id = 2;

            var venda = new Venda();
            venda.AdicionarProduto(produto, 1);
            venda.AdicionarProduto(segundoProduto, 1);

            Assert.AreEqual(39.99M, venda.Total);
            Assert.AreEqual(39.99M, venda.Subtotal);
            Assert.AreEqual(0M, venda.ValorDesconto);
            Assert.AreEqual(0M, venda.ValorAcrescimo);


        }

        [TestMethod]
        public void Calcular_Totais_Venda_Desconto()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;

            var venda = new Venda();
            venda.AdicionarProduto(produto, 1);
            venda.AplicarDesconto(10M);

            Assert.AreEqual(29.99M, venda.Total);
            Assert.AreEqual(39.99M, venda.Subtotal);
            Assert.AreEqual(10M, venda.ValorDesconto);
            Assert.AreEqual(0M, venda.ValorAcrescimo);


        }

        [TestMethod]
        public void Calcular_Totais_Venda_Desconto_2_Produtos()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;

            var venda = new Venda();
            venda.AdicionarProduto(produto, 2);
            venda.AplicarDesconto(10M);

            Assert.AreEqual(69.98M, venda.Total);
            Assert.AreEqual(79.98M, venda.Subtotal);
            Assert.AreEqual(10M, venda.ValorDesconto);
            Assert.AreEqual(0M, venda.ValorAcrescimo);


        }

        [TestMethod]
        public void Calcular_Totais_Venda_Desconto_2_Produtos_Valores_Diferentes()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;


            var segundoProduto = new Produto();

            segundoProduto.Codigo = "P123123WEDJ";
            segundoProduto.CodigoDeBarras = "SEM GTIN";
            segundoProduto.Cest = "56780734";
            segundoProduto.Ncm = "12354577";
            segundoProduto.Descricao = "Camiseta Nike";
            segundoProduto.ValorVenda = 19.99M;
            segundoProduto.ValorCompra = 19.99M;
            segundoProduto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            segundoProduto.Id = 2;

            var venda = new Venda();
            venda.AdicionarProduto(produto, 2);
            venda.AdicionarProduto(segundoProduto, 1);
            venda.AplicarDesconto(10M);

            Assert.AreEqual(89.97M, venda.Total);
            Assert.AreEqual(99.97M, venda.Subtotal);
            Assert.AreEqual(10M, venda.ValorDesconto);
            Assert.AreEqual(0M, venda.ValorAcrescimo);


        }

        [TestMethod]
        public void Calcular_Totais_Venda_Desconto_Acrescimo()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;

            var venda = new Venda();
            venda.AdicionarProduto(produto, 1);
            venda.AplicarDesconto(10M);
            venda.AplicarAcrescimo(5M);

            Assert.AreEqual(34.99M, venda.Total);
            Assert.AreEqual(39.99M, venda.Subtotal);
            Assert.AreEqual(10M, venda.ValorDesconto);
            Assert.AreEqual(5M, venda.ValorAcrescimo);


        }

        [TestMethod]
        public void Calcular_Totais_Venda_Desconto_Acrescimo_2_Produtos()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;

            var venda = new Venda();
            venda.AdicionarProduto(produto, 2);
            venda.AplicarDesconto(10M);
            venda.AplicarAcrescimo(5M);

            Assert.AreEqual(74.98M, venda.Total);
            Assert.AreEqual(79.98M, venda.Subtotal);
            Assert.AreEqual(10M, venda.ValorDesconto);
            Assert.AreEqual(5M, venda.ValorAcrescimo);


        }

        [TestMethod]
        public void Calcular_Totais_Venda_Desconto_Acrescimo_2_Produtos_Valores_Diferentes()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;


            var segundoProduto = new Produto();

            segundoProduto.Codigo = "P123123WEDJ";
            segundoProduto.CodigoDeBarras = "SEM GTIN";
            segundoProduto.Cest = "56780734";
            segundoProduto.Ncm = "12354577";
            segundoProduto.Descricao = "Camiseta Nike";
            segundoProduto.ValorVenda = 19.99M;
            segundoProduto.ValorCompra = 19.99M;
            segundoProduto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            segundoProduto.Id = 2;

            var venda = new Venda();
            venda.AdicionarProduto(produto, 2);
            venda.AdicionarProduto(segundoProduto, 1);
            venda.AplicarDesconto(10M);
            venda.AplicarAcrescimo(5M);

            Assert.AreEqual(94.97M, venda.Total);
            Assert.AreEqual(99.97M, venda.Subtotal);
            Assert.AreEqual(10M, venda.ValorDesconto);
            Assert.AreEqual(5M, venda.ValorAcrescimo);


        }

        [TestMethod]
        public void Calcular_Valor_Pago_Troco_Venda()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;

            var formaPagamento = new FormaPagamento();
            formaPagamento.Descricao = "Dinheiro";
            formaPagamento.Codigo = "01";
            formaPagamento.DataCadastro = DateTime.Now;
            formaPagamento.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            formaPagamento.Parcelas = 1;
            


     

            var venda = new Venda();
            venda.AdicionarProduto(produto, 2);
            venda.AdicionarFormaPagamento(formaPagamento, 100);


            Assert.AreEqual(79.98M, venda.Total);
            Assert.AreEqual(79.98M, venda.Subtotal);
            Assert.AreEqual(0M, venda.ValorDesconto);
            Assert.AreEqual(0M, venda.ValorAcrescimo);
            Assert.AreEqual(20.02M, venda.ValorTroco);
            Assert.AreEqual(100M, venda.ValorPago);


        }

        [TestMethod]
        public void Calcular_Valor_Pago_Troco_Venda_2_Metodos_Pagamento()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;

            var formaPagamento = new FormaPagamento();
            formaPagamento.Descricao = "Dinheiro";
            formaPagamento.Codigo = "01";
            formaPagamento.DataCadastro = DateTime.Now;
            formaPagamento.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            formaPagamento.Parcelas = 1;

            var segundaFormaPagamento = new FormaPagamento();
            segundaFormaPagamento.Descricao = "Debito";
            segundaFormaPagamento.Codigo = "02";
            segundaFormaPagamento.DataCadastro = DateTime.Now;
            segundaFormaPagamento.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            segundaFormaPagamento.Parcelas = 1;





            var venda = new Venda();
            venda.AdicionarProduto(produto, 2);
            venda.AdicionarFormaPagamento(formaPagamento, 40);
            venda.AdicionarFormaPagamento(segundaFormaPagamento, 50);


            Assert.AreEqual(79.98M, venda.Total);
            Assert.AreEqual(79.98M, venda.Subtotal);
            Assert.AreEqual(0M, venda.ValorDesconto);
            Assert.AreEqual(0M, venda.ValorAcrescimo);
            Assert.AreEqual(10.02M, venda.ValorTroco);
            Assert.AreEqual(90M, venda.ValorPago);


        }


    }
}
