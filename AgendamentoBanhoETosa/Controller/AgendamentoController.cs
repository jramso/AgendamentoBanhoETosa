using Microsoft.AspNetCore.Mvc;
using AgendamentoBanhoETosa.Services.Interfaces;
using AgendamentoBanhoETosa.Model.DTOs;

namespace AgendamentoBanhoETosa.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoServ _agendamentoServ;

        public AgendamentoController(IAgendamentoServ agendamentoServ)
        {
            _agendamentoServ = agendamentoServ;
        }

        // GET: /api/Agendamento
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var agendamentos = await _agendamentoServ.GetAllAgendamentosAsync();
            return Ok(agendamentos);
        }

        // GET: /api/Agendamento/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var agendamento = await _agendamentoServ.GetAgendamentoByIdAsync(id);
            if (agendamento == null)
                return NotFound(new { mensagem = $"Agendamento com ID {id} não encontrado." });

            return Ok(agendamento);
        }

        // POST: /api/Agendamento
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AgendamentoDTO agendamentoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var agendamentoCriado = await _agendamentoServ.CreateAgendamentoAsync(agendamentoDto);
                return CreatedAtAction(nameof(GetById), new { id = agendamentoCriado.Id }, agendamentoCriado);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        // PUT: /api/Agendamento/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AgendamentoDTO agendamentoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var atualizado = await _agendamentoServ.UpdateAgendamentoAsync(id, agendamentoDto);
            if (!atualizado)
                return NotFound(new { mensagem = $"Agendamento com ID {id} não encontrado para atualização." });

            return NoContent();
        }

        // DELETE: /api/Agendamento/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletado = await _agendamentoServ.DeleteAgendamentoAsync(id);
            if (!deletado)
                return NotFound(new { mensagem = $"Agendamento com ID {id} não encontrado para exclusão." });

            return NoContent();
        }
    }
}
