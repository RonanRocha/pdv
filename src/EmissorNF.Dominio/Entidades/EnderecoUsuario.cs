using EmissorNF.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorNF.Dominio.Entidades
{
    [Table("enderecousuario")]
    public class EnderecoUsuario
    {
        public int Id { get; set; }
        public int EnderecoId { get; set; }
        public int UsuarioId { get; set; }
        public Endereco Endereco { get; set; }
        public Usuario Usuario { get; set; }
        public SituacaoEntidade SituacaoEntidade { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
