using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LojaOnline.GerenciamentoDePedidos.Models.ViewModels
{
    [DataContract]
    public class PedidoViewModel
    {
        [DataMember]
        public int PedidoId { get; set; }

        [DataMember]
        public virtual ICollection<ProdutoViewModel> Produtos { get; set; }
    }
}