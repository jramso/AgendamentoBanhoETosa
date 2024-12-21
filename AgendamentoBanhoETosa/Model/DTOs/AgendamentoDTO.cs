using System.ComponentModel.DataAnnotations;

namespace AgendamentoBanhoETosa.Model.DTOs
{
    public class AgendamentoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A data e hora do agendamento são obrigatórias")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato inválido para data e hora")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O ID do cliente é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID do cliente deve ser um valor válido")]
        public int TutorId { get; set; }

        [Required(ErrorMessage = "O ID do pet é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID do pet deve ser um valor válido")]
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "O ID do serviço é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID do serviço deve ser um valor válido")]
        public int ServicoId { get; set; }
    }
}

