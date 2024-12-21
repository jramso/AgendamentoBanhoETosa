using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoBanhoETosa.Repository.Implementations;

public class AnimalRepo : IAnimalRepo
{
    private readonly AppDbContext _dbContext;

    public AnimalRepo(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Animal>> GetAllAsync()
    {
        return await _dbContext.Animais.ToListAsync();
    }

    public async Task<Animal?> GetByIdAsync(int id)
    {
        return await _dbContext.Animais.FindAsync(id);
    }

    public async Task AddAsync(Animal animal)
    {
        await _dbContext.Animais.AddAsync(animal);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Animal animal)
    {
        _dbContext.Animais.Update(animal);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Animal animal)
    {
        _dbContext.Animais.Remove(animal);
        await _dbContext.SaveChangesAsync();
    }
}
