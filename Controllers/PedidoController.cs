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
        String? carrinho_json = HttpContext.Session.GetString("carrinho");

        if (string.IsNullOrEmpty(carrinho_json))
            return RedirectToAction("Index", "Produto");

        return View(JsonSerializer.Deserialize<Dictionary<int, ItemPedido>>(carrinho_json));
    }

    private Dictionary<int, ItemPedido> Load() 
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

        return carrinho;
    }

    private void Save(Dictionary<int, ItemPedido> carrinho) 
    {
        string dados = JsonSerializer.Serialize(carrinho);
        HttpContext.Session.SetString("carrinho", dados);
    }

    public ActionResult Update(int id) 
    {
        var carrinho = Load();
        
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

        Save(carrinho);

        return RedirectToAction("Index");
    }

    public ActionResult UpdateQuantidade(int id, [FromQuery]string operacao) 
    {
        var carrinho = Load();     
        
        if(carrinho.ContainsKey(id))
        {
            if(operacao == "incrementar")
            {
                carrinho[id].Quantidade++;
            }
            else if(operacao == "decrementar") 
            {
                carrinho[id].Quantidade--;

                if(carrinho[id].Quantidade == 0)
                    carrinho.Remove(id);
            }
        }     

        Save(carrinho);

        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id) 
    {
        var carrinho = Load();     
        
        if(carrinho.ContainsKey(id))
        {
            carrinho.Remove(id);
        }     

        Save(carrinho);

        if(carrinho.Keys.Count == 0) {
            return RedirectToAction("Index", "Produto");
        }

        return RedirectToAction("Index");
    }
}