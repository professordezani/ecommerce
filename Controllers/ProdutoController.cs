using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public class ProdutoController : Controller
{
    public ActionResult Index()
    {
        // No futuro, conectaremos com o BD
        List<Produto> produtos = new List<Produto>();
        produtos.Add(new Produto { ProdutoId = 1, Nome = "Manga", Imagem="manga.jpg", Preco = 10 });
        produtos.Add(new Produto { ProdutoId = 2, Nome = "Banana", Imagem="banana.jpg", Preco = 5});
        produtos.Add(new Produto { ProdutoId = 3, Nome = "Goiaba", Imagem="goiaba.jpg", Preco = 18 });

        return View(produtos); // Views/Produto/Index.cshtml
    }

    public ActionResult Detalhes(int id)
    {
        return View();
    }
}