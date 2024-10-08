using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoASPNet.Models
{
    [Table("Genero")]
    public class Genero
    {
        [Display(Name ="ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name ="Descrição: ")]
        [Required(ErrorMessage ="Campo é obrigatório")]
        [StringLength(50, ErrorMessage ="Máximo de 50 caracteres")]
        public string Descricao { get; set; }
    }
}