using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaEstetica2.Models
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo Nome é obrigatório...")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo Idade é obrigatório...")]
        [Display(Name = "Idade")]
        public int nascimento { get; set; }

        [StringLength(14)]
        [Required(ErrorMessage = "Campo CPF é obrigatório...")]
        [Display(Name = "CPF")]
        public string cpf { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Campo Telefone é obrigatório...")]
        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo Email é obrigatório...")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email inválido")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Campo Horários Disponíveis é obrigatório...")]
        [Display(Name = "Qtde Horários Disponíveis")]
        public int vagas { get; set; }
    }
}
