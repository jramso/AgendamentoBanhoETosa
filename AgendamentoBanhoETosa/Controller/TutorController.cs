using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AgendamentoBanhoETosa.Model.DTOs;

namespace AgendamentoBanhoETosa.Controller
{
    [ApiController] //controlador de API
    [Route("[controller]")] // Define a rota base como "/Tutor"
    public class TutorController : ControllerBase
    {
        private readonly ITutorServ _tutorService;
        public TutorController(ITutorServ clienteService)
        {
            _tutorService = clienteService;
        }

        // GET: /Tutor (todos os clientes)
        [HttpGet]
        public async Task<IActionResult> GetAllTutores()
        {
            // Chama o serviço para buscar os clientes
            var clientes = await _tutorService.GetAllTutoresAsync();

            // Retorna os clientes no formato JSON
            return Ok(clientes);
        }

        // GET: /Tutor/{id} (clientes por id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTutorById(int id)
        {
            var cliente = await _tutorService.GetTutorByIdAsync(id);
            if (cliente == null)
            {
                return NotFound(new { mensagem = $"Tutor com ID {id} não encontrado." });
            }
            return Ok(cliente);
        }

        // POST: /Tutor
        [HttpPost]
        public async Task<IActionResult> AddTutor([FromBody] TutorDTO novoTutor)
        {
            await _tutorService.AddTutorAsync(novoTutor);
            return CreatedAtAction(nameof(GetTutorById), new { id = novoTutor }, novoTutor);
        }

        // PUT: /Tutor/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTutor(int id, [FromBody] TutorDTO tutorAtualizado)
        {
            // Verifica se os dados enviados são válidos
            if (tutorAtualizado == null)
            {
                return BadRequest(new { mensagem = "Dados inválidos para atualização." });
            }

            // Verifica se o tutor existe no banco de dados
            var tutorExistente = await _tutorService.GetTutorByIdAsync(id);
            if (tutorExistente == null)
            {
                return NotFound(new { mensagem = $"Tutor com ID {id} não encontrado." });
            }

            // Atualiza os dados do tutor
            await _tutorService.UpdateTutorAsync(id, tutorAtualizado);

            return Ok(new { mensagem = $"Tutor com ID {id} atualizado com sucesso!" });
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _tutorService.GetTutorByIdAsync(id);
            if (cliente == null)
            {
                return NotFound(new { mensagem = $"Tutor com ID {id} não encontrado para exclusão." });
            }

            await _tutorService.DeleteTutorAsync(id);
            return NoContent();
        }


    }
}
