﻿namespace AgendamentoBanhoETosa.Model.Entities
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int ClienteId { get; set; }
        //public Tutor Tutor { get; set; }
        public int PetId { get; set; }
        //public Pet Pet { get; set; }
        public int ServicoId { get; set; }
        //public Servico Servico { get; set; }

    }

}
