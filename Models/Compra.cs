using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoASPNet.Models
{
    [Table("Compra")]
    public class Compra
    {
        [Display(Name ="ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name ="Total de itens: ")]
        [Required(ErrorMessage ="Campo é obrigatório")]
        public int TotalItens { get; set; }

        [Display(Name ="Valor total: ")]
        [Required(ErrorMessage ="Campo é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal {  get; set; }
    }
}