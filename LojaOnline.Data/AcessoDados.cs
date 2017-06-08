using LojaOnline.Domain;
using System.Data.Entity;

namespace LojaOnline.Data
{
    class AcessoDados : DbContext
    {
        public AcessoDados() : base("DefaultConnection")
        {
            Database.SetInitializer<AcessoDados>(new CreateDatabaseIfNotExists<AcessoDados>());

            Database.Initialize(false);
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
