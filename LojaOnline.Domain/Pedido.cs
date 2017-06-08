using System.Collections.Generic;

namespace LojaOnline.Domain
{
    public class Pedido
    {
        public int PedidoId { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
