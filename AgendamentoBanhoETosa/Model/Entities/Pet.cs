using AgendamentoBanhoETosa.Model.Enums;

namespace AgendamentoBanhoETosa.Model
{
    public class Pet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoPet Tipo { get; set; }
        public RacaCachorro? RacaCachorro { get; set; }
        public RacaGato? RacaGato { get; set; }
        public int ClienteId { get; set; }
    }
}

