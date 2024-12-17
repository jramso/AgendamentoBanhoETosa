using AgendamentoBanhoETosa.Model;
using AgendamentoBanhoETosa.Services;
using AgendamentoBanhoETosa.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoBanhoETosa.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalServ _petService;

        public AnimalController(IAnimalServ petService)
        {
            _petService = petService;
        }

        // GET: /Pet (obter todos os pets)
        [HttpGet]
        public async Task<IActionResult> GetAllPets()
        {
            var pets = await _petService.GetAllPetsAsync();
            return Ok(pets);
        }

        // GET: /Pet/{id} (obter pet por id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPetById(int id)
        {
            var pet = await _petService.GetAnimalByIdAsync(id);
            if (pet == null)
            {
                return NotFound(new { mensagem = $"Pet com ID {id} não encontrado." });
            }
            return Ok(pet);
        }

        [HttpPost]
        public async Task<IActionResult> AddPet([FromBody] Animal novoPet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var petCriado = await _petService.AddAnimalAsync(novoPet);

            if (petCriado == null)
            {
                return NotFound($"Cliente com ID {novoPet.ClienteId} não encontrado.");
            }

            return CreatedAtAction(nameof(GetPetById), new { id = petCriado.Id }, petCriado);
        }



        // PUT: /Pet/{id} (atualizar pet existente)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, [FromBody] Animal petAtualizado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var atualizado = await _petService.UpdateAnimalAsync(id, petAtualizado);
            if (!atualizado)
            {
                return NotFound(new { mensagem = $"Pet com ID {id} não encontrado para atualização." });
            }

            return NoContent();
        }

        // DELETE: /Pet/{id} (excluir pet pelo ID)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var deletado = await _petService.DeleteAnimalAsync(id);
            if (!deletado)
            {
                return NotFound(new { mensagem = $"Pet com ID {id} não encontrado para exclusão." });
            }

            return NoContent();
        }
    }
}
