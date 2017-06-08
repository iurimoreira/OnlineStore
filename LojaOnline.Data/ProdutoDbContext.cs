using LojaOnline.Domain;
using System.Linq;

namespace LojaOnline.Data
{
    class ProdutoDbContext
    {
        private AcessoDados banco = new AcessoDados();

        public IQueryable<Produto> Produtos()
        {
            return banco.Produtos;
        }

        public bool NovoProduto(Produto Produto)
        {
            banco.Produtos.Add(Produto);
            banco.SaveChanges();
            return true;
        }

        public bool EditarProduto(Produto Produto)
        {

            var ProdutoTemporario = PegarProduto(Produto.ProdutoId);

            ProdutoTemporario.ProdutoId = Produto.ProdutoId;
            ProdutoTemporario.NomeProduto = Produto.NomeProduto;

            banco.SaveChanges();
            return true;
        }

        public bool RemoverProduto(int id)
        {
            Produto Produto = banco.Produtos.Find(id);
            banco.Produtos.Remove(Produto);
            banco.SaveChanges();
            return true;
        }

        public Produto PegarProduto(int id)
        {
            var queryProdutos = banco.Produtos.Where(a => a.ProdutoId == id);
            var Produto = queryProdutos.FirstOrDefault<Produto>();
            return Produto;
        }
    }
}
