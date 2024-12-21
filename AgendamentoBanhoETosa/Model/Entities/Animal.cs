using AgendamentoBanhoETosa.Model.Enums;

namespace AgendamentoBanhoETosa.Model.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Especie EspecieAnimal { get; set; }
        public RacaCachorro? RacaCachorro { get; set; }
        public RacaGato? RacaGato { get; set; }
        public int TutorID { get; set; }

        //public Tutor Tutor { get; set; }   
    }
}
