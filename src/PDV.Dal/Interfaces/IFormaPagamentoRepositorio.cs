using PDV.Dominio.Entidades;
using System;
using System.Collections.Generic;


namespace PDV.Dal.Interfaces
{
    public interface IFormaPagamentoRepositorio : IDisposable
    {
        List<FormaPagamento> RecuperarTodas();
    }
}
