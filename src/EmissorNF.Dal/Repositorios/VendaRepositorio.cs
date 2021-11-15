using EmissorNF.Dal.Contexto;
using EmissorNF.Dal.Interfaces;
using EmissorNF.Dominio.Entidades;


namespace EmissorNF.Dal.Repositorios
{
    public class VendaRepositorio : IVendaRepositorio
    {
        public void Salvar(Venda venda)
        {
            using (var ctx = new AppDataContext())
            {


                ctx.Vendas.Add(venda);

                foreach (var vendaPagamento in venda.Pagamentos)
                {
                    ctx.FormaPagamentos.Attach(vendaPagamento.FormaPagamento);
                }

                foreach (var vendaProduto in venda.Produtos)
                {
                    ctx.Produtos.Attach(vendaProduto.Produto);
                }

                ctx.Usuarios.Attach(venda.Usuario);

                if(venda.Cliente != null)
                {
                    ctx.Usuarios.Attach(venda.Cliente);
                }
                

                ctx.SaveChanges();
            }
        }
    }
}
