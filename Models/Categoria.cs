using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Define o namespace onde está localizada a classe de modelo de domínio
namespace ProjetoLanches.Models
{
    // Define que a tabela no banco de dados será chamada "Categorias"
    [Table("Categorias")]
    public class Categoria
    {
        // Define a propriedade como chave primária da tabela
        [Key]
        public int CategoriaId { get; set; }

        // Define que o campo pode ter no máximo 100 caracteres
        // Torna o campo obrigatório e exibe uma mensagem personalizada se não for preenchido
        // Define o nome do campo como "Nome" na interface (View)
        [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [Display(Name = "Nome")]
        public string CategoriaNome { get; set; }

        // Define que o campo pode ter no máximo 200 caracteres
        // Torna o campo obrigatório e exibe uma mensagem personalizada se não for preenchido
        // Define o nome do campo como "Descrição" na interface (View)
        [StringLength(200, ErrorMessage = "O tamanho máximo é 200 caracteres")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        // Define a relação de um-para-muitos entre Categoria e Lanche
        // Uma categoria pode ter vários lanches associados
        public List<Lanche> Lanches { get; set; }
    }
}

