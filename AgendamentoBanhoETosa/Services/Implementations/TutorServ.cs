using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AgendamentoBanhoETosa.Repository.Interfaces;
using AgendamentoBanhoETosa.Model.DTOs;

namespace AgendamentoBanhoETosa.Services.Implementations;
public class TutorServ : ITutorServ
{
    private readonly ITutorRepo _clienteRepo;

    public TutorServ(ITutorRepo clienteRepo)
    {
        _clienteRepo = clienteRepo;
    }

    public async Task<IEnumerable<TutorDTO>> GetAllTutoresAsync()
    {
        var tutores = await _clienteRepo.GetAllAsync();
        return tutores.Select(c => new TutorDTO
        {
            Id = c.Id,
            Nome = c.Nome,
            Telefone = c.Telefone,
            Endereco = c.Endereco
        });
    }

    public async Task<TutorDTO?> GetTutorByIdAsync(int id)
    {
        var tutor = await _clienteRepo.GetByIdAsync(id);
        if (tutor == null) return null;

        return new TutorDTO
        {
            Id = tutor.Id,
            Nome = tutor.Nome,
            Telefone = tutor.Telefone,
            Endereco = tutor.Endereco
        };
    }

    public async Task<Tutor> AddTutorAsync(TutorDTO tutorDto)
    {
        var cliente = new Tutor
        {
            Id= tutorDto.Id,
            Nome = tutorDto.Nome,
            Telefone = tutorDto.Telefone,
            Endereco = tutorDto.Endereco
        };
        await _clienteRepo.AddAsync(cliente);
        return cliente;
    }

    public async Task<bool> UpdateTutorAsync(int id, TutorDTO tutorDto)
    {
        var cliente = await _clienteRepo.GetByIdAsync(id);
        if (cliente == null) return false;

        cliente.Nome = tutorDto.Nome;
        cliente.Telefone = tutorDto.Telefone;
        cliente.Endereco = tutorDto.Endereco;

        await _clienteRepo.UpdateAsync(cliente);
        return true;
    }

    public async Task<bool> DeleteTutorAsync(int id)
    {
        var tutor = await _clienteRepo.GetByIdAsync(id);
        if (tutor == null) return false;

        await _clienteRepo.DeleteAsync(tutor);
        return true;
    }
}
