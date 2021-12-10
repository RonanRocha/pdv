using PDV.Dominio.Entidades;
using System;

namespace PDV.Dal.Interfaces
{
    public interface IVendaRepositorio : IDisposable
    {
        void Salvar(Venda venda);
    }
}
