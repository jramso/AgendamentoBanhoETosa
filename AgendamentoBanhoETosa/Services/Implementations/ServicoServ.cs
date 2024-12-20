using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoBanhoETosa.Services.Implementations
{
    public class ServicoServ : IServicoServ
    {
        private readonly AppDbContext _dbContext;
        public ServicoServ(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Servico>> GetAllServicosAsync()
        {
            return await _dbContext.Servicos.ToListAsync();
        }

        public async Task<Servico?> GetServicoByIdAsync(int id)
        {
            return await _dbContext.Servicos.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Servico> AddServicoAsync(Servico servico)
        {
            _dbContext.Servicos.Add(servico);
            await _dbContext.SaveChangesAsync();
            return servico;
        }

        public async Task<bool> UpdateServicoAsync(int id, Servico servico)
        {
            var existingServico = await _dbContext.Servicos.FindAsync(id);
            if (existingServico == null) return false;

            existingServico.Nome = servico.Nome;
            //existingServico.Descricao = servico.Descricao;
            existingServico.Preco = servico.Preco;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteServicoAsync(int id)
        {
            var servico = await _dbContext.Servicos.FindAsync(id);
            if (servico == null) return false;

            _dbContext.Servicos.Remove(servico);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
