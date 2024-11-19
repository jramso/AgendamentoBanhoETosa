using AgendamentoBanhoETosa.Model;

namespace AgendamentoBanhoETosa.Services
{
    public class AgendamentoServ : IAgendamentoServ
    {
        private readonly AgendamentoServ _agendamentoServ;
        public AgendamentoServ(AgendamentoServ agendamentoServ )
        {
            _agendamentoServ = agendamentoServ;
        }

        public Task CreateAgendamentoAsync(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAgendamentoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Agendamento?> GetAgendamentoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Agendamento>> GetAgendamentosByClienteAsync(int clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Agendamento>> GetAgendamentosByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Agendamento>> GetAllAgendamentosAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAgendamentoAsync(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }
    }
}
