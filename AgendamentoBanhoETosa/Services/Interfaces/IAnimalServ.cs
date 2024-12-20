using AgendamentoBanhoETosa.Model.Entities;


namespace AgendamentoBanhoETosa.Services.Interfaces
{
    public interface IAnimalServ
    {

        // Método para obter todos os pets
        Task<IEnumerable<Animal>> GetAllPetsAsync();

        // Método para obter um pet pelo ID
        Task<Animal?> GetAnimalByIdAsync(int id);

        // Método para adicionar um novo pet
        Task<Animal> AddAnimalAsync(Animal pet);

        // Método para atualizar um pet existente
        Task<bool> UpdateAnimalAsync(int id, Animal petAtualizado);

        // Método para excluir um pet pelo ID
        Task<bool> DeleteAnimalAsync(int id);


    }
}
