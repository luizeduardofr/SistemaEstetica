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

        //[Required(ErrorMessage = "Campo Agendamento é obrigatório...")]
        //[Display(Name = "Data")]
        //public DateOnly reservaDia { get; set; }

        //[Required(ErrorMessage = "Campo Agendamento é obrigatório...")]
        //[Display(Name = "Horário")]
        //public TimeOnly reservaHorario { get; set; }

        [Required(ErrorMessage = "Campo Agendamento é obrigatório.")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Agendar Horário")]
        public DateTime dataDisponivel { get; set; }

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
