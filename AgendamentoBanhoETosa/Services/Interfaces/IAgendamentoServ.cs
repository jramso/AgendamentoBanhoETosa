using AgendamentoBanhoETosa.Model.Entities;

namespace AgendamentoBanhoETosa.Services.Interfaces
{
    public interface IAgendamentoServ
    {
        Task<IEnumerable<Agendamento>> GetAllAgendamentosAsync();
        Task<Agendamento?> GetAgendamentoByIdAsync(int id);
        Task<Agendamento> CreateAgendamentoAsync(Agendamento agendamento);
        Task UpdateAgendamentoAsync(int id, Agendamento agendamento);
        Task DeleteAgendamentoAsync(int id);
        Task<IEnumerable<Agendamento>> GetAgendamentosByClienteAsync(int clienteId);
        Task<IEnumerable<Agendamento>> GetAgendamentosByDateAsync(DateTime date);
    }
}
