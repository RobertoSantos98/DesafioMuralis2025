using DesafioMuralis2025.Application.Request;
using DesafioMuralis2025.Domain.DTOs;
using DesafioMuralis2025.Domain.Models;

namespace DesafioMuralis2025.Application.Services.ClienteServices
{
    public interface IClienteService
    {
        Task<ResponseModel<ClienteDTO>> AddAsync(ClienteRequest request);
        Task UpdateAsync(ClienteRequest request);
        Task DeleteAsync(int id);
        Task GetAll();
        Task GetById(int id);

    }
}
