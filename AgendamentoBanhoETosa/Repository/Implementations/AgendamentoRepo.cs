using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoBanhoETosa.Repository.Implementations;

public class AgendamentoRepo : IAgendamentoRepo
{
    private readonly AppDbContext _dbContext;

    public AgendamentoRepo(AppDbContext dbContext)
    {  _dbContext = dbContext; }

    public async Task<IEnumerable<Agendamento>> GetAllAsync() 
    {
        return await _dbContext.Agendamentos.ToListAsync();
    }

    public async Task<Agendamento?> GetByIdAsync(int id) 
    {
        return await _dbContext.Agendamentos.FindAsync(id);
    }

    public async Task AddAsync(Agendamento agendamento)
    {
        await _dbContext.Agendamentos.AddAsync(agendamento);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Agendamento agendamento)
    {
        _dbContext.Agendamentos.Update(agendamento);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Agendamento agendamento)
    {
        _dbContext.Agendamentos.Remove(agendamento);
        await _dbContext.SaveChangesAsync();
    }


}
