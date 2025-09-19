using Microsoft.AspNetCore.Mvc;
using ProjetoLanches.Models;
using ProjetoLanches.Repositories.Interfaces;
using ProjetoLanches.ViewModels;

// Define o namespace onde o controlador está localizado, organizando o código por funcionalidade
namespace ProjetoLanches.Controllers
{
    // Controlador responsável por gerenciar as ações relacionadas aos lanches
    public class LancheController : Controller
    {


        // Injeção de dependência do repositório de lanches
        private readonly ILancheRepository _lancheRepository;


        // Construtor que recebe o repositório de lanches via injeção de dependência
        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }


        // Ação que exibe a lista de lanches, possivelmente filtrada por categoria
        public IActionResult List(string categoria)
        {

            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }

            else
            {

                lanches = _lancheRepository.Lanches
                .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                .OrderBy(l => l.Nome);

                categoriaAtual = categoria;
            }

            // Cria o ViewModel com os dados necessários para a View
            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            // Retorna a View com o ViewModel
            return View(lancheListViewModel);
        }




        // Ação que exibe os detalhes de um lanche específico
        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches
               .FirstOrDefault(l => l.LancheId == lancheId);
            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche);
        }


    }
}
