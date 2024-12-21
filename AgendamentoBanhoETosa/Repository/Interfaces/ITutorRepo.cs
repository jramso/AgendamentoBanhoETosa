namespace AgendamentoBanhoETosa.Repository.Interfaces;
    using AgendamentoBanhoETosa.Model.Entities;
    using global::AgendamentoBanhoETosa.Model;


    public interface ITutorRepo
    {
        Task<IEnumerable<Tutor>> GetAllAsync();
        Task<Tutor?> GetByIdAsync(int id);
        Task AddAsync(Tutor cliente);
        Task UpdateAsync(Tutor cliente);
        Task DeleteAsync(Tutor cliente);
    }
