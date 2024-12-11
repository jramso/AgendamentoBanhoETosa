namespace AgendamentoBanhoETosa.Model
{
    public class Pet
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int ClienteId { get; set; }

        //public Cliente Cliente { get; set; }   
    }
}
