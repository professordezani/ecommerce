using System.Text.Json;
using System.Transactions;
using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public class ClienteController:  Controller
{
    private DbEcommerce db;

    public ClienteController(DbEcommerce db)
    {
        this.db = db;
    }

    public ActionResult Create()
    {
        String? carrinho_json = HttpContext.Session.GetString("carrinho");

        if (string.IsNullOrEmpty(carrinho_json))
            return RedirectToAction("Index", "Produto");

        return View(JsonSerializer.Deserialize<Dictionary<int, ItemPedido>>(carrinho_json));
    }

    [HttpPost]
    public ActionResult Create(Cliente cliente)
    {
        // TOD: Implementar finalização da compra para o cliente.
        return RedirectToAction("Index", "Produto");
    }
}