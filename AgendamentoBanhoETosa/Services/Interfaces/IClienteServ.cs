using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Model.DTOs;

namespace AgendamentoBanhoETosa.Services.Interfaces;
public interface IClienteServ
{
    // Método para obter todos os clientes
    Task<IEnumerable<ClienteDTO>> GetAllClientesAsync();

    // Método para obter um cliente pelo ID
    Task<ClienteDTO?> GetClienteByIdAsync(int id);

    // Método para adicionar um novo cliente
    Task<Cliente> AddClienteAsync(ClienteCreateDTO cliente);


    // Método para atualizar um cliente existente
    Task<bool> UpdateClienteAsync(int id, ClienteCreateDTO clienteAtualizado);

    // Método para excluir um cliente pelo ID
    Task<bool> DeleteClienteAsync(int id);
}

