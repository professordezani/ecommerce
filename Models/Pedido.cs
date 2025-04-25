using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models;

public class Pedido
{
    public int PedidoId { get; set; }
    public Cliente Cliente { get; set; }
    public DateTime Data { get; set; }
    public List<ItemPedido> ItemPedidos { get; set; }
}