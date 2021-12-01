using PDV.Dominio.Enums;
using System;
using System.Collections.Generic;


namespace PDV.Dominio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public List<EnderecoUsuario> Enderecos { get; set; }
        public SituacaoEntidade SituacaoEntidade { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
