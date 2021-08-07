using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorNF.Cliente.ViewModels
{
    public class ParcelaViewModel
    {
        public int Valor { get; set; }
        public string Descricao { get; set; }

        public static List<ParcelaViewModel> GerarParcelas(int quantidade)
        {
            var list = new List<ParcelaViewModel>();

            int count = 1;

            while(count <= quantidade)
            {
                list.Add(new ParcelaViewModel
                {
                    Valor = count,
                    Descricao = count.ToString()
                });

                count++;
            }

            return list;
        }
    }
}
