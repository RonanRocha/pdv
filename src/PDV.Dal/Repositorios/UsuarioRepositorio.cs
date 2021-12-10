using PDV.Dal.Contexto;
using PDV.Dal.Interfaces;
using PDV.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace PDV.Dal.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly AppDataContext _contexto;
        private bool _disposed = false;

        public UsuarioRepositorio(AppDataContext contexto)
        {
            _contexto = contexto;     
        }

     
        public List<Cliente> RecuperarTodosClientes()
        {
  
           return _contexto.Usuarios.OfType<Cliente>().Where(x => x.SituacaoEntidade == Dominio.Enums.SituacaoEntidade.Ativo).ToList();
           
        }

        public List<Usuario> RecuperTodos()
        {

          return _contexto.Usuarios.ToList();
            
        }


        ~UsuarioRepositorio() => Dispose();

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
