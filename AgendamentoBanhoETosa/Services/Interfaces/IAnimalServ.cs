using AgendamentoBanhoETosa.Model.DTOs;
using AgendamentoBanhoETosa.Model.Entities;


namespace AgendamentoBanhoETosa.Services.Interfaces
{
    public interface IAnimalServ
    {

        // Método para obter todos os pets
        Task<IEnumerable<AnimalDTO>> GetAllAnimaisAsync();

        // Método para obter um pet pelo ID
        Task<AnimalDTO?> GetAnimalByIdAsync(int id);

        // Método para adicionar um novo pet
        Task<Animal> AddAnimalAsync(AnimalDTO pet);

        // Método para atualizar um pet existente
        Task<bool> UpdateAnimalAsync(int id, AnimalDTO petAtualizado);

        // Método para excluir um pet pelo ID
        Task<bool> DeleteAnimalAsync(int id);


    }
}
