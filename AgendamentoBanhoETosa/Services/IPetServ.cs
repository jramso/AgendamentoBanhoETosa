using AgendamentoBanhoETosa.Model;


namespace AgendamentoBanhoETosa.Services
{
    public interface IPetServ
    {

        // Método para obter todos os pets
        Task<IEnumerable<Pet>> GetAllPetsAsync();

        // Método para obter um pet pelo ID
        Task<Pet?> GetPetByIdAsync(int id);

        // Método para adicionar um novo cliente
        Task<Pet> AddPetAsync(Pet pet);

        // Método para atualizar um pet existente
        Task<bool> UpdatePetAsync(int id, Pet petAtualizado);

        // Método para excluir um pet pelo ID
        Task<bool> DeletePetAsync(int id);


    }
}
