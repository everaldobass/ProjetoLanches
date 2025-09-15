using Microsoft.EntityFrameworkCore;
using ProjetoLanches.Context;
using ProjetoLanches.Models;
using ProjetoLanches.Repositories.Interfaces;

// Define o namespace onde a classe está localizada, organizando o código por funcionalidade
namespace ProjetoLanches.Repositories
{
    // Classe que implementa a interface ILancheRepository
    // Responsável por acessar os dados da tabela de lanches no banco
    public class LancheRepository : ILancheRepository
    {
        // Campo privado e somente leitura que representa o contexto do banco de dados
        private readonly ApplicationDbContext _context;



        // Construtor que recebe o contexto do banco de dados via injeção de dependência
        public LancheRepository(ApplicationDbContext contexto)
        {
            // Armazena o contexto recebido para uso nos métodos da classe
            _context = contexto;
        }


        // Propriedade que retorna todos os lanches cadastrados, incluindo suas categorias
        public IEnumerable<Lanche> Lanches =>
            _context.Lanches.Include(c => c.Categoria); // Usa Include para carregar os dados da categoria junto com o lanche

        // Propriedade que retorna apenas os lanches marcados como preferidos, incluindo suas categorias
        public IEnumerable<Lanche> LanchesPreferidos =>
            _context.Lanches
                .Where(l => l.IsLanchePreferido) // Filtra os lanches preferidos
                .Include(c => c.Categoria);      // Inclui os dados da categoria

        // Método que retorna um lanche específico com base no seu ID
        public Lanche GetLancheById(int LancheId)
        {
            // Busca o primeiro lanche que tenha o ID informado, ou retorna null se não encontrar
            return _context.Lanches.FirstOrDefault(l => l.LancheId == LancheId);
        }
    }
}

