using Microsoft.AspNetCore.Mvc;
using ProjetoLanches.Models;
using ProjetoLanches.Repositories.Interfaces;

// Aula 50  - Define o namespace do projeto, agrupando as classes relacionadas
namespace ProjetoLanches.Controllers
{

    // Define a classe do controller responsável pelo carrinho de compras
    public class CarrinhoCompraController : Controller
    {

        // Declara uma variável para acessar os dados dos lanches
        private readonly ILancheRepository _lancheRepository;
        // Declara uma variável para manipular o carrinho de compras
        private readonly CarrinhoCompra _carrinhoCompra;


        // Construtor da classe, que recebe as dependências via injeção de dependência
        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            // Atribui o repositório de lanches à variável privada
            _lancheRepository = lancheRepository;

            // Atribui o carrinho de compras à variável privada
            _carrinhoCompra = carrinhoCompra;
        }




        // Método que retorna a view principal do carrinho de compras
        public IActionResult Index()
        {
            // Obtém os itens atualmente no carrinho de compras
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            // Atribui os itens obtidos à propriedade do carrinho de compras
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraViewModel = new ViewModels.CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            // Retorna a view associada à ação Index
            return View(carrinhoCompraViewModel);
        }




        // Método que adiciona um lanche ao carrinho de compras
        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
        {
            // Busca o lanche pelo ID fornecido
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            // Se o lanche for encontrado, adiciona-o ao carrinho de compras
            if (lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }
            // Redireciona para a ação Index do controller atual
            return RedirectToAction("Index");

        }



        // Método que adiciona um lanche ao carrinho de compras
        public RedirectToActionResult RemoverItemDoCarrinhoCompra(int lancheId)
        {
            // Busca o lanche pelo ID fornecido
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            // Se o lanche for encontrado, adiciona-o ao carrinho de compras
            if (lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }
            // Redireciona para a ação Index do controller atual
            return RedirectToAction("Index");

        }

    }
}

