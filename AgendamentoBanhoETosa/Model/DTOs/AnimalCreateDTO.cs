using AgendamentoBanhoETosa.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace AgendamentoBanhoETosa.Model.DTOs
{
    public class AnimalCreateDTO
    {

        [Required(ErrorMessage = "O nome do pet é obrigatório")]
        public string Nome { get; set; }
        public  Especie EspecieAnimal { get; set; }

        // Raça correspondente à espécie
        public RacaCachorro? RacaCachorro { get; set; }
        public RacaGato? RacaGato { get; set; }
        public int ClienteId { get; set; }
    }
}
