using AgendamentoBanhoETosa.Model;
using AgendamentoBanhoETosa.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoBanhoETosa.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoServ _servicoService;

        public ServicoController(IServicoServ servicoService)
        {
            _servicoService = servicoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServicos()
        {
            var servicos = await _servicoService.GetAllServicosAsync();
            return Ok(servicos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicoById(int id)
        {
            var servico = await _servicoService.GetServicoByIdAsync(id);
            if (servico == null) return NotFound();
            return Ok(servico);
        }

        [HttpPost]
        public async Task<IActionResult> AddServico(Servico servico)
        {
            var newServico = await _servicoService.AddServicoAsync(servico);
            return CreatedAtAction(nameof(GetServicoById), new { id = newServico.Id }, newServico);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServico(int id, Servico servico)
        {
            var updated = await _servicoService.UpdateServicoAsync(id, servico);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServico(int id)
        {
            var deleted = await _servicoService.DeleteServicoAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

    }
}
