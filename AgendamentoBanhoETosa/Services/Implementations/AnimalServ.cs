using AgendamentoBanhoETosa.Model.DTOs;
using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Model.Enums;
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
            Tipo = a.EspecieAnimal,
            RacaCachorro = a.RacaCachorro,
            RacaGato = a.RacaGato,
            TutorId = a.TutorID
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
            Tipo = animal.EspecieAnimal,
            RacaCachorro = animal.EspecieAnimal == Especie.Cachorro ? animal.RacaCachorro : null,
            RacaGato = animal.EspecieAnimal == Especie.Gato ? animal.RacaGato : null,
            TutorId = animal.TutorID
        };
    }


    public async Task<Animal> AddAnimalAsync(AnimalDTO animalDto)
    {
        var animal = new Animal
        {
            Nome = animalDto.Nome,
            EspecieAnimal = animalDto.Tipo,
            TutorID = animalDto.TutorId
        };

        // Validação e atribuição das raças
        if (animalDto.Tipo == Especie.Gato)
        {
            if (animalDto.RacaGato.HasValue)
            {
                animal.RacaGato = animalDto.RacaGato;
            }
            else
            {
                throw new ArgumentException("Raça do gato não foi fornecida.");
            }
        }
        else if (animalDto.Tipo == Especie.Cachorro)
        {
            if (animalDto.RacaCachorro.HasValue)
            {
                animal.RacaCachorro = animalDto.RacaCachorro;
            }
            else
            {
                throw new ArgumentException("Raça do cachorro não foi fornecida.");
            }
        }
        else
        {
            throw new ArgumentException("Espécie inválida ou não suportada.");
        }

        await _animalRepo.AddAsync(animal);
        return animal;
    }



    public async Task<bool> UpdateAnimalAsync(int id, AnimalDTO animalDto)
    {
        var animal = await _animalRepo.GetByIdAsync(id);
        if (animal == null) return false;

        animal.Nome = animalDto.Nome;
        animal.EspecieAnimal = animalDto.Tipo;

        if (animalDto.Tipo == Especie.Cachorro)
        {
            animal.RacaCachorro = animalDto.RacaCachorro;
            animal.RacaGato = null; // Limpa a raça de gato caso seja um cachorro.
        }
        else if (animalDto.Tipo == Especie.Gato)
        {
            animal.RacaGato = animalDto.RacaGato;
            animal.RacaCachorro = null; // Limpa a raça de cachorro caso seja um gato.
        }

        animal.TutorID = id;

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
