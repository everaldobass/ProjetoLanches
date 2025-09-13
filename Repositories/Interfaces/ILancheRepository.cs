using ProjetoLanches.Models;

namespace ProjetoLanches.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> Lanches { get; } // Retrna uma lista de lanches
        IEnumerable<Lanche> LanchesPreferidos { get; } // Retrna uma lista de lanches preferidos
        Lanche GetLancheById(int id); // Acessa um lanche especifico
    }
}
