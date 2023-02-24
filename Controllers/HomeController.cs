﻿using Microsoft.AspNetCore.Mvc;
using Poke_Adventures.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Emit;
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

        public ActionResult Attack()
        {
            return View("Battle");
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
        public IActionResult Main()
        {
            return View();
        }

        public IActionResult Battle()
        {
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