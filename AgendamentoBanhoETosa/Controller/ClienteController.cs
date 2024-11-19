using AgendamentoBanhoETosa.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoBanhoETosa.Controller
{
    [ApiController] // Indica que a classe é um controlador de API
    [Route("[controller]")] // Define a rota base como "/Cliente"
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServ _clienteService;

        // Injeção de dependência do serviço
        public ClienteController(IClienteServ clienteService)
        {
            _clienteService = clienteService;
        }

        // Endpoint para buscar todos os clientes
        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            // Chama o serviço para buscar os clientes
            var clientes = await _clienteService.GetAllClientesAsync();

            // Retorna os clientes no formato JSON
            return Ok(clientes);
        }
    }
}
