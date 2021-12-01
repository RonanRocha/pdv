using PDV.Dal.Contexto;
using PDV.Dal.Interfaces;
using PDV.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;


namespace PDV.Dal.Repositorios
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
