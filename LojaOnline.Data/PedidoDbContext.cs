using LojaOnline.Domain;
using System.Linq;

namespace LojaOnline.Data
{
    public class PedidoDbContext
    {
        private AcessoDados banco = new AcessoDados();

        public IQueryable<Pedido> Pedidos()
        {
            return banco.Pedidos;
        }

        public bool NovoPedido(Pedido pedido)
        {
            banco.Pedidos.Add(pedido);
            banco.SaveChanges();
            return true;
        }

        public bool EditarPedido(Pedido pedido)
        {

            var pedidoTemporario = PegarPedido(pedido.PedidoId);

            pedidoTemporario.PedidoId = pedido.PedidoId;
            pedidoTemporario.Produtos = pedido.Produtos;

            banco.SaveChanges();
            return true;
        }

        public bool RemoverPedido(int id)
        {
            Pedido pedido = banco.Pedidos.Find(id);
            banco.Pedidos.Remove(pedido);
            banco.SaveChanges();
            return true;
        }

        public Pedido PegarPedido(int id)
        {
            var queryPedidos = banco.Pedidos.Where(a => a.PedidoId == id);
            var pedido = queryPedidos.FirstOrDefault<Pedido>();
            return pedido;
        }
    }
}
