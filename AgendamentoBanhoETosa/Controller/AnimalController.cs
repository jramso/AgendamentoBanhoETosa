using Microsoft.AspNetCore.Mvc;
using AgendamentoBanhoETosa.Services.Interfaces;
using AgendamentoBanhoETosa.Model.DTOs;

namespace AgendamentoBanhoETosa.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalServ _animalService;

        public AnimalController(IAnimalServ animalService)
        {
            _animalService = animalService;
        }

        // GET: /Animal (obter todos os animais)
        [HttpGet]
        public async Task<IActionResult> GetAllAnimais()
        {
            var animais = await _animalService.GetAllAnimaisAsync();
            return Ok(animais);
        }

        // GET: /Animal/{id} (obter animal por id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalById(int id)
        {
            var animal = await _animalService.GetAnimalByIdAsync(id);
            if (animal == null)
            {
                return NotFound(new { mensagem = $"Animal com ID {id} não encontrado." });
            }
            return Ok(animal);
        }

        // POST: /Animal (adicionar novo animal)
        [HttpPost]
        public async Task<IActionResult> AddAnimal([FromBody] AnimalDTO novoAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var animalCriado = await _animalService.AddAnimalAsync(novoAnimal);

            if (animalCriado == null)
            {
                return NotFound(new { mensagem = $"Tutor com ID {novoAnimal.TutorId} não encontrado." });
            }

            return CreatedAtAction(nameof(GetAnimalById), new { id = animalCriado.Id }, animalCriado);
        }

        // PUT: /Animal/{id} (atualizar animal existente)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimal(int id, [FromBody] AnimalDTO animalAtualizado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var atualizado = await _animalService.UpdateAnimalAsync(id, animalAtualizado);
            if (!atualizado)
            {
                return NotFound(new { mensagem = $"Animal com ID {id} não encontrado para atualização." });
            }

            return NoContent();
        }

        // DELETE: /Animal/{id} (excluir animal pelo ID)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var deletado = await _animalService.DeleteAnimalAsync(id);
            if (!deletado)
            {
                return NotFound(new { mensagem = $"Animal com ID {id} não encontrado para exclusão." });
            }

            return NoContent();
        }
    }
}
