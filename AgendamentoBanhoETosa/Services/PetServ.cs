using AgendamentoBanhoETosa.Data;
using AgendamentoBanhoETosa.Model;
using Microsoft.EntityFrameworkCore;
using AgendamentoBanhoETosa.Model.Enums;


namespace AgendamentoBanhoETosa.Services
{
    public class PetServ : IPetServ
    {
        private readonly AppDbContext _dbContext;
        public PetServ(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //obter todos os pets
        public async Task<IEnumerable<Pet>> GetAllPetsAsync()
        {
            return await _dbContext.Pets.ToListAsync();
        }

        // Obtém um pet pelo ID
        public async Task<Pet?> GetPetByIdAsync(int id)
        {
            return await _dbContext.Pets.FirstOrDefaultAsync(c => c.Id == id);
        }

        // Adiciona um novo pet
        public async Task<Pet?> AddPetAsync(Pet pet)
        {
            // Verifica se o ClienteId fornecido existe
            var clienteExiste = await _dbContext.Clientes.AnyAsync(c => c.Id == pet.ClienteId);
            if (!clienteExiste)
            {
                return null; // Cliente não encontrado
            }

            // Verifica a consistência do TipoPet e das Raças
            if (pet.Tipo == TipoPet.Cachorro && pet.RacaCachorro == null)
            {
                throw new ArgumentException("É necessário informar a raça do cachorro.");
            }

            if (pet.Tipo == TipoPet.Gato && pet.RacaGato == null)
            {
                throw new ArgumentException("É necessário informar a raça do gato.");
            }

            // Adiciona o pet e associa ao cliente pelo ClienteId
            _dbContext.Pets.Add(pet);
            await _dbContext.SaveChangesAsync();
            return pet;
        }


        // Atualiza um pet existente
        public async Task<bool> UpdatePetAsync(int id, Pet petAtualizado)
        {
            var pet = await _dbContext.Pets.FindAsync(id);
            if (pet == null)
            {
                return false; // Pet não encontrado
            }

            // Atualiza os campos necessários
            pet.Nome = petAtualizado.Nome;
            pet.Tipo = petAtualizado.Tipo;

            // Atualiza as raças de acordo com o tipo
            if (petAtualizado.Tipo == TipoPet.Cachorro)
            {
                pet.RacaCachorro = petAtualizado.RacaCachorro;
                pet.RacaGato = null; // Remove a raça de gato caso tenha sido configurada anteriormente
            }
            else if (petAtualizado.Tipo == TipoPet.Gato)
            {
                pet.RacaGato = petAtualizado.RacaGato;
                pet.RacaCachorro = null; // Remove a raça de cachorro caso tenha sido configurada anteriormente
            }

            await _dbContext.SaveChangesAsync();
            return true;
        }

        // Exclui um pet pelo ID
        public async Task<bool> DeletePetAsync(int id)
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
