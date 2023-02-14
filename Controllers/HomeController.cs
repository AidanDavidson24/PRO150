using Microsoft.AspNetCore.Mvc;
using Poke_Adventures.Models;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Poke_Adventures.Controllers
{
    public class HomeController : Controller
    {
        PokemonElements PK;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //PK.Name;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}