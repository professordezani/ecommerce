using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public class ProdutoController : Controller
{
    public ActionResult Index()
    {
        return View(); // Views/Produto/Index.cshtml
    }
}