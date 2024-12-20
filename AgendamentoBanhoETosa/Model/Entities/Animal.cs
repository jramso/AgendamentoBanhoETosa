using AgendamentoBanhoETosa.Model.Enums;

namespace AgendamentoBanhoETosa.Model.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nome { get; set; }


        public Especie EspecieAnimal { get; set; }
        public int ClienteId { get; set; }

        //public Cliente Cliente { get; set; }   
    }
}
