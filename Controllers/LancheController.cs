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
            string categoriaAtual = "Todos os Lanches";

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches
                                           .OrderBy(l => l.LancheId);
            }
            else
            {
                // Filtra os lanches pela categoria fornecida, ignorando maiúsculas e minúsculas
                lanches = _lancheRepository.Lanches
                                           .Where(l => l.Categoria != null &&
                                                       l.Categoria.CategoriaNome.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                                           .OrderBy(l => l.Nome);

                categoriaAtual = categoria;
            }

            // Cria o ViewModel com os dados necessários para a View
            var viewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };


            // Retorna a View com o ViewModel
            return View(viewModel);
        }
    }
}
