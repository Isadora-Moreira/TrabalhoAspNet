using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoASPNet.Models
{
    [Table("Livro")]
    public class Livro
    {
        [Display(Name ="ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name ="Título: ")]
        [Required(ErrorMessage ="Campo é obrigatório")]
        [StringLength(50, ErrorMessage ="Máximo de 50 caracteres")]
        public string Titulo { get; set; }

        [Display(Name ="Ano de publicação: ")]
        [Required(ErrorMessage ="Campo é obrigatório")]
        [StringLength(4, ErrorMessage ="Máximo de 4 caracteres")]
        public string AnoPublicacao { get; set; }

        [Display(Name ="Preço: ")]
        [Required(ErrorMessage ="Campo é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco {  get; set; }

        [Display(Name ="Quantidade em estoque: ")]
        [Required(ErrorMessage ="Campo é obrigatório")]
        public int QuantidadeEmEstoque { get; set; }

        [Display(Name ="Autor: ")]
        public Autor Autor { get; set; }

        [Display(Name ="Autor: ")]
        public int AutorId { get; set; }

        [Display(Name ="Genero: ")]
        public Genero Genero { get; set; }

        [Display(Name ="Genero: ")]
        public int GeneroId { get; set; }

        [Display(Name ="Editora: ")]
        public Editora Editora { get; set; }

        [Display(Name ="Editora: ")]
        public int EditoraId { get; set; }
    }
}