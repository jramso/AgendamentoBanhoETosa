using AgendamentoBanhoETosa.Model.DTOs;
using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Repository.Interfaces;
using AgendamentoBanhoETosa.Services.Interfaces;

namespace AgendamentoBanhoETosa.Services.Implementations;

public class AnimalServ : IAnimalServ
{
    private readonly IAnimalRepo _animalRepo;

    public AnimalServ(IAnimalRepo animalRepo)
    {
        _animalRepo = animalRepo;
    }

    public async Task<IEnumerable<AnimalDTO>> GetAllAnimaisAsync()
    {
        var animais = await _animalRepo.GetAllAsync();
        return animais.Select(a => new AnimalDTO
        {
            Id = a.Id,
            Nome = a.Nome,
            Especie = a.Especie,
            Raca = a.Raca,
            ClienteId = a.ClienteId
        });
    }

    public async Task<AnimalDTO?> GetAnimalByIdAsync(int id)
    {
        var animal = await _animalRepo.GetByIdAsync(id);
        if (animal == null) return null;

        return new AnimalDTO
        {
            Id = animal.Id,
            Nome = animal.Nome,
            Especie = animal.EspecieAnimal,
            Raca = animal.Raca,
            ClienteId = animal.ClienteId
        };
    }

    public async Task<Animal> AddAnimalAsync(AnimalCreateDTO animalDto)
    {
        var animal = new Animal
        {
            Nome = animalDto.Nome,
            Especie = animalDto.Especie,
            Raca = animalDto.Raca,
            ClienteId = animalDto.ClienteId
        };
        await _animalRepo.AddAsync(animal);
        return animal;
    }

    public async Task<bool> UpdateAnimalAsync(int id, AnimalCreateDTO animalDto)
    {
        var animal = await _animalRepo.GetByIdAsync(id);
        if (animal == null) return false;

        animal.Nome = animalDto.Nome;
        animal.Especie = animalDto.Especie;
        animal.Raca = animalDto.Raca;
        animal.ClienteId = animalDto.ClienteId;

        await _animalRepo.UpdateAsync(animal);
        return true;
    }

    public async Task<bool> DeleteAnimalAsync(int id)
    {
        var animal = await _animalRepo.GetByIdAsync(id);
        if (animal == null) return false;

        await _animalRepo.DeleteAsync(animal);
        return true;
    }
}
