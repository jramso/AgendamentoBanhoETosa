﻿using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoBanhoETosa.Repository.Implementations;
public class TutorRepo : ITutorRepo
{
    private readonly AppDbContext _dbContext;

    public TutorRepo(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Tutor>> GetAllAsync()
    {
        return await _dbContext.Tutores.ToListAsync();
    }

    public async Task<Tutor?> GetByIdAsync(int id)
    {
        return await _dbContext.Tutores.FindAsync(id);
    }

    public async Task AddAsync(Tutor cliente)
    {
        await _dbContext.Tutores.AddAsync(cliente);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tutor cliente)
    {
        _dbContext.Tutores.Update(cliente);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Tutor cliente)
    {
        _dbContext.Tutores.Remove(cliente);
        await _dbContext.SaveChangesAsync();
    }
}
