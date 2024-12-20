using System.ComponentModel.DataAnnotations;
using AgendamentoBanhoETosa.Model.Enums;

namespace AgendamentoBanhoETosa.DTOs
{
    public class AnimalDTO
    {
        [Required(ErrorMessage = "O nome do pet é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do pet deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O tipo do pet é obrigatório (0 Cachorro ou 1 Gato)")]
        public Especie Tipo { get; set; }

        public RacaCachorro? RacaCachorro { get; set; }

        public RacaGato? RacaGato { get; set; }

        [Required(ErrorMessage = "O ID do cliente é obrigatório")]
        public int ClienteId { get; set; }
    }
}

