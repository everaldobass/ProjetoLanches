using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjetoLanches.Models;
using ProjetoLanches.Repositories.Interfaces;

namespace ProjetoLanches.Controllers
{
    // Aula 34 - Define a classe do controller responsável pela página inicial
    public class HomeController : Controller
    {
        // Declara uma variável para acessar os dados dos lanches
        private readonly ILancheRepository _lancheRepository;

        // Construtor da classe, que recebe o repositório de lanches via injeção de dependência
        public HomeController(ILancheRepository lancheRepository)
        {
            //
            _lancheRepository = lancheRepository;

        }



        // Método que retorna a view principal da aplicação
        public IActionResult Index()
        {
            // Cria uma instância do ViewModel da página inicial, preenchendo suas propriedades
            var homeViewModel = new ViewModels.HomeViewModel
            {
                // Obtém a lista de lanches preferidos do repositório
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            };
            // Retorna a view associada à ação Index, passando o ViewModel como parâmetro
            return View(homeViewModel);
            //return View();
        }




        // Método que retorna a view de contato
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // Aula 34 - Define a ação para exibir a página de erro
        public IActionResult Error()
        {
            // Retorna a view associada à ação Error, passando um modelo de erro com o ID da requisição
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
