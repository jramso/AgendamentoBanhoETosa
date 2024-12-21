using AgendamentoBanhoETosa.Model.Entities;

namespace AgendamentoBanhoETosa.Repository.Interfaces;

public interface IAnimalRepo
{
    Task<IEnumerable<Animal>> GetAllAsync();
    Task<Animal?> GetByIdAsync(int id);
    Task AddAsync(Animal animal);
    Task UpdateAsync(Animal animal);
    Task DeleteAsync(Animal animal);
}
