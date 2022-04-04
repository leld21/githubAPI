using githubAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Octokit;
namespace githubAPI.Controllers
{
    public class GitHubController : Controller
    {
        static string texto;
        static Repository? DescRepositorio;
        public async void Github(string name)
        {
            var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));
            var user = await client.User.Get(name);
            GitHubController.texto = user.Name + " has " + user.PublicRepos + " public repositories - go check out their profile at " + user.Url;
        }

        public async void GithubDescricao(string usuario, string repositorio)
        {
            var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));
            GitHubController.DescRepositorio = await client.Repository.Get(usuario,repositorio);
            
        }

        public IActionResult Index()
        {
            return View(new GithubViewModel());
        }

        public IActionResult Descricao(string repo)
        {
            string usuario=repo.Split('/')[0];
            string repositorio=repo.Split('/')[1];
            GithubDescricao(usuario, repositorio);
            return View(DescRepositorio);
        }

        [HttpPost]
        public IActionResult Index(GithubViewModel obj)
        {
            Github(obj.Name);
            ViewData["Message"] = texto;
            return View();
        }

        

    }
}
