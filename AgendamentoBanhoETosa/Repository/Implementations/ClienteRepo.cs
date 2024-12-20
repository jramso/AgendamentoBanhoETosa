using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoBanhoETosa.Repository.Implementations;
public class ClienteRepo : IClienteRepo
{
    private readonly AppDbContext _dbContext;

    public ClienteRepo(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _dbContext.Clientes.ToListAsync();
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await _dbContext.Clientes.FindAsync(id);
    }

    public async Task AddAsync(Cliente cliente)
    {
        await _dbContext.Clientes.AddAsync(cliente);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cliente cliente)
    {
        _dbContext.Clientes.Update(cliente);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Cliente cliente)
    {
        _dbContext.Clientes.Remove(cliente);
        await _dbContext.SaveChangesAsync();
    }
}
