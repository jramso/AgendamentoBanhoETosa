using Microsoft.EntityFrameworkCore;
using AgendamentoBanhoETosa.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgendamentoBanhoETosa.Services.Interfaces;
using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Model.DTOs;

namespace AgendamentoBanhoETosa.Services.Implementations
{
    public class AgendamentoServ : IAgendamentoServ
    {
        private readonly AppDbContext _context;

        public AgendamentoServ(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AgendamentoDTO>> GetAllAgendamentosAsync()
        {
            return await _context.Agendamentos
                .Select(a => new AgendamentoDTO
                {
                    Id = a.Id,
                    DataHora = a.DataHora,
                    TutorId = a.TutorId,
                    AnimalId = a.AnimalId,
                    ServicoId = a.ServicoId
                })
                .ToListAsync();
        }

        public async Task<AgendamentoDTO?> GetAgendamentoByIdAsync(int id)
        {
            var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.Id == id);
            if (agendamento == null) return null;

            return new AgendamentoDTO
            {
                Id = agendamento.Id,
                DataHora = agendamento.DataHora,
                TutorId = agendamento.TutorId,
                AnimalId = agendamento.AnimalId,
                ServicoId = agendamento.ServicoId
            };
        }

        public async Task<AgendamentoDTO> CreateAgendamentoAsync(AgendamentoDTO agendamentoDto)
        {
            // Validações
            if (!await _context.Tutores.AnyAsync(c => c.Id == agendamentoDto.TutorId))
                throw new InvalidOperationException("O TutorId fornecido não foi encontrado.");

            if (!await _context.Animais.AnyAsync(p => p.Id == agendamentoDto.AnimalId))
                throw new InvalidOperationException("O AnimalId fornecido não foi encontrado.");

            if (!await _context.Servicos.AnyAsync(s => s.Id == agendamentoDto.ServicoId))
                throw new InvalidOperationException("O ServicoId fornecido não foi encontrado.");

            // Criação
            var agendamento = new Agendamento
            {
                DataHora = agendamentoDto.DataHora,
                TutorId = agendamentoDto.TutorId,
                AnimalId = agendamentoDto.AnimalId,
                ServicoId = agendamentoDto.ServicoId
            };

            await _context.Agendamentos.AddAsync(agendamento);
            await _context.SaveChangesAsync();

            agendamentoDto.Id = agendamento.Id;
            return agendamentoDto;
        }

        public async Task<bool> UpdateAgendamentoAsync(int id, AgendamentoDTO agendamentoDto)
        {
            var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.Id == id);
            if (agendamento == null) return false;

            agendamento.DataHora = agendamentoDto.DataHora;
            agendamento.TutorId = agendamentoDto.TutorId;
            agendamento.AnimalId = agendamentoDto.AnimalId;
            agendamento.ServicoId = agendamentoDto.ServicoId;

            _context.Agendamentos.Update(agendamento);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAgendamentoAsync(int id)
        {
            var agendamento = await _context.Agendamentos.FirstOrDefaultAsync(a => a.Id == id);
            if (agendamento == null) return false;

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AgendamentoDTO>> GetAgendamentosByClienteAsync(int clienteId)
        {
            return await _context.Agendamentos
                .Where(a => a.TutorId == clienteId)
                .Select(a => new AgendamentoDTO
                {
                    Id = a.Id,
                    DataHora = a.DataHora,
                    TutorId = a.TutorId,
                    AnimalId = a.AnimalId,
                    ServicoId = a.ServicoId
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AgendamentoDTO>> GetAgendamentosByDateAsync(DateTime date)
        {
            return await _context.Agendamentos
                .Where(a => a.DataHora.Date == date.Date)
                .Select(a => new AgendamentoDTO
                {
                    Id = a.Id,
                    DataHora = a.DataHora,
                    TutorId = a.TutorId,
                    AnimalId = a.AnimalId,
                    ServicoId = a.ServicoId
                })
                .ToListAsync();
        }
    }
}
