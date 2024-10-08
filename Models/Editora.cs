using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoASPNet.Models
{
    [Table("Editora")]
    public class Editora
    {
        [Display(Name ="ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome: ")]
        [Required(ErrorMessage ="Campo é obrigatório")]
        [StringLength(50, ErrorMessage ="Máximo de 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name ="Endereço: ")]
        [Required(ErrorMessage ="Campo é obrigatório")]
        [StringLength(250, ErrorMessage ="Máximo de 250 caracteres")]
        public string Endereco { get; set; }

        [Display(Name ="Telefone: ")]
        [Required(ErrorMessage ="Campo é obrigatório")]
        [StringLength(20, ErrorMessage ="Máximo de 20 caracteres")]
        public string Telefone { get; set; }

    }
}