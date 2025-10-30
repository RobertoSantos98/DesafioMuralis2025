using DesafioMuralis2025.Application.Request;
using DesafioMuralis2025.Application.Services.ClienteServices;
using Microsoft.AspNetCore.Mvc;

namespace DesafioMuralis2025.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] CreateClienteRequest request)
        {
            var result = await _clienteService.AddAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _clienteService.GetAll();

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var result = await _clienteService.GetById(id);

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clienteService.DeleteAsync(id);
            return NoContent();
        }


    }
}
