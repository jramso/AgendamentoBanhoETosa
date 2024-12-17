using System.ComponentModel.DataAnnotations;

namespace AgendamentoBanhoETosa.DTOs
{
    public class ClienteDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Phone(ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        public string Endereco { get; set; }
    }
}
