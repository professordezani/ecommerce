namespace Ecommerce.Models;

public class ItemPedido
{
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; }
    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
}