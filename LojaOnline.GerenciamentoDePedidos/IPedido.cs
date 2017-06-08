using LojaOnline.GerenciamentoDePedidos.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LojaOnline.GerenciamentoDePedidos
{
    [ServiceContract(Name = "Gerenciador_Versao_1", Namespace = ("http://localhost:58782/v1"))]
    public interface IPedido_UmItem
    {
        [OperationContract]
        string RealizarPedido(ProdutoViewModel produto);

        [OperationContract]
        PedidoViewModel ProximoPedido();

    }

    [ServiceContract(Name = "Gerenciador_Versao_2", Namespace = ("http://localhost:58782/v2"))]
    public interface IPedido_VariosItens
    {
        [OperationContract]
        string RealizarPedido(List<ProdutoViewModel> ListaProdutos);

        [OperationContract]
        PedidoViewModel ProximoPedido();
    }
}
