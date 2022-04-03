using githubAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace githubAPI.Controllers
{
    public class MeusRepositoriosController : Controller
    {

        static string texto;
        public async void Github()
        {
            var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));
            var repos = await client.Repository.GetAllForCurrent();
            
        }   

        public IActionResult Index()
        {
            return View();
        }
    }
}
