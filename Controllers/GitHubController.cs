using githubAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Octokit;
namespace githubAPI.Controllers
{
    public class GitHubController : Controller
    {
        

        //Github Search utiliza o octokit para retornar o resultado da pesquisa
        //utilizando um repositorio como entrada
        public SearchRepositoryResult GithubSearch (string reponame)
        {
            var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));

            var request = new SearchRepositoriesRequest(reponame);

            var result = Task.Run(async () => await client.Search.SearchRepo(request)).Result;


            return result;
        }

        //Retorna o objeto repositorio ( com todas informações da API)
        //utilizando o usuario e o nome do repositorio como entrada
        public Repository GithubDescricao(string usuario, string repositorio)
        {
            var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));
            var DescRepositorio = Task.Run(async () => await client.Repository.Get(usuario, repositorio)).Result;
            return DescRepositorio;
        }

        public IReadOnlyList<RepositoryContributor> GithubConstributors(string usuario, string repositorio)
        {
            var client = new GitHubClient(new ProductHeaderValue("my-cool-app"));
            var AllContributors = Task.Run(async () => await client.Repository.GetAllContributors(usuario, repositorio)).Result;
            return AllContributors;
        }

        public IActionResult Index()
        {
            return View(new GithubViewModel());
        }


        //action que irá mostrar a descrição do repositorio clicado
        public IActionResult Descricao(string repo)
        {
            string usuario=repo.Split('/')[0];
            string repositorio=repo.Split('/')[1];
            return View(GithubDescricao(usuario, repositorio));
        }

        public IActionResult Contribuidores(string repo)
        {
            string usuario = repo.Split('/')[0];
            string repositorio = repo.Split('/')[1];
            return View(GithubConstributors(usuario, repositorio));
        }

        //recebe como entrada o nome do repositorio colocado na barra de pesquisa
        //e redireciona para outra aba com os resultados da pesquisa (a action Search).
        [HttpPost]
        public IActionResult Index(GithubViewModel obj)
        {
            return Redirect(@"/Github/Search?Repo="+obj.Repo);
        }

        public IActionResult Search(string Repo)
        {
            return View(GithubSearch(Repo));
        }


    }
}
