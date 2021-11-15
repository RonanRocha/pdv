using EmissorNF.Dal.Contexto;
using EmissorNF.Dal.Interfaces;
using EmissorNF.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;


namespace EmissorNF.Dal.Repositorios
{
    public class FormaPagamentoRepositorio : IFormaPagamentoRepositorio
    {
        public List<FormaPagamento> RecuperarTodas()
        {
            using(var ctx = new AppDataContext())
            {
                return ctx.FormaPagamentos.Where(x => x.SituacaoEntidade == Dominio.Enums.SituacaoEntidade.Ativo).ToList();
            }
        }
    }
}
