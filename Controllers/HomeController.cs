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

        public IActionResult Main()
        {
            var pokemon = Pokemon.LoadAllPokemon();

            PlayerModel.AddPokemon("voltorb", 5);
            PlayerModel.AddPokemon("miltank", 5);
            var location = LoadLocation.LoadAllLocations();
            Random rand = new Random();

            PokemonModel.ResetPK();
            PokemonModel.MakeEnemy("Easy");
            return View();
        }

        public IActionResult Battle()
        {
           
            return View();
        }

        public IActionResult Move1()
        {
            if(PokemonModel.PlayerHP <= 0 || PokemonModel.EnemyHP <= 0)
            {
                return RedirectToAction("Main");
            }
            else
            {
                string PKID = PlayerModel.PlayerTeam[0].Name;
                AttackFunction.Damage(PKID, PlayerModel.PlayerTeam[1].Name, 0);
                AttackFunction.EnemyAttack(PokemonModel.PlayerHP);
                return RedirectToAction("Battle");
            }
        }

        public IActionResult Move2()
        {
            if (PokemonModel.PlayerHP <= 0 || PokemonModel.EnemyHP <= 0)
            {
                return RedirectToAction("Main");
                
            }
            else
            {
                string PKID = PlayerModel.PlayerTeam[0].Name;
                AttackFunction.Damage(PKID, PlayerModel.PlayerTeam[1].Name, 1);
                AttackFunction.EnemyAttack(PokemonModel.PlayerHP);
                return RedirectToAction("Battle");
            }
        }

        public IActionResult Move3()
        {
            if (PokemonModel.PlayerHP <= 0 || PokemonModel.EnemyHP <= 0)
            {
                return RedirectToAction("Main");
            }
            else
            {
                string PKID = PlayerModel.PlayerTeam[0].Name;
                AttackFunction.Damage(PKID, PlayerModel.PlayerTeam[1].Name, 2);
                AttackFunction.EnemyAttack(PokemonModel.PlayerHP);
                return RedirectToAction("Battle");
            }
        }
        public IActionResult Move4()
        {
            if (PokemonModel.PlayerHP <= 0 || PokemonModel.EnemyHP <= 0)
            {
                return RedirectToAction("Main");
            }
            else
            {
                string PKID = PlayerModel.PlayerTeam[0].Name;
                AttackFunction.Damage(PKID, PlayerModel.PlayerTeam[1].Name, 4);
                AttackFunction.EnemyAttack(PokemonModel.PlayerHP);
                return RedirectToAction("Battle");
            }
        }

        public IActionResult JungleMove1()
        {
            string PKID = PlayerModel.PlayerTeam[0].Name;
            string? other = Routes.otherPokemon.Name;
            AttackFunction.WildDamage(PokemonModel.WildHP.Value,PKID, other, 0);
            return RedirectToAction("Jungle");
        }

        public IActionResult JungleMove2()
        {
            string PKID = PlayerModel.PlayerTeam[0].Name;
            AttackFunction.WildDamage(PokemonModel.WildHP.Value, PKID, Routes.otherPokemon.Name, 1);
            return RedirectToAction("Jungle");
        }

        public IActionResult JungleMove3()
        {
            string PKID = PlayerModel.PlayerTeam[0].Name;
            AttackFunction.WildDamage(PokemonModel.WildHP.Value,PKID, Routes.otherPokemon.Name, 2);
            return RedirectToAction("Jungle");
        }

        public IActionResult JungleMove4()
        {
            string PKID = PlayerModel.PlayerTeam[0].Name;
            AttackFunction.WildDamage(PokemonModel.WildHP.Value,PKID, Routes.otherPokemon.Name, 3);
            return RedirectToAction("Jungle");
        }

        public IActionResult Catch()
        {
            PokemonModel.CatchPokemon();
            return RedirectToAction("Team");
        }

        public IActionResult Jungle()
        {
            Routes.LoadRoute();
            return View();
        }

        public IActionResult Team()
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