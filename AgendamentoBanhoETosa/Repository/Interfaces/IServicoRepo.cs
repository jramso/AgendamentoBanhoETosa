using AgendamentoBanhoETosa.Model.Entities;

namespace AgendamentoBanhoETosa.Repository.Interfaces
{
    public interface IServicoRepo
    {

        Task<IEnumerable<Servico>> GetAllAsync();

        Task<Servico?> GetByIdAsync(int id);
        Task AddAsync(Servico servico);
        Task UpdateAsync(Servico servico);
        Task DeleteAsync(Servico servico);   
    }
}
