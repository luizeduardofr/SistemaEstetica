using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaEstetica2.Models
{
    [Table("Servicos")]
    public class Servico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [StringLength(35)]
        [Required(ErrorMessage = "Campo Descrição é obrigatório...")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo Preço é obrigatório...")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Preço")]
        public double preco { get; set; }
    }
}