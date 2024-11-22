using Microsoft.EntityFrameworkCore;
using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendamentoBanhoETosa.Services
{
    public class AgendamentoServ : IAgendamentoServ
    {
        private readonly AppDbContext _context;

        public AgendamentoServ(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Agendamento>> GetAllAgendamentosAsync()
        {
            return await _context.Agendamentos.Include(a => a.Cliente)
                                              .Include(a => a.Pet)
                                              .Include(a => a.Servico)
                                              .ToListAsync();
        }

        public async Task<Agendamento?> GetAgendamentoByIdAsync(int id)
        {
            return await _context.Agendamentos.Include(a => a.Cliente)
                                              .Include(a => a.Pet)
                                              .Include(a => a.Servico)
                                              .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task CreateAgendamentoAsync(Agendamento agendamento)
        {
            await _context.Agendamentos.AddAsync(agendamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAgendamentoAsync(int id, Agendamento agendamentoAtualizado)
        {
            var  agendamentoExistente = await GetAgendamentoByIdAsync(id);

            if (agendamentoExistente != null)
            {
                agendamentoExistente.DataHora = agendamentoAtualizado.DataHora;
                agendamentoExistente.ClienteId = agendamentoAtualizado.ClienteId;
                agendamentoExistente.PetId = agendamentoAtualizado.PetId;
                agendamentoExistente.ServicoId = agendamentoAtualizado.ServicoId;

                _context.Agendamentos.Update(agendamentoExistente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAgendamentoAsync(int id)
        {
            var agendamento = await GetAgendamentoByIdAsync(id);

            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Agendamento>> GetAgendamentosByClienteAsync(int clienteId)
        {
            return await _context.Agendamentos.Include(a => a.Cliente)
                                              .Include(a => a.Pet)
                                              .Include(a => a.Servico)
                                              .Where(a => a.ClienteId == clienteId)
                                              .ToListAsync();
        }

        public async Task<IEnumerable<Agendamento>> GetAgendamentosByDateAsync(DateTime date)
        {
            return await _context.Agendamentos.Include(a => a.Cliente)
                                              .Include(a => a.Pet)
                                              .Include(a => a.Servico)
                                              .Where(a => a.DataHora.Date == date.Date)
                                              .ToListAsync();
        }

    }
}
