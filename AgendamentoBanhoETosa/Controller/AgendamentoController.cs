using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AgendamentoBanhoETosa.Services.Interfaces;
using AgendamentoBanhoETosa.Model.Entities;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var agendamentos = await _agendamentoServ.GetAllAgendamentosAsync();
            return Ok(agendamentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var agendamento = await _agendamentoServ.GetAgendamentoByIdAsync(id);
            if (agendamento == null)
                return NotFound();

            return Ok(agendamento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Agendamento agendamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var agendamentoCriado = await _agendamentoServ.CreateAgendamentoAsync(agendamento);
                return CreatedAtAction(nameof(GetById), new { id = agendamentoCriado.Id }, agendamentoCriado);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Agendamento agendamento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingAgendamento = await _agendamentoServ.GetAgendamentoByIdAsync(id);
            if (existingAgendamento == null)
                return NotFound();

            await _agendamentoServ.UpdateAgendamentoAsync(id, agendamento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingAgendamento = await _agendamentoServ.GetAgendamentoByIdAsync(id);
            if (existingAgendamento == null)
                return NotFound();

            await _agendamentoServ.DeleteAgendamentoAsync(id);
            return NoContent();
        }
    }
}
