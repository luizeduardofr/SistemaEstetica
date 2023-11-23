using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaEstetica2.Models
{
    [Table("Agendamentos")]
    public class Agendamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo Data é obrigatório...")]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        public DateTime reservaData { get; set; }

        [Required(ErrorMessage = "Campo Horário é obrigatório...")]
        [DataType(DataType.Time)]
        [Display(Name = "Horário")]
        public TimeSpan reservaHorario { get; set; }

        public int funcionarioID { get; set; }
        [ForeignKey("funcionarioID")]
        [Display(Name = "Funcionário")]
        public Funcionario funcionario { get; set; }

        public int clienteID { get; set; }
        [ForeignKey("clienteID")]
        [Display(Name = "Cliente")]
        public Cliente cliente { get; set; }

        public int servicoID { get; set; }
        [ForeignKey("servicoID")]
        [Display(Name = "Serviço")]
        public Servico servico { get; set; }
    }
}
