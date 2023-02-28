using Microsoft.AspNetCore.Mvc;
using Poke_Adventures.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Poke_Adventures.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Attack()
        {
            return View("Battle");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Main()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Battle(string Move1)
        {
            AttackFunction.ApplyDamage();
            return View();
        }

        public IActionResult Jungle()
        {
            return View();
        }

        public IActionResult Training()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
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