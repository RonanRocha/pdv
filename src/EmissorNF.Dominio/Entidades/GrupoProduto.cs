using EmissorNF.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorNF.Dominio.Entidades
{

    [Table("grupoproduto")]
    public class GrupoProduto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public SituacaoEntidade SituacaoEntidade { get; set; }
        public DateTime DataCadastro { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}
