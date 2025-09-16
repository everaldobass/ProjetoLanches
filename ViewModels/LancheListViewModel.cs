using ProjetoLanches.Models;

//
namespace ProjetoLanches.ViewModels
{
    public class LancheListViewModel
    {
        // Definindo as propriedades do ViewModel
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }
    }

}
