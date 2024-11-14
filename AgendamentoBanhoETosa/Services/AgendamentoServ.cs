using AgendamentoBanhoETosa.IRepositories;
using AgendamentoBanhoETosa.Model;

namespace AgendamentoBanhoETosa.Services
{
    public class AgendamentoServ
    {
        private readonly IAgendamento _agendamentoServ;
        public AgendamentoServ(IAgendamento agendamentoServ )
        {
            _agendamentoServ = agendamentoServ;
        }

        public async Task<IEnumerable<Agendamento>> GetAgendamentos()
        {
            return await _agendamentoServ.GetAllAsync();
        }
    }
}
