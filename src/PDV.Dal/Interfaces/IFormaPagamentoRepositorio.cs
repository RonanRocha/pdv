using PDV.Dominio.Entidades;
using System.Collections.Generic;


namespace PDV.Dal.Interfaces
{
    public interface IFormaPagamentoRepositorio
    {
        List<FormaPagamento> RecuperarTodas();
    }
}
