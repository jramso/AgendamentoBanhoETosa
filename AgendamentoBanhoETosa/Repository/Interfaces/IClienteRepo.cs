namespace AgendamentoBanhoETosa.Repository.Interfaces;
    using AgendamentoBanhoETosa.Model.Entities;
    using global::AgendamentoBanhoETosa.Model;


    public interface IClienteRepo
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Cliente cliente);
    }
