using LojaOnline.Data;
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
    public class Pedido : IPedido_UmItem, IPedido_VariosItens
    {
        private PedidoDbContext dao = new PedidoDbContext();
        private Service.PedidoFilaService fila = new Service.PedidoFilaService();


        public string RealizarPedido(ProdutoViewModel produto)
        {

            Service.PedidoFilaService fila = new Service.PedidoFilaService();

            Produto objProduto = new Produto();
            objProduto.idProduto = produto.idProduto;
            objProduto.Quantidade = produto.Quantidade;

            List<Produto> ListaProdutos = new List<Produto>();

            ListaProdutos.Add(objProduto);

            Loja.Domain.Pedido objPedido = new Loja.Domain.Pedido();
            objPedido.Produtos = ListaProdutos;
            objPedido.PedidoEmpacotado = false;
            objPedido.PedidoEnviado = false;



            var resposta = dao.AdicionarPedido(objPedido);

            if (resposta.ToString() == "True")
            {
                fila.AdicionarPedidoAFila(objPedido.idPedido);
                return "Pedido Realizado com Sucesso , aguardando colobarodores para mudar status do seu pedido";

            }
            else
            {
                return "OPS.. Ocorreu algum erro.";
            }

        }




        public string RealizarPedido(List<ProdutoViewModel> ListaProdutos)
        {
            List<Produto> ProdutosLista = new List<Produto>();

            foreach (var item in ListaProdutos)
            {
                Produto produto = new Produto();
                produto.idProduto = item.idProduto;
                produto.NomeProduto = item.NomeProduto;
                produto.Quantidade = item.Quantidade;

                ProdutosLista.Add(produto);

            }

            Loja.Domain.Pedido objPedido = new Loja.Domain.Pedido();
            objPedido.Produtos = ProdutosLista;
            objPedido.PedidoEmpacotado = false;
            objPedido.PedidoEnviado = false;

            var resposta = dao.AdicionarPedido(objPedido);

            if (resposta.ToString() == "True")
            {
                fila.AdicionarPedidoAFila(objPedido.idPedido);
                return "Pedido Realizado com Sucesso , aguardando colobarodores para mudar status do seu pedido";
            }
            else
            {
                return "OPS.. Ocorreu algum erro.";
            }




        }
        public PedidoViewModel ProximoPedido()
        {

            PedidoViewModel pedido = new PedidoViewModel();

            pedido = fila.PegarProximoPedido();



            return pedido;



        }

    }
}
