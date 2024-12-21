using System.ComponentModel.DataAnnotations;

namespace AgendamentoBanhoETosa.Model.DTOs
{
    public class ServicoDTO
    {
        [Required(ErrorMessage = "O nome do serviço é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do serviço deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço do serviço é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public float Preco { get; set; }
    }
}
