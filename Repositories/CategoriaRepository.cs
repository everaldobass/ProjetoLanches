using ProjetoLanches.Context;
using ProjetoLanches.Models;
using ProjetoLanches.Repositories.Interfaces;

// Define o namespace onde a classe está localizada, ajudando na organização do projeto
namespace ProjetoLanches.Repositories
{

    // Classe que implementa a interface ICategoriaRepository
    // Responsável por acessar os dados da tabela de categorias no banco
    public class CategoriaRepository : ICategoriaRepository
    {

        // Campo privado e somente leitura que representa o contexto do banco de dados
        private readonly ApplicationDbContext _context;


        // Construtor que recebe o contexto do banco de dados via injeção de dependência
        public CategoriaRepository(ApplicationDbContext context)
        {
            // Armazena o contexto recebido para uso nos métodos da classe
            _context = context;
        }


        // Propriedade que retorna todas as categorias do banco de dados
        // Utiliza o Entity Framework para acessar a tabela Categorias
        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}

