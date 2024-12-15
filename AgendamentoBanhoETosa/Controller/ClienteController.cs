using AgendamentoBanhoETosa.Model;
using AgendamentoBanhoETosa.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoBanhoETosa.Controller
{
    [ApiController] //controlador de API
    [Route("[controller]")] // Define a rota base como "/Cliente"
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServ _clienteService;
        public ClienteController(IClienteServ clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: /Cliente (todos os clientes)
        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            // Chama o serviço para buscar os clientes
            var clientes = await _clienteService.GetAllClientesAsync();

            // Retorna os clientes no formato JSON
            return Ok(clientes);
        }

        // GET: /Cliente/{id} (clientes por id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound(new { mensagem = $"Cliente com ID {id} não encontrado." });
            }
            return Ok(cliente);
        }

        // POST: /Cliente
        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] Cliente novoCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clienteCriado = await _clienteService.AddClienteAsync(novoCliente);
            return CreatedAtAction(nameof(GetClienteById), new { id = clienteCriado.Id }, clienteCriado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound(new { mensagem = $"Cliente com ID {id} não encontrado para exclusão." });
            }

            await _clienteService.DeleteClienteAsync(id);
            return NoContent();
        }


    }
}
