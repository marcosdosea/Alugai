using Microsoft.AspNetCore.Mvc;

namespace AlugaiWEB.Controllers
{
    public class MeusDadosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
