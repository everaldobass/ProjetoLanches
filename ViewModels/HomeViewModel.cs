using ProjetoLanches.Models;

// Define o namespace onde está localizada a ViewModel da página inicial (home)
namespace ProjetoLanches.ViewModels
{
    // Classe que representa os dados que serão enviados da controller para a view inicial (home)
    public class HomeViewModel
    {
        // Propriedade que representa os lanches que são preferidos
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }

     }
}
