using PDV.Dal.Contexto;
using PDV.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.Dal.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDataContext _contexto;

        public UnitOfWork(AppDataContext contexto)
        {
            _contexto = contexto;
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }
    }
}
