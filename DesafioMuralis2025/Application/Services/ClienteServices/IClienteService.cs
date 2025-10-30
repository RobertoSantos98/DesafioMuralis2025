using DesafioMuralis2025.Application.Request;
using DesafioMuralis2025.Domain.DTOs;
using DesafioMuralis2025.Domain.Models;

namespace DesafioMuralis2025.Application.Services.ClienteServices
{
    public interface IClienteService
    {
        Task<ResponseModel<ClienteDTO>> AddAsync(CreateClienteRequest request);
        Task<ResponseModel<ClienteDTO>> UpdateAsync(CreateClienteRequest request);
        Task DeleteAsync(int id);
        Task<ResponseModel<List<ClienteDTO>>> GetAll();
        Task<ResponseModel<ClienteDTO>> GetById(int id);

    }
}
