using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoASPNet.Models
{
    [Table("Carrinho")]
    public class Carrinho
    {
        [Display(Name ="ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name ="Nome do livro: ")]
        public Livro Livro { get; set; }

        [Display(Name ="Nome do Livro: ")]
        [Required(ErrorMessage ="Campo é obrigatório")]
        public int LivroId { get; set; }

        [Display(Name ="Quantidade: ")]
        [Required(ErrorMessage ="Campo é obrigatório")]
        public int Quantidade { get; set; }

        [Display(Name = "ID da Compra: ")]
        public Compra Compra { get; set; }

        [Display(Name ="ID da Compra: ")]
        public int? CompraId { get; set; }
    }
}