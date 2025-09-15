using Microsoft.AspNetCore.Mvc;
using ProjetoLanches.Repositories.Interfaces;
using ProjetoLanches.ViewModels;

namespace ProjetoLanches.Controllers
{
    public class LancheController : Controller
    {

        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        // Método construtor

        public IActionResult List()
        {

            var lancheslistViewModel = new LancheListViewModel();
            {
                lancheslistViewModel.Lanches = _lancheRepository.Lanches;
                lancheslistViewModel.CategoriaAtual = "Categoria Atual";
            }

            return View(lancheslistViewModel);
        

        }
    }
}
