using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public class ProdutoController : Controller
{
    public ActionResult Index()
    {
        // No futuro, conectaremos com o BD
        List<Produto> produtos = new List<Produto>();
        produtos.Add(new Produto { ProdutoId = 1, Nome = "Banana" });
        produtos.Add(new Produto { ProdutoId = 2, Nome = "Cenoura" });
        produtos.Add(new Produto { ProdutoId = 3, Nome = "Abacate" });

        return View(produtos); // Views/Produto/Index.cshtml
    }
}