using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace githubAPI.Controllers
{
    public class FavoritosController : Controller
    {
        public IActionResult Index()
        {
            string[] lines = System.IO.File.ReadAllLines("favoritos.txt");
            return View(lines);
        }
    }
}
