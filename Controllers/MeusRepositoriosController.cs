using githubAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace githubAPI.Controllers
{
    public class MeusRepositoriosController : Controller
    {
        //essa função irá pegar um usuario do github( meu usuario ) e retornar uma
        //lista de repositorios com todos os repositorios do usuario
        public IReadOnlyList<Repository> Github()
        {
                var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));
                var user = Task.Run(async () => await client.User.Get("leld21")).Result;
                var repos = Task.Run(async () => await client.Repository.GetAllForUser("leld21")).Result;
                return repos;

        }

        public IActionResult Index()
        {

            return View(Github());
        }
    }
}
