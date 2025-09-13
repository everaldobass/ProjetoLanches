using ProjetoLanches.Models;

// Define o namespace onde a interface está localizada, organizando o código por funcionalidade
namespace ProjetoLanches.Repositories.Interfaces
{
    // Interface que define o contrato para o repositório de lanches
    public interface ILancheRepository
    {
        // Propriedade que retorna todos os lanches disponíveis no sistema
        IEnumerable<Lanche> Lanches { get; } // Retorna uma lista de lanches

        // Propriedade que retorna apenas os lanches marcados como preferidos
        IEnumerable<Lanche> LanchesPreferidos { get; } // Retorna uma lista de lanches preferidos

        // Método que busca um lanche específico pelo seu ID
        Lanche GetLancheById(int id); // Acessa um lanche específico
    }
}
