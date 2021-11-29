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
    public class TesteVendaProduto
    {


        [TestMethod]
        public void Calcular_Totais()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 20.00M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;

            var vendaProduto = new VendaProduto
            {
                Quantidade = 2,
                Produto = produto,
                SituacaoEntidade = EmissorNF.Dominio.Enums.SituacaoEntidade.Ativo,
                ValorUnitario = 20M,
                            
            };

            vendaProduto.Calcular();
           

            Assert.AreEqual(40M, vendaProduto.Subtotal);
            Assert.AreEqual(40M, vendaProduto.Total);
        }

        [TestMethod]
        public void Calcular_Totais_Adicionar_Produtos()
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

            var vendaProduto = new VendaProduto();
            vendaProduto.AdicionarProduto(produto, 2);

            Assert.AreEqual(79.98M, vendaProduto.Subtotal);
            Assert.AreEqual(79.98M, vendaProduto.Total);
        }

        [TestMethod]
        public void Calcular_Descontos()
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

            var vendaProduto = new VendaProduto();
            vendaProduto.AdicionarProduto(produto, 2);
            vendaProduto.AplicarDesconto(10M);

            Assert.AreEqual(79.98M, vendaProduto.Subtotal);
            Assert.AreEqual(59.98M, vendaProduto.Total);
            Assert.AreEqual(20M, vendaProduto.ValorDesconto);
        }


        [TestMethod]
        public void Calcular_Acrescimo()
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

            var vendaProduto = new VendaProduto();
            vendaProduto.AdicionarProduto(produto, 2);
            vendaProduto.AplicarAcrescimo(10M);

            Assert.AreEqual(79.98M, vendaProduto.Subtotal);
            Assert.AreEqual(99.98M, vendaProduto.Total);
            Assert.AreEqual(20M, vendaProduto.ValorAcrescimo);
        }
    }
}
