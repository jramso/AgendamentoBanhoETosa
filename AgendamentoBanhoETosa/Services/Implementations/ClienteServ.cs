using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AgendamentoBanhoETosa.Repository.Interfaces;
using AgendamentoBanhoETosa.Model.DTOs;

namespace AgendamentoBanhoETosa.Services.Implementations;
public class ClienteServ : IClienteServ
{
    private readonly IClienteRepo _clienteRepo;

    public ClienteServ(IClienteRepo clienteRepo)
    {
        _clienteRepo = clienteRepo;
    }

    public async Task<IEnumerable<ClienteDTO>> GetAllClientesAsync()
    {
        var clientes = await _clienteRepo.GetAllAsync();
        return clientes.Select(c => new ClienteDTO
        {
            Id = c.Id,
            Nome = c.Nome,
            Telefone = c.Telefone,
            Endereco = c.Endereco
        });
    }

    public async Task<ClienteDTO?> GetClienteByIdAsync(int id)
    {
        var cliente = await _clienteRepo.GetByIdAsync(id);
        if (cliente == null) return null;

        return new ClienteDTO
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Telefone = cliente.Telefone,
            Endereco = cliente.Endereco
        };
    }

    public async Task<Cliente> AddClienteAsync(ClienteCreateDTO clienteDto)
    {
        var cliente = new Cliente
        {
            
            Nome = clienteDto.Nome,
            Telefone = clienteDto.Telefone,
            Endereco = clienteDto.Endereco
        };
        await _clienteRepo.AddAsync(cliente);
        return cliente;
    }

    public async Task<bool> UpdateClienteAsync(int id, ClienteCreateDTO clienteDto)
    {
        var cliente = await _clienteRepo.GetByIdAsync(id);
        if (cliente == null) return false;

        cliente.Nome = clienteDto.Nome;
        cliente.Telefone = clienteDto.Telefone;
        cliente.Endereco = clienteDto.Endereco;

        await _clienteRepo.UpdateAsync(cliente);
        return true;
    }

    public async Task<bool> DeleteClienteAsync(int id)
    {
        var cliente = await _clienteRepo.GetByIdAsync(id);
        if (cliente == null) return false;

        await _clienteRepo.DeleteAsync(cliente);
        return true;
    }
}
