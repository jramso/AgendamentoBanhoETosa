using Microsoft.AspNetCore.Mvc;
using AgendamentoBanhoETosa.Model;
using AgendamentoBanhoETosa.Services;
using System.Threading.Tasks;

namespace SeuProjeto.Controllers
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

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var agendamentos = await _agendamentoServ.ObterTodosAsync();
            return Ok(agendamentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var agendamento = await _agendamentoServ.ObterPorIdAsync(id);
            if (agendamento == null)
                return NotFound();

            return Ok(agendamento);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] Agendamento agendamento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _agendamentoServ.CriarAsync(agendamento);
            return CreatedAtAction(nameof(ObterPorId), new { id = agendamento.Id }, agendamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Agendamento agendamento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var agendamentoExistente = await _agendamentoServ.ObterPorIdAsync(id);
            if (agendamentoExistente == null)
                return NotFound();

            await _agendamentoServ.AtualizarAsync(id, agendamento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var agendamentoExistente = await _agendamentoServ.ObterPorIdAsync(id);
            if (agendamentoExistente == null)
                return NotFound();

            await _agendamentoServ.DeletarAsync(id);
            return NoContent();
        }
    }
}
