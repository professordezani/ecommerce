namespace Ecommerce.Models;

public class Produto
{
    public int ProdutoId { get; set; }
    public string Nome { get; set; }
    public string Imagem { get; set; }
    public decimal Preco { get; set; }
    public List<ItemPedido> ItemPedidos { get; set; }
}