using AgendamentoBanhoETosa.Model;
using System.Collections.Generic;

namespace AgendamentoBanhoETosa.IRepositories
{
    public interface IAgendamento
    {

        Task<IEnumerable<Agendamento>> GetAllAsync();            
        Task<Agendamento?> GetByIdAsync(int id);                 
        Task AddAsync(Agendamento agendamento);                
        Task UpdateAsync(Agendamento agendamento);               
        Task DeleteAsync(int id);                               
        Task<IEnumerable<Agendamento>> GetByClienteIdAsync(int clienteId);  //por id
        Task<IEnumerable<Agendamento>> GetByDateAsync(DateTime date);       //por data
    }
}
