using AgendamentoBanhoETosa.Repository.Interfaces;
using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoBanhoETosa.Repository.Implementations;
public class ServicoRepo : IServicoRepo
{
    private readonly AppDbContext _dbContext;

    public ServicoRepo(AppDbContext dbContext)
    {
         _dbContext = dbContext;
    }
        
    public async Task<IEnumerable<Servico>> GetAllAsync()
    {
        return await _dbContext.Servicos.ToListAsync();
    }

    public async Task<Servico?> GetByIdAsync(int id)
    {
        return await _dbContext.Servicos.FindAsync(id);
    }

    public async Task AddAsync(Servico servico) 
    {
        await _dbContext.Servicos.AddAsync(servico);
        await _dbContext.SaveChangesAsync();
    }


    public async Task UpdateAsync(Servico servico) 
    {
        _dbContext.Servicos.Update(servico);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(Servico servico) 
    {

        _dbContext.Servicos.Remove(servico);
        await _dbContext.SaveChangesAsync();
    }



}



