using AgendamentoBanhoETosa.Model;


namespace AgendamentoBanhoETosa.Services;
public interface IClienteServ
{
    // Método para obter todos os clientes
    Task<IEnumerable<Cliente>> GetAllClientesAsync();

    // Método para obter um cliente pelo ID
    Task<Cliente?> GetClienteByIdAsync(int id);

    // Método para adicionar um novo cliente
    Task<Cliente> AddClienteAsync(Cliente cliente);

    // Método para atualizar um cliente existente
    Task<bool> UpdateClienteAsync(int id, Cliente clienteAtualizado);

    // Método para excluir um cliente pelo ID
    Task<bool> DeleteClienteAsync(int id);
}

