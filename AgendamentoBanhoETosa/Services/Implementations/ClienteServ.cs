using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Model;
using AgendamentoBanhoETosa.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoBanhoETosa.Services.Implementations;
public class ClienteServ : IClienteServ
{
    private readonly AppDbContext _dbContext;

    public ClienteServ(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Obtém todos os clientes
    public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
    {
        return await _dbContext.Clientes.ToListAsync();
    }

    // Obtém um cliente pelo ID
    public async Task<Cliente?> GetClienteByIdAsync(int id)
    {
        return await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
    }

    // Adiciona um novo cliente
    public async Task<Cliente> AddClienteAsync(Cliente cliente)
    {
        _dbContext.Clientes.Add(cliente);
        await _dbContext.SaveChangesAsync();
        return cliente;
    }

    // Atualiza um cliente existente
    public async Task<bool> UpdateClienteAsync(int id, Cliente clienteAtualizado)
    {
        var cliente = await _dbContext.Clientes.FindAsync(id);
        if (cliente == null)
        {
            return false; // Cliente não encontrado
        }

        // Atualiza os campos necessários
        cliente.Nome = clienteAtualizado.Nome;
        cliente.Telefone = clienteAtualizado.Telefone;
        cliente.Endereco = clienteAtualizado.Endereco;

        await _dbContext.SaveChangesAsync();
        return true;
    }

    // Exclui um cliente pelo ID
    public async Task<bool> DeleteClienteAsync(int id)
    {
        var cliente = await _dbContext.Clientes.FindAsync(id);
        if (cliente == null)
        {
            return false; // Cliente não encontrado
        }

        _dbContext.Clientes.Remove(cliente);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
