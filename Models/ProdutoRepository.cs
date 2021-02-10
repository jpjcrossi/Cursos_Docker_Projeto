using System.Collections.Generic;

namespace mvc1.Models
{
    public class ProdutoRepository : IRepository
    {
        private AppDbContext context;
        public ProdutoRepository(AppDbContext ctx)
        {
            this.context = ctx;
        }
        public IEnumerable<Produto> Produtos => this.context.Produtos;
    }
}