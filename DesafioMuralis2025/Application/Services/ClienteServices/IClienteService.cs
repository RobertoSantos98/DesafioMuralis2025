using DesafioMuralis2025.Application.Request;

namespace DesafioMuralis2025.Application.Services.ClienteServices
{
    public interface IClienteService
    {
        Task AddAsync(ClienteRequest request);
        Task UpdateAsync(ClienteRequest request);
        Task DeleteAsync(int id);
        Task GetAll();
        Task GetById(int id);

    }
}
