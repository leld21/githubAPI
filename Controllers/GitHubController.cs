using githubAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Octokit;
namespace githubAPI.Controllers
{
    public class GitHubController : Controller
    {
        static string texto;
        public async void Github(string name)
        {
            var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));
            var user = await client.User.Get(name);
            GitHubController.texto = user.Name + " has " + user.PublicRepos + " public repositories - go check out their profile at " + user.Url;
        }
        public IActionResult Index()
        {
            return View(new GithubViewModel());
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
