using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public class ProdutoController : Controller
{
    // atributos:
    List<Produto> produtos = new List<Produto>();

    public ProdutoController()
    {
        produtos.Add(new Produto { ProdutoId = 1, Nome = "Manga", Imagem="manga.jpg", Preco = 10 });
        produtos.Add(new Produto { ProdutoId = 2, Nome = "Banana", Imagem="banana.jpg", Preco = 5});
        produtos.Add(new Produto { ProdutoId = 3, Nome = "Goiaba", Imagem="goiaba.jpg", Preco = 18 });
    }

    public ActionResult Index()
    {
        return View(produtos); // Views/Produto/Index.cshtml
    }

    public ActionResult Detalhes(int id)
    {
        foreach(var produto in produtos)
        {
            if(produto.ProdutoId == id) {
                return View(produto);
            }
        }

        return NotFound();
    }
}