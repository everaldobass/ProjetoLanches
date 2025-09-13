using ProjetoLanches.Models;

// Define um namespace para organizar o código relacionado a repositórios e interfaces
namespace ProjetoLanches.Repositories.Interfaces
{
    // Interface que representa o contrato para o repositório de categorias
    public interface ICategoriaRepository
    {
        // Propriedade que retorna uma coleção de objetos do tipo Categoria
        // O uso de IEnumerable permite iteração eficiente e flexível sobre os dados
        IEnumerable<Categoria> Categorias { get; }
    }
}

