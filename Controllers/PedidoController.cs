namespace Ecommerce.Controllers;

using System.Text.Json;
using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

public class PedidoController : Controller
{
    private DbEcommerce db;

    public PedidoController(DbEcommerce db) 
    {
        this.db = db;
    }

    public ActionResult Index()
    {
        Dictionary<int, ItemPedido> carrinho;

        String? carrinho_json = HttpContext.Session.GetString("carrinho");

        if (carrinho_json == null)
            return RedirectToAction("Index", "Produto");
        
        carrinho = JsonSerializer.Deserialize<Dictionary<int, ItemPedido>>(carrinho_json);

        return View(carrinho);
    }

    public ActionResult Update(int id) 
    {
        Dictionary<int, ItemPedido> carrinho;

        String? carrinho_json = HttpContext.Session.GetString("carrinho");

        if (carrinho_json == null)
        {
             carrinho = new Dictionary<int, ItemPedido>();
        }
        else
        {
            carrinho = JsonSerializer.Deserialize<Dictionary<int, ItemPedido>>(carrinho_json);
        }        
        
        if(carrinho.ContainsKey(id))
        {
            // Se o produto já existir no carrinho, incremente a quantidade.
            carrinho[id].Quantidade++;
        }
        else
        {
            // Se o produto não exisir no carrinho, adicione-o, com quantidade = 1.
            Produto produto = db.Produtos.Find(id);
            ItemPedido item = new ItemPedido();
            item.Produto = produto;
            item.Preco = produto.Preco;
            item.Quantidade = 1;
            carrinho.Add(id, item);
        }        

        HttpContext.Session.SetString("carrinho", JsonSerializer.Serialize(carrinho));

        return RedirectToAction("Index");
    }
}