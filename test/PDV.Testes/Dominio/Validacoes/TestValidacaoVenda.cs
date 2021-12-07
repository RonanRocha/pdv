using FluentValidation.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDV.Dominio.Entidades;
using PDV.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.Testes.Dominio.Validacoes
{
    [TestClass]
    public class TestValidacaoVenda
    {
        [TestMethod]
        public void Validacao_De_Venda()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = PDV.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;

            var usuario = new Usuario();
            usuario.Cpf = "44882486911";
            usuario.DataCadastro = DateTime.Now;
            usuario.Nome = "Julio Marcos";
            usuario.SituacaoEntidade = PDV.Dominio.Enums.SituacaoEntidade.Ativo;
            usuario.Senha = "as234rv3g234thdu9f";
            usuario.Id = 1;
            usuario.Email = "julio.marcos@email.com";


            var formaPagamento = new FormaPagamento();
            formaPagamento.Id = 1;
            formaPagamento.TipoPagamento = PDV.Dominio.Enums.TipoPagamento.Dinheiro;
            formaPagamento.Descricao = "Dinheiro";
            formaPagamento.DataCadastro = DateTime.Now;
            formaPagamento.Codigo = "01";
            formaPagamento.Parcelas = 1;
            formaPagamento.SituacaoEntidade = PDV.Dominio.Enums.SituacaoEntidade.Ativo;



            var venda = new Venda();
            venda.AdicionarUsuario(usuario);
            venda.AdicionarProduto(produto, 2);
            venda.AdicionarFormaPagamento(formaPagamento, 79.98M);


            ValidacaoVenda validator = new ValidacaoVenda();

            ValidationResult vr = validator.Validate(venda);

            Assert.AreEqual(true, vr.IsValid);



        }


        [TestMethod]
        public void Validacao_De_Venda_Sem_Vendedor()
        {

            var produto = new Produto();

            produto.Codigo = "P193UJD0WEDJ";
            produto.CodigoDeBarras = "SEM GTIN";
            produto.Cest = "1230983";
            produto.Ncm = "14564651";
            produto.Descricao = "Camiseta Basica";
            produto.ValorVenda = 39.99M;
            produto.ValorCompra = 39.99M;
            produto.SituacaoEntidade = PDV.Dominio.Enums.SituacaoEntidade.Ativo;
            produto.Id = 1;




            var formaPagamento = new FormaPagamento();
            formaPagamento.Id = 1;
            formaPagamento.TipoPagamento = PDV.Dominio.Enums.TipoPagamento.Dinheiro;
            formaPagamento.Descricao = "Dinheiro";
            formaPagamento.DataCadastro = DateTime.Now;
            formaPagamento.Codigo = "01";
            formaPagamento.Parcelas = 1;
            formaPagamento.SituacaoEntidade = PDV.Dominio.Enums.SituacaoEntidade.Ativo;



            var venda = new Venda();
            venda.AdicionarProduto(produto, 2);
            venda.AdicionarFormaPagamento(formaPagamento, 79.98M);


            ValidacaoVenda validator = new ValidacaoVenda();

            ValidationResult vr = validator.Validate(venda);

            Assert.AreEqual(false, vr.IsValid);
     



        }


        [TestMethod]
        public void Validacao_De_Venda_Sem_Produtos()
        {



            var usuario = new Usuario();
            usuario.Cpf = "44882486911";
            usuario.DataCadastro = DateTime.Now;
            usuario.Nome = "Julio Marcos";
            usuario.SituacaoEntidade = PDV.Dominio.Enums.SituacaoEntidade.Ativo;
            usuario.Senha = "as234rv3g234thdu9f";
            usuario.Id = 1;
            usuario.Email = "julio.marcos@email.com";


            var formaPagamento = new FormaPagamento();
            formaPagamento.Id = 1;
            formaPagamento.TipoPagamento = PDV.Dominio.Enums.TipoPagamento.Dinheiro;
            formaPagamento.Descricao = "Dinheiro";
            formaPagamento.DataCadastro = DateTime.Now;
            formaPagamento.Codigo = "01";
            formaPagamento.Parcelas = 1;
            formaPagamento.SituacaoEntidade = PDV.Dominio.Enums.SituacaoEntidade.Ativo;



            var venda = new Venda();
            venda.AdicionarUsuario(usuario);
            venda.AdicionarFormaPagamento(formaPagamento, 79.98M);


            ValidacaoVenda validator = new ValidacaoVenda();

            ValidationResult vr = validator.Validate(venda);

            Assert.AreEqual(false, vr.IsValid);



        }






    }
}
