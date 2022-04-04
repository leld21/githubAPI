using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace githubAPI.Controllers
{
    public class FavoritosController : Controller
    {
        //lista todos os favoritos guardados no .txt 
        public IActionResult Index()
        {
            string[] lines = System.IO.File.ReadAllLines("favoritos.txt");
            return View(lines);
        }

        //adiciona o repositorio ( Repo ) ao .txt, armazenando-o
        public IActionResult AdicionarFavorito(string Repo)
        {
            System.IO.File.AppendAllText("favoritos.txt",'\n'+Repo);
            return View();
        }
    }
}
