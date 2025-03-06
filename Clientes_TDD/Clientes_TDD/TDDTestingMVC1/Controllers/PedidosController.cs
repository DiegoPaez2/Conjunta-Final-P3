using Microsoft.AspNetCore.Mvc;

namespace TDDTestingMVC1.Controllers
{
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
