using System.Collections.Generic;
namespace mvc1.Models
{
    public class TesteRepository : IRepository
    {
       
       private static Produto[] produtos =new Produto[]{
            new Produto(){ ProdutoId=10, Nome = "Caneta", Categoria = "Material", Preco=0.0M},
            new Produto(){ ProdutoId=20, Nome = "Borracha", Categoria = "Material", Preco=0.0M},
            new Produto(){ ProdutoId=30, Nome = "Estojo", Categoria = "Material", Preco=0.0M}       
       };

          public IEnumerable<Produto> Produtos { get{return produtos;} }
    }





} 