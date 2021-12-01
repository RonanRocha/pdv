using PDV.Dal.Contexto;
using PDV.Dal.Interfaces;
using PDV.Dominio.Entidades;


namespace PDV.Dal.Repositorios
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
