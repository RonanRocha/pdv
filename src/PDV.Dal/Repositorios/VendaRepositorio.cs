using PDV.Dal.Contexto;
using PDV.Dal.Interfaces;
using PDV.Dominio.Entidades;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace PDV.Dal.Repositorios
{
    public class VendaRepositorio : IVendaRepositorio
    {

        private readonly AppDataContext _contexto;
        private bool _disposed = false;

        public VendaRepositorio(AppDataContext contexto)
        {
            _contexto = contexto;
        }

  

        public void Salvar(Venda venda)
        {
            _contexto.Entry(venda).State = EntityState.Added;
            
        }


        ~VendaRepositorio() => Dispose();

        public void Dispose()
        {
            if (!_disposed)
            {
                _contexto.Dispose();
                GC.SuppressFinalize(this);
            }
        }




    }
}
