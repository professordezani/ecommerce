using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data;

public class DbEcommerce : DbContext
{
    public DbEcommerce(DbContextOptions options) : base(options) {}     

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<ItemPedido> ItemPedidos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Produto>().HasData(
            new Produto { ProdutoId = 1, Nome = "Manga", Imagem="manga.jpg", Preco = 7.50M },
            new Produto { ProdutoId = 2, Nome = "Banana", Imagem="banana.jpg", Preco = 4.0M},
            new Produto { ProdutoId = 3, Nome = "Goiaba", Imagem="goiaba.jpg", Preco = 12.0M },
            new Produto { ProdutoId = 4, Nome = "Granola", Imagem="granola.jpg", Preco = 22.0M },
            new Produto { ProdutoId = 5, Nome = "Maçã", Imagem="maca.jpg", Preco = 8.50M },
            new Produto { ProdutoId = 6, Nome = "Melancia", Imagem="melancia.jpg", Preco = 15.0M },
            new Produto { ProdutoId = 7, Nome = "Uva", Imagem="uva.jpg", Preco = 20.0M }
        );        
    }
}
