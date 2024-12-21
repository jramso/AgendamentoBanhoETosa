using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Model.DTOs;

namespace AgendamentoBanhoETosa.Services.Interfaces
{
    public interface IAgendamentoServ
    {
        Task<IEnumerable<AgendamentoDTO>> GetAllAgendamentosAsync();
        Task<AgendamentoDTO?> GetAgendamentoByIdAsync(int id);
        Task<AgendamentoDTO> CreateAgendamentoAsync(AgendamentoDTO agendamento); // Retorna DTO
        Task<bool> UpdateAgendamentoAsync(int id, AgendamentoDTO agendamento); // Retorna bool
        Task<bool> DeleteAgendamentoAsync(int id); // Consistente com o controller
        Task<IEnumerable<AgendamentoDTO>> GetAgendamentosByClienteAsync(int clienteId); // Retorna DTOs
        Task<IEnumerable<AgendamentoDTO>> GetAgendamentosByDateAsync(DateTime date); // Retorna DTOs
    }
}
