using EmissorNF.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorNF.Dominio.Entidades
{
    [Table("enderecos")]
    public class Endereco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string CodigoUF { get; set; }
        public string SiglaUF { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Municipio { get; set; }
        public string Pais { get; set; }
        public string CodigoPais { get; set; }

        public SituacaoEntidade SituacaoEntidade { get; set; }
        public DateTime DataCadastro { get; set; }

        public List<EnderecoUsuario> Usuarios { get; set; }

    }
}
