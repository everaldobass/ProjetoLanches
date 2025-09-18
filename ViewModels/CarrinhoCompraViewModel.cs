using ProjetoLanches.Models;


// Define o namespace onde está localizada a ViewModel do carrinho de compras
namespace ProjetoLanches.ViewModels
{

    // Classe que representa os dados que serão enviados da controller para a view do carrinho
    public class CarrinhoCompraViewModel
    {

        // Propriedade que representa o carrinho de compras atual do usuário
        public CarrinhoCompra CarrinhoCompra { get; set; }

        // Propriedade que representa o valor total dos itens no carrinho
        public decimal CarrinhoCompraTotal { get; set; }
    }
}
