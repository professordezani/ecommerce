using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models;

public class Pedido
{
    public int PedidoId { get; set; }

    [NotMapped]
    public List<ItemPedido> Itens { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public DateTime Data { get; set; }
}