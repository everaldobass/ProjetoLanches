using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Define um namespace para organizar o código relacionado
namespace ProjetoLanches.Models
{
    // Define que a tabela no banco de dados será chamada "CarrinhoCompraItens"
    [Table("CarrinhoCompraItens")]
    // Define a classe que representa um item no carrinho de compras
    public class CarrinhoCompraItem
    {
        // Define a propriedade como chave primária da tabela
        public int CarrinhoCompraItemId { get; set; }
        // Define a chave estrangeira para o lanche associado ao item do carrinho
        public Lanche Lanche { get; set; }
        // Define a quantidade do lanche no carrinho
        public int Quantidade { get; set; }
        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }

    }

}
