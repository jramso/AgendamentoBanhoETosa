using Microsoft.EntityFrameworkCore;
using SeuProjeto.Data;
using SeuProjeto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeuProjeto.Services
{
    public class AgendamentoServ : IAgendamentoServ
    {
        private readonly AppDbContext _context;

        public AgendamentoServ(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Agendamento>> ObterTodosAsync()
        {
            return await _context.Agendamentos.Include(a => a.Cliente)
                                              .Include(a => a.Pet)
                                              .Include(a => a.Servico)
                                              .ToListAsync();
        }

        public async Task<Agendamento?> ObterPorIdAsync(int id)
        {
            return await _context.Agendamentos.Include(a => a.Cliente)
                                              .Include(a => a.Pet)
                                              .Include(a => a.Servico)
                                              .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task CriarAsync(Agendamento agendamento)
        {
            await _context.Agendamentos.AddAsync(agendamento);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(int id, Agendamento agendamentoAtualizado)
        {
            var agendamentoExistente = await ObterPorIdAsync(id);

            if (agendamentoExistente != null)
            {
                agendamentoExistente.Data = agendamentoAtualizado.Data;
                agendamentoExistente.ClienteId = agendamentoAtualizado.ClienteId;
                agendamentoExistente.PetId = agendamentoAtualizado.PetId;
                agendamentoExistente.ServicoId = agendamentoAtualizado.ServicoId;

                _context.Agendamentos.Update(agendamentoExistente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletarAsync(int id)
        {
            var agendamento = await ObterPorIdAsync(id);

            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
