using Microsoft.EntityFrameworkCore;
using ProjetoLanches.Context;
using System.Security.Cryptography.X509Certificates;

// Define um namespace para organizar o código relacionado 
namespace ProjetoLanches.Models
{
    //Classe quem implementa um Carrinho de Compra
    public class CarrinhoCompra
    {

        // Conexão com o banco de dados via Entity Framework
        private readonly ApplicationDbContext _context;

        // Construtor da classe CarrinhoCompra que recebe o contexto do banco de dados
        public CarrinhoCompra(ApplicationDbContext context)
        {
            // Armazena o contexto recebido para uso interno
            _context = context;
        }

        // Propriedade que armazena o ID único do carrinho de compras
        public string CarrinhoCompraId { get; set; }


        // Lista de itens que pertencem ao carrinho de compras
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        // Método estático que obtém ou cria um carrinho de compras vinculado à sessão do usuário
        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            // Obtém a sessão HTTP atual do usuário
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            // Obtém o contexto do banco de dados a partir dos serviços
            var context = services.GetService<ApplicationDbContext>();


            // Tenta recuperar o ID do carrinho da sessão; se não existir, gera um novo GUID
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            // Salva o ID do carrinho na sessão para persistência entre requisições
            session.SetString("CarrinhoId", carrinhoId);

            // Cria e retorna uma nova instância de CarrinhoCompra com o contexto e o ID definido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };


        }



        // Método para adicionar um item ao carrinho de compras
        public void AdicionarAoCarrinho(Lanche lanche)
        {
            // Busca no banco de dados se já existe um item no carrinho com o mesmo LancheId e CarrinhoCompraId
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault
                (
                s => s.Lanche.LancheId == lanche.LancheId && // Verifica se o lanche é o mesmo
                s.CarrinhoCompraId == CarrinhoCompraId       // Verifica se pertence ao mesmo carrinho
                );

            // Se o item ainda não está no carrinho
            if (carrinhoCompraItem == null)
            {
                // Cria um novo item de carrinho com quantidade 1
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId, // Define o ID do carrinho
                    Lanche = lanche,                     // Associa o lanche ao item
                    Quantidade = 1                       // Define a quantidade inicial como 1
                };

                // Adiciona o novo item ao banco de dados
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                // Se o item já existe, apenas incrementa a quantidade
                carrinhoCompraItem.Quantidade++;
            }

            // Salva as alterações no banco de dados
            _context.SaveChanges();
        }



        // Metodo para Remover do Carrinho
        public int RemoverDoCarrinho(Lanche lanche)
        {
            // Busca no banco de dados se já existe um item no carrinho com o mesmo LancheId e CarrinhoCompraId
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault
                (
                s => s.Lanche.LancheId == lanche.LancheId && // Verifica se o lanche é o mesmo
                s.CarrinhoCompraId == CarrinhoCompraId       // Verifica se pertence ao mesmo carrinho
                );

            // Variável que armazenará a quantidade atual do item após a remoção
            var quantidadeLocal = 0;

            // Se o item foi encontrado no carrinho
            if (carrinhoCompraItem != null)
            {
                // Se a quantidade do item for maior que 1, apenas decrementa
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--; // Reduz a quantidade em 1
                                                     //quantidadeLocal = carrinhoCompraItem.Quantidade; // (Comentado) Poderia armazenar a nova quantidade
                }
                else
                {
                    // Se a quantidade for 1, remove o item do carrinho completamente
                    _context.CarrinhoCompraItens.Remove(carrinhoCompraItem); // ⚠️ Faltou ponto e vírgula aqui!
                }
            }

            // Salva as alterações no banco de dados
            _context.SaveChanges();

            // Retorna a quantidade atual do item (sempre será 0 neste caso, pois não foi atualizada)
            return quantidadeLocal;
        }





        // Método que retorna uma lista dos itens do carrinho de compras
        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            // Verifica se a lista CarrinhoCompraItems já foi carregada
            // Se não, busca os itens do carrinho no banco de dados com base no CarrinhoCompraId
            // Inclui os dados do lanche relacionado a cada item
            return CarrinhoCompraItems ??
                 (CarrinhoCompraItems = _context.CarrinhoCompraItens
                 .Where(c => c.CarrinhoCompraId == CarrinhoCompraId) // Filtra os itens pelo ID do carrinho
                 .Include(s => s.Lanche)                             // Carrega os dados do lanche associado
                 .ToList());                                         // Converte o resultado para uma lista
        }






        // Método que remove todos os itens do carrinho de compras
        public void LimparCarrinho()
        {
            // Busca todos os itens do carrinho com base no CarrinhoCompraId
            var carrinhoItens = _context.CarrinhoCompraItens
                .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

            // Remove todos os itens encontrados de uma vez
            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);

            // Salva as alterações no banco de dados
            _context.SaveChanges();
        }


        // Método para calcular o valor total dos itens no carrinho de compras
        public decimal GetCarrinhoCompraTotal()
        {
            // Busca todos os itens do carrinho que possuem o mesmo CarrinhoCompraId
            var valorToral = _context.CarrinhoCompraItens
                .Where(valortotal => valortotal.CarrinhoCompraId == CarrinhoCompraId) // Filtra os itens do carrinho atual
                .Select(valortotal => valortotal.Lanche.Preco * valortotal.Quantidade) // Multiplica o preço do lanche pela quantidade
                .Sum(); // Soma todos os valores calculados para obter o total

            // Retorna o valor total do carrinho
            return valorToral;
        }




    }

}
