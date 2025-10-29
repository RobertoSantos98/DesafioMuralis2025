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
        public async Task<IActionResult> PostClient(ClienteRequest request)
        {
            var result = await _clienteService.AddAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Created();
        }
    }
}
