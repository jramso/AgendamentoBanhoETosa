using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Model.DTOs;

namespace AgendamentoBanhoETosa.Services.Interfaces;
public interface ITutorServ
{
    // Método para obter todos os clientes
    Task<IEnumerable<TutorDTO>> GetAllTutoresAsync();

    // Método para obter um cliente pelo ID
    Task<TutorDTO?> GetTutorByIdAsync(int id);

    // Método para adicionar um novo cliente
    Task<Tutor> AddTutorAsync(TutorCreateDTO cliente);


    // Método para atualizar um cliente existente
    Task<bool> UpdateTutorAsync(int id, TutorCreateDTO clienteAtualizado);

    // Método para excluir um cliente pelo ID
    Task<bool> DeleteTutorAsync(int id);
}

