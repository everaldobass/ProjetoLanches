using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Define o namespace onde está localizada a classe de modelo de domínio
namespace ProjetoLanches.Models
{
    // Define que a tabela no banco de dados será chamada "Lanches"
    [Table("Lanches")]
    public class Lanche
    {
        // Define a propriedade como chave primária da tabela
        [Key]
        public int LancheId { get; set; }

        // Define que o campo é obrigatório, exibe um nome amigável e impõe restrições de tamanho
        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome do Lanche")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string Nome { get; set; }

        // Define que o campo é obrigatório, exibe um nome amigável e impõe restrições de tamanho
        [Required(ErrorMessage = "A descrição do lanche deve ser informada")]
        [Display(Name = "Descrição do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição pode exceder {1} caracteres")]
        public string DescricaoCurta { get; set; }

        // Define que o campo é obrigatório, exibe um nome amigável e impõe restrições de tamanho
        [Required(ErrorMessage = "O descrição detalhada do lanche deve ser informada")]
        [Display(Name = "Descrição detalhada do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada pode exceder {1} caracteres")]
        public string DescricaoDetalhada { get; set; }

        // Define que o campo é obrigatório, exibe um nome amigável, define o tipo de dado e impõe um intervalo de valores
        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }

        // Define o nome amigável para o campo na interface (View)
        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }

        // Define o nome amigável para o campo na interface (View)
        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        // Define o nome amigável para o campo na interface (View)
        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        // Define o nome amigável para o campo na interface (View)
        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        // Chave estrangeira para a categoria do lanche
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}

