using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.Dominio.Entidades
{
    [Table("clientes")]
    public class Cliente : Usuario
    {

        public string Cnpj { get; set; }
 
    }
}
