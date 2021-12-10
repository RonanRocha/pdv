using PDV.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.Dal.Interfaces
{
    public interface IVendaProdutoRepositorio
    {
        void Salvar(VendaProduto vendaProduto);
    }
}
