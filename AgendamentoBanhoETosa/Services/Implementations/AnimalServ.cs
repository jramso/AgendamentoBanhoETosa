using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace AgendamentoBanhoETosa.Services.Implementations
{
    public class AnimalServ : IAnimalServ
    {
        private readonly AppDbContext _dbContext;
        public AnimalServ(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //obter todos os pets
        public async Task<IEnumerable<Animal>> GetAllPetsAsync()
        {
            return await _dbContext.Pets.ToListAsync();
        }

        // Obtém um pet pelo ID
        public async Task<Animal?> GetAnimalByIdAsync(int id)
        {
            return await _dbContext.Pets.FirstOrDefaultAsync(c => c.Id == id);
        }

        // Adiciona um novo pet
        public async Task<Animal?> AddAnimalAsync(Animal animal)
        {
            // Verifica se o ClienteId fornecido existe
            var clienteExiste = await _dbContext.Clientes.AnyAsync(c => c.Id == animal.ClienteId);
            if (!clienteExiste)
            {
                return null; // Cliente não encontrado
            }

            // Adiciona o pet e associa ao cliente pelo ClienteId
            _dbContext.Pets.Add(animal);
            await _dbContext.SaveChangesAsync();
            return animal;
        }


        // Atualiza um pet existente
        public async Task<bool> UpdateAnimalAsync(int id, Animal petAtualizado)
        {
            var animal = await _dbContext.Pets.FindAsync(id);
            if (animal == null)
            {
                return false; // Pet não encontrado
            }

            // Atualiza os campos necessários
            animal.Nome = petAtualizado.Nome;
            animal.EspecieAnimal = petAtualizado.EspecieAnimal;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        // Exclui um pet pelo ID
        public async Task<bool> DeleteAnimalAsync(int id)
        {
            var pet = await _dbContext.Pets.FindAsync(id);
            if (pet == null)
            {
                return false; // pet não encontrado
            }

            _dbContext.Pets.Remove(pet);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
