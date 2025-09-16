using Microsoft.AspNetCore.Mvc;
using ProjetoLanches.Repositories.Interfaces;
using ProjetoLanches.ViewModels;

namespace ProjetoLanches.Controllers
{
    public class LancheController : Controller
    {
        // Declara uma variável para acessar os dados dos lanches
        private readonly ILancheRepository _lancheRepository;
        // Construtor da classe, que recebe o repositório de lanches via injeção de dependência
        public LancheController(ILancheRepository lancheRepository)
        {   // Atribui o repositório de lanches à variável privada
            _lancheRepository = lancheRepository;
        }

        // Método construtor

        public IActionResult List()
        {
            // Cria uma instância do ViewModel da lista de lanches, preenchendo suas propriedades
            var lancheslistViewModel = new LancheListViewModel();
            {   // Obtém a lista de lanches do repositório
                lancheslistViewModel.Lanches = _lancheRepository.Lanches;
                lancheslistViewModel.CategoriaAtual = "Categoria Atual";
            }
            // Retorna a view associada à ação List, passando o ViewModel como parâmetro
            return View(lancheslistViewModel);


        }
    }
}
