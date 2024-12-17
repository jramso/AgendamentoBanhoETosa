using Microsoft.EntityFrameworkCore;
using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgendamentoBanhoETosa.Services.Interfaces;

namespace AgendamentoBanhoETosa.Services.Implementations
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
            return await _context.Agendamentos.ToListAsync();
        }

        public async Task<Agendamento?> GetAgendamentoByIdAsync(int id)
        {
            return await _context.Agendamentos.FirstOrDefaultAsync(a => a.Id == id);
        }


        public async Task<Agendamento> CreateAgendamentoAsync(Agendamento agendamento)
        {
            // Verifica se o ClienteId é válido
            var clienteExiste = await _context.Clientes.AnyAsync(c => c.Id == agendamento.ClienteId);
            if (!clienteExiste)
            {
                throw new InvalidOperationException("O ClienteId fornecido não foi encontrado.");
            }

            // Verifica se o PetId é válido
            var petExiste = await _context.Pets.AnyAsync(p => p.Id == agendamento.PetId);
            if (!petExiste)
            {
                throw new InvalidOperationException("O PetId fornecido não foi encontrado.");
            }

            // Verifica se o ServicoId é válido
            var servicoExiste = await _context.Servicos.AnyAsync(s => s.Id == agendamento.ServicoId);
            if (!servicoExiste)
            {
                throw new InvalidOperationException("O ServicoId fornecido não foi encontrado.");
            }

            // Se tudo estiver válido, adiciona o agendamento
            await _context.Agendamentos.AddAsync(agendamento);
            await _context.SaveChangesAsync();
            return agendamento;
        }


        public async Task UpdateAgendamentoAsync(int id, Agendamento agendamentoAtualizado)
        {
            var agendamentoExistente = await GetAgendamentoByIdAsync(id);

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
            return await _context.Agendamentos
                                 .Where(a => a.ClienteId == clienteId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Agendamento>> GetAgendamentosByDateAsync(DateTime date)
        {
            return await _context.Agendamentos
                                 .Where(a => a.DataHora.Date == date.Date)
                                 .ToListAsync();
        }

    }
}
