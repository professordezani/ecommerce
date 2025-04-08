using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public class ProdutoController : Controller
{
    private DbEcommerce db;

    public ProdutoController(DbEcommerce db)
    {
        this.db = db;
    }

    public ActionResult Index()
    {
        return View(db.Produtos.ToList()); // Views/Produto/Index.cshtml
    }

    public ActionResult Detalhes(int id)
    {
        // SELECT * FROM Produtos WHERE ProdutoId = id
        // Produto produto = db.Produtos.Where(p => p.ProdutoId == id).First();
        Produto produto = db.Produtos.SingleOrDefault(p => p.ProdutoId == id);

        return View(produto);
    }
}