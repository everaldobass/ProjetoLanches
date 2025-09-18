using Microsoft.AspNetCore.Mvc;
using ProjetoLanches.Models;
using ProjetoLanches.ViewModels;

// Aula 55 - Importa o namespace necessário para criar componentes de visão
// Define o namespace onde está localizado o componente de visão do carrinho de compras
namespace ProjetoLanches.Components
{


    // Classe que representa o componente de visão do resumo do carrinho de compras
    public class CarrinhoCompraResumo : ViewComponent
    {

        // Declara uma variável para manipular o carrinho de compras
        private readonly CarrinhoCompra _carrinhoCompra;


        // Construtor da classe, que recebe o carrinho de compras via injeção de dependência
        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            // Atribui o carrinho de compras à variável privada
            _carrinhoCompra = carrinhoCompra;
        }



        // Método que é chamado para renderizar o componente de visão
        public IViewComponentResult Invoke()
        {
            // Obtém os itens atualmente no carrinho de compras
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();

            // Atribui os itens obtidos à propriedade do carrinho de compras
            _carrinhoCompra.CarrinhoCompraItems = itens;

            // Cria uma instância do ViewModel do carrinho de compras, preenchendo suas propriedades
            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                // Define o carrinho de compras atual
                CarrinhoCompra = _carrinhoCompra,
                // Calcula e define o valor total dos itens no carrinho
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            // Retorna a view associada à ação Index
            return View(carrinhoCompraVM);


        }
    }
}
