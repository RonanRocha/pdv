using EmissorNF.Dominio.Entidades;
using System.Collections.Generic;


namespace EmissorNF.Dal.Interfaces
{
    public interface IFormaPagamentoRepositorio
    {
        List<FormaPagamento> RecuperarTodas();
    }
}
