using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models;

public class ItemPedido
{
    public int ItemPedidoId { get; set; }
    public Produto Produto { get; set; }
    public Pedido Pedido { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
    
    [NotMapped]
    public decimal Total => Preco * Quantidade;
}