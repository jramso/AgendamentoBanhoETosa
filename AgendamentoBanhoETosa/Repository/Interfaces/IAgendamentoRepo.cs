using AgendamentoBanhoETosa.Model.Entities;

namespace AgendamentoBanhoETosa.Repository.Interfaces;

public interface IAgendamentoRepo
{
    Task<IEnumerable<Agendamento>> GetAllAsync();
    Task<Agendamento?> GetByIdAsync(int id);
    Task AddAsync(Agendamento agendamento);
    Task UpdateAsync(Agendamento agendamento);
    Task DeleteAsync(Agendamento agendamento);
}

