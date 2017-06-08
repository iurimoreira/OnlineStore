using System.Runtime.Serialization;

namespace LojaOnline.GerenciamentoDePedidos.Models.ViewModels
{
    [DataContract]
    public class ProdutoViewModel
    {
        [DataMember]
        public int ProdutoId { get; set; }
        [DataMember]
        public string NomeProduto { get; set; }
    }
}