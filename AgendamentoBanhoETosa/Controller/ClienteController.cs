using AgendamentoBanhoETosa.Model.Entities;
using AgendamentoBanhoETosa.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AgendamentoBanhoETosa.DTOs;

namespace AgendamentoBanhoETosa.Controller
{
    [ApiController] //controlador de API
    [Route("[controller]")] // Define a rota base como "/Tutor"
    public class ClienteController : ControllerBase
    {
        private readonly ITutorServ _clienteService;
        public ClienteController(ITutorServ clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: /Tutor (todos os clientes)
        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            // Chama o serviço para buscar os clientes
            var clientes = await _clienteService.GetAllTutoresAsync();

            // Retorna os clientes no formato JSON
            return Ok(clientes);
        }

        // GET: /Tutor/{id} (clientes por id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetTutorByIdAsync(id);
            if (cliente == null)
            {
                return NotFound(new { mensagem = $"Tutor com ID {id} não encontrado." });
            }
            return Ok(cliente);
        }

        // POST: /Tutor
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] ClienteDTO novoCliente)
        {
            await _clienteService.AddClienteAsync(novoCliente);
            return CreatedAtAction(nameof(GetClienteById), new { id = novoCliente }, novoCliente);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _clienteService.GetTutorByIdAsync(id);
            if (cliente == null)
            {
                return NotFound(new { mensagem = $"Tutor com ID {id} não encontrado para exclusão." });
            }

            await _clienteService.DeleteTutorAsync(id);
            return NoContent();
        }


    }
}
