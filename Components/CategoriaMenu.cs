using Microsoft.AspNetCore.Mvc;
using ProjetoLanches.Repositories.Interfaces;



// Define o namespace onde o componente está localizado, organizando o código por funcionalidade
namespace ProjetoLanches.Components
{
    // Componente de visualização para o menu de categorias
    public class CategoriaMenu : ViewComponent
    {
        // Repositório de categorias para acessar os dados
        private readonly ICategoriaRepository _categoriaRepository;


        // Construtor que injeta o repositório de categorias
        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            // Inicializa o repositório de categorias
            _categoriaRepository = categoriaRepository;
        }


        // Método que é chamado para renderizar o componente
        public IViewComponentResult Invoke()
        {
            // Obtém a lista de categorias ordenadas por nome
            var categorias = _categoriaRepository.Categorias.OrderBy(c => c.CategoriaNome);
            // Retorna a visualização do componente com a lista de categorias
            return View(categorias);
        }

    }
}
