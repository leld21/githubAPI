using githubAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace githubAPI.Controllers
{
    public class MeusRepositoriosController : Controller
    {

        static string? texto;
        static IReadOnlyList<Repository>? model;
        static Repository? repositorio;

        public async void Github()
        {
            try {
                var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));
                var user = await client.User.Get("leld21");
                var repos = await client.Repository.GetAllForUser("leld21");
                model = repos;
            } catch (Exception e) {

            }

        }
 

        public IActionResult Index()
        {
            Github();
            return View(model);
        }
    }
}
