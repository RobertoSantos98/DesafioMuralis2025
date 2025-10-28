using DesafioMuralis2025.Domain.Models;

namespace DesafioMuralis2025.Infrastructure.Repositories.Clientes
{
    public interface IClienteRepository
    {
        Task AddAsync(ClienteModel cliente);
        Task UpdateAsync(ClienteModel cliente);
        Task<ClienteModel?> GetById(int id);
        Task DeleteAsync (ClienteModel cliente);
        Task CommitAsync();
    }
}
