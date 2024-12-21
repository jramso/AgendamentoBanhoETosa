using AgendamentoBanhoETosa.Model.Entities;

namespace AgendamentoBanhoETosa.Repository.Interfaces;

    public interface ITutorRepo
    {
        Task<IEnumerable<Tutor>> GetAllAsync();
        Task<Tutor?> GetByIdAsync(int id);
        Task AddAsync(Tutor cliente);
        Task UpdateAsync(Tutor cliente);
        Task DeleteAsync(Tutor cliente);
    }
