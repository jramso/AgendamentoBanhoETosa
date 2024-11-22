using AgendamentoBanhoETosa.Model;
using AgendamentoBanhoETosa.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoBanhoETosa.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetServ _petService;

        public PetController(IPetServ petService)
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
            var pet = await _petService.GetPetByIdAsync(id);
            if (pet == null)
            {
                return NotFound(new { mensagem = $"Pet com ID {id} não encontrado." });
            }
            return Ok(pet);
        }

        // POST: /Pet (adicionar novo pet)
        [HttpPost]
        public async Task<IActionResult> AddPet([FromBody] Pet novoPet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var petCriado = await _petService.AddPetAsync(novoPet);
            return CreatedAtAction(nameof(GetPetById), new { id = petCriado.Id }, petCriado);
        }

        // PUT: /Pet/{id} (atualizar pet existente)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(int id, [FromBody] Pet petAtualizado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var atualizado = await _petService.UpdatePetAsync(id, petAtualizado);
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
            var deletado = await _petService.DeletePetAsync(id);
            if (!deletado)
            {
                return NotFound(new { mensagem = $"Pet com ID {id} não encontrado para exclusão." });
            }

            return NoContent();
        }
    }
}
