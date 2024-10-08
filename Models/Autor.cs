using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoASPNet.Models
{
    [Table("Autor")]
    public class Autor
    {
        [Display(Name = "ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nome: ")]
        [Required(ErrorMessage = "Campo é obrigatório")]
        [StringLength(50, ErrorMessage = "Tamanho máximo de 50 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Data de nascimento")] 
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Date)]
        public DateOnly Nascimento { get; set; }
       
        [Display(Name ="Nacionalidade: ")]
        [Required(ErrorMessage ="Campo é obrigatório")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Nacionalidade { get; set; }
    }
}