using AgendamentoBanhoETosa.Model.Enums;

namespace AgendamentoBanhoETosa.Model.DTOs
{
    public class AnimalCreateDTO
    {
        public string Nome { get; set; }
        public  Especie EspecieAnimal { get; set; }
        public int Idade { get; set; }
        public int ClienteId { get; set; }
    }
}
