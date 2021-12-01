using PDV.Dominio.Entidades;
using FluentValidation;
using System.Linq;

namespace PDV.Dominio.Validacoes
{
   public class ValidacaoVenda : AbstractValidator<Venda>
   {
        public ValidacaoVenda()
        {
            RuleFor(x => x.Total).GreaterThan(0);
            RuleFor(x => x.Usuario).NotNull();
            RuleFor(x => x.Subtotal).GreaterThan(0);
            RuleFor(x => x.Produtos.Count).GreaterThan(0);
            RuleFor(x => x.Total).Equal(x =>  x.Produtos.Sum(p => p.Total));
            RuleFor(x => x.Subtotal).Equal(x => x.Produtos.Sum(p => p.Subtotal));
            RuleFor(x => x.ValorPago).Equal(x => x.Pagamentos.Sum(pg => pg.ValorPago));
            RuleFor(x => x.ValorAcrescimo).Equal(x => x.Produtos.Sum(p => p.ValorAcrescimo));
            RuleFor(x => x.ValorDesconto).Equal(x => x.Produtos.Sum(p => p.ValorDesconto));
            RuleFor(x => x.ValorTroco).Equal(x => x.ValorPago - x.Total);
        }
   }
}
